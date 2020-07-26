using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Threading;
using System.Diagnostics;
using Flir.Atlas.Live.Device;
using Flir.Atlas.Live.Discovery;
using Flir.Atlas.Live.WinForms;
using Flir.Atlas.Image;
using Flir.Atlas.Image.Fusion;
using Flir.Atlas.Image.Palettes;
//using Flir.Atlas.Image.Palettes;
//using Appearance = Flir.Atlas.Image.Isotherms.Appearance;

namespace FlirProjectC3
{
    public partial class FlirC3 : Form
    {
        string filename = string.Empty;
        static Discovery _discovery;
        static ThermalCamera _camera;
        ThermalImage image;
        ThermalImageFile ThermalImageFile;
        public FlirC3()
        {
            InitializeComponent();
        }
        void _discovery_DeviceFound(object sender, CameraDeviceInfoEventArgs e)
        {
            //BeginInvoke((Action)(() => AddDevice(e.CameraDevice)));
            var cameraDeviceInfo = new CameraDeviceInfo(e.CameraDevice);
            if (cameraDeviceInfo.IsFlirCamera)
            {
                //MessageBox.Show(e.CameraDevice.IsFlirCamera.ToString());

                //PictureBox PictureBox1 = new PictureBox();
                //Label Label1 = new Label();

                
                var streamingFormat = ImageFormat.FlirFileFormat;
                cameraDeviceInfo.SelectedStreamingFormat = streamingFormat;
                Console.WriteLine(cameraDeviceInfo.SelectedStreamingFormat);

                switch (cameraDeviceInfo.SelectedStreamingFormat)
                {
                    case ImageFormat.FlirFileFormat:
                        _camera = new ThermalCamera();
                        
                        //MessageBox.Show("Hi");
                        break;
                    case ImageFormat.Argb:
                        //MessageBox.Show("Hi");
                        _camera = new ThermalCamera();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
                // _camera = new ThermalCamera();

                Size size = new Size(720, 480);
                Size size2 = new Size(1080, 720);

                Console.WriteLine(_camera.ConnectionStatus);
                _camera.Connect(cameraDeviceInfo);
                while (!_camera.ConnectionStatus.Equals(ConnectionStatus.Connected));
                // _camera.EnumerateResolutions().Add(size);
                int preTime = 0;
                while (_camera.ConnectionStatus.Equals(ConnectionStatus.Connected))
                {

                    //List<T> ts = _camera.EnumerateResolutions.Width
                    int curtimeS = DateTime.Now.Second;

                    if(curtimeS%1 == 0)
                    {
                        if(curtimeS != preTime)
                        {
                            int inde = _camera.SelectedResolutionIndex;
                            //this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { label2.Text = "Index " + _camera.EnumerateResolutions().Count.ToString(); });
                            //image = new ThermalImage();
                            _camera.GetImage().EnterLock();
                            image = _camera.ThermalImage;

                            image.Scale.IsAutoAdjustEnabled = true;
                            image.Palette = PaletteManager.Iron;

                            //image.Fusion.Mode = image.Fusion.Msx;
                            //ThermalImageFile.Save();
                            //var ir = new ThermalImageFile(image);

                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { Max.Text = "Max = " + image.Statistics.Max.Value.ToString("0.00"); });
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { Min.Text = "Min = " + image.Statistics.Min.Value.ToString("0.00"); });
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { label3.Text = "H " + image.Height.ToString(); });
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { label4.Text = "W " + image.Width.ToString(); });
                            //byte[] thermalValue = image.GetData();
                            //MessageBox.Show(image.CompassInformation.ToString());
                            //image.Height;
                            //image.Width.Equals(1080);
                            //ThermalImage thermalImage = new ThermalImage();

                            //thermalImage.Equals(image);
                            //pictureBox2.Image = image;
                            // MessageBox.Show(_camera.EnumerateResolutions().ToString());
                            //Bitmap image1 = new Bitmap(image.Image);
                            //image.RenderTo();
                            string dt = image.DateTime.ToString();
                            DateTime dateTime = new DateTime();
                            
                            
                            int curtimeY = DateTime.Now.Year;
                            
                            String timeStamp = curtimeY.ToString() + DateTime.Now.ToString("MMddHHmmss");
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { label5.Text = "Running...."; });
                            string path = "dataset/tempCSV/" + timeStamp + ".csv";
                            System.IO.StreamWriter file = new System.IO.StreamWriter(path);
                            double spot = 0;
                            double[,] pixel_array = image.ImageProcessing.GetPixelsArray(); //array containing the raw signal data
                            double[] temps = { 0, 0, 0, 0, 0 , 0, 0, 0, 0, 0};
                            string his = "";
                            for (int y = 0; y < image.Height; y++)
                            {
                                string line = string.Empty;
                                for (int x = 0; x < image.Width; x++)
                                {
                                    int pixel_int = (int)pixel_array[y, x]; //casting the signal value to int
                                    double pixel_temp = image.GetValueFromSignal(pixel_int); //converting signal to temperature

                                    if(pixel_temp < 30) { temps[0] += 1; }
                                    else if(pixel_temp < 31) { temps[1] += 1; }
                                    else if(pixel_temp < 32) { temps[2] += 1; }
                                    else if (pixel_temp < 33) { temps[3] += 1; }
                                    else if (pixel_temp < 34) { temps[4] += 1; }
                                    else if (pixel_temp < 35) { temps[5] += 1; }
                                    else if (pixel_temp < 36) { temps[6] += 1; }
                                    else if (pixel_temp < 37) { temps[7] += 1; }
                                    else if (pixel_temp < 38) { temps[8] += 1; }
                                    else if (pixel_temp >= 38) { temps[9] += 1; }

                                    int test_int = (int)pixel_array[image.Height / 2, image.Width / 2];
                                    spot = image.GetValueFromSignal(test_int);
                                    line += pixel_temp.ToString("0.00") + ";"; //"building" each line
                                    
                                }
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.Clear()));
                                
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("<30", temps[0])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("30", temps[1])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("31", temps[2])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("32", temps[3])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("33", temps[4])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("34", temps[5])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("35", temps[6])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("36", temps[7])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY("37", temps[8])));
                                BeginInvoke((Action)(() => chart1.Series["Temp"].Points.AddXY(">37", temps[9])));

                                file.WriteLine(line); //writing a line to the excel sheet
                            }
                            for(int i = 0;i < 10; i++)
                            {
                                his += temps[i].ToString() + ";";
                            }
                            file.WriteLine(his);
                            file.Flush();
                            file.Close();
                            //image.Image.Save("C:/Users/nataw/Desktop/CEKMITL/summer/img/FLIR0002.jpg");


                            // _camera.GetImage().SaveSnapshot("C:/Users/nataw/Desktop/CEKMITL/summer/img/FLIR0001.jpg");


                            try
                            {

                                if (_camera.ConnectionStatus == ConnectionStatus.Connected)
                                {
                                    image.SaveSnapshot("dataset/img/"+ timeStamp+".jpg");
                                }
                            }
                            catch (Exception exception)
                            {
                                //MessageBox.Show("Failed to save snapshot: " + exception.Message);
                            }
                            finally
                            {
                                _camera.GetImage().ExitLock();
                            }
                            pictureBox2.Image = _camera.ThermalImage.Image;
                            this.BeginInvoke((System.Windows.Forms.MethodInvoker)delegate () { label1.Text = spot.ToString("0.00") + " C"; });

                        }
                    }
                    preTime = curtimeS;
                    // foreach (var s in _camera.EnumerateResolutions())


                    //_camera.SelectedResolutionIndex = 0;
                    


                   /* try
                    {
                        // Retrieve the image.
                        //image1 = image.Image;

                        int x, y;
                       // label1.Text = image1.Height.ToString()+" - "+image1.Width.ToString();
                        // Loop through the images pixels to reset color.
                        for (x = 0; x < image1.Width; x++)
                        {

                            for (y = 0; y < image1.Height; y++)
                            {

                                Color pixelColor = image1.GetPixel(x, y);
                                //Console.WriteLine(pixelColor);
                                Color newColor = Color.FromArgb(pixelColor.R, pixelColor.G, pixelColor.B);
                                image1.SetPixel(x, y, newColor);
                            }
                        }

                        // Set the PictureBox to display the image.
                        //pictureBox2.Image = Image4; 
                        
                        
                        //_camera.ThermalImage;
                        //image.InternalSaveSnapshot("C:/Users/nataw/Desktop/CEKMITL/summer/img/FLIR0002.jpg",image1);
                        //_camera.GetImage().SaveSnapshot("C:/Users/nataw/Desktop/CEKMITL/summer/img/FLIR0001.jpg");
                        // Display the pixel format in Label1.
                        //label1.Text = "Pixel format: " + image1.PixelFormat.ToString();
                    }
                    catch (ArgumentException)
                    {
                        MessageBox.Show("There was an error." +
                            "Check the path to the image file.");
                    }*/
                }



                
                //_camera.Disconnect();
                Console.WriteLine(_camera.ConnectionStatus);
            }
            else
            {
                Console.WriteLine("Not flir");
            }
            /* foreach (var streamingFormat in cameraDeviceInfo.StreamingFormats)
             {
                 var info = new CameraDeviceInfo(cameraDeviceInfo);
                 info.SelectedStreamingFormat = streamingFormat;
                 if (info.IsFlirCamera)
                 {
                     Console.WriteLine(info.SelectedStreamingFormat);
                 }
                 else
                 {
                     Console.WriteLine("not");
                 }
             }*/

        }
        void Start()
        {
            Stop();
            _discovery = new Discovery();
            _discovery.DeviceFound += _discovery_DeviceFound;
            //_discovery.DeviceLost += _discovery_DeviceLost;
            //_discovery.DeviceError += _discovery_DeviceError;

            // Scan for camera devices on all interfaces. If you are only interested in devices from i.e. USB
            // then you can start Discovery with the bit-flag Interface.Usb.

            _discovery.Start(Interface.Usb);

            // or with a combination
            // _discovery.Start(Interface.Network | Interface.Usb); 

            // Start discovery, scan on all interfaces. 
            // This requires that Bonjour and the Pleora drivers are installed, see the Atlas web page for more information.

            //_discovery.Start();
        }
        static void DisposeDiscovery(Object context)
        {
            var discovery = (Discovery)context;
            discovery.Dispose();
        }
        private void Stop()
        {
            if (_discovery == null) return;
            _discovery.DeviceFound -= _discovery_DeviceFound;
            // Stop discovery might take some time. Put dispose of discovery on a background thread.
            ThreadPool.QueueUserWorkItem(DisposeDiscovery, _discovery);
            _discovery = null;
        }
       /* private void OK_Click(object sender, EventArgs e)
        {
            Stop();
            DisconnectCamera();
            DisposeCamera();
            Start();
        }*/

      /*  private void dis_Click(object sender, EventArgs e)
        {
            DisconnectCamera();
        }*/

        private void FlirC3_Load(object sender, EventArgs e)
        {
            Start();
        }
        private void DisposeCamera()
        {

            if (_camera == null) return;

            //_camera.GetImage().Changed -= Image_Changed;
            _camera.Dispose();
        }
        private bool IsDirty { get; set; }
        void Image_Changed(object sender, Flir.Atlas.Image.ImageChangedEventArgs e)
        {
            IsDirty = true;
        }

        private void DisconnectCamera()
        {
            if (_camera == null) return;

            _camera.Disconnect();
        }

        private void closing(object sender, FormClosingEventArgs e)
        {
            Stop();
            DisconnectCamera();
            DisposeCamera();
        }

        private void Max_Click(object sender, EventArgs e)
        {

        }

        private void Chart1_Click(object sender, EventArgs e)
        {

        }

        private void Find_device_click(object sender, EventArgs e)
        {
            Stop();
            DisconnectCamera();
            DisposeCamera();
            Start();
        }

        private void disconnect_Click(object sender, EventArgs e)
        {
            DisconnectCamera();
        }
    }
}
