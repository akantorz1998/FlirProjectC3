﻿namespace FlirProjectC3
{
    partial class FlirC3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.OK = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dis = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Max = new System.Windows.Forms.Label();
            this.Min = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // OK
            // 
            this.OK.Location = new System.Drawing.Point(12, 48);
            this.OK.Name = "OK";
            this.OK.Size = new System.Drawing.Size(75, 23);
            this.OK.TabIndex = 2;
            this.OK.Text = "OK";
            this.OK.Click += new System.EventHandler(this.OK_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureBox2.Location = new System.Drawing.Point(148, 12);
            this.pictureBox2.MinimumSize = new System.Drawing.Size(320, 240);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(320, 280);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 140);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "0.00 C";
            // 
            // dis
            // 
            this.dis.Location = new System.Drawing.Point(12, 98);
            this.dis.Name = "dis";
            this.dis.Size = new System.Drawing.Size(75, 23);
            this.dis.TabIndex = 4;
            this.dis.Text = "Dis";
            this.dis.UseVisualStyleBackColor = true;
            this.dis.Click += new System.EventHandler(this.dis_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 217);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 243);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = "W";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 275);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(18, 17);
            this.label4.TabIndex = 7;
            this.label4.Text = "H";
            // 
            // Max
            // 
            this.Max.AutoSize = true;
            this.Max.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Max.Location = new System.Drawing.Point(142, 295);
            this.Max.Name = "Max";
            this.Max.Size = new System.Drawing.Size(68, 32);
            this.Max.TabIndex = 8;
            this.Max.Text = "Max";
            this.Max.Click += new System.EventHandler(this.Max_Click);
            // 
            // Min
            // 
            this.Min.AutoSize = true;
            this.Min.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Min.Location = new System.Drawing.Point(350, 295);
            this.Min.Name = "Min";
            this.Min.Size = new System.Drawing.Size(61, 32);
            this.Min.TabIndex = 9;
            this.Min.Text = "Min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(6, 332);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 32);
            this.label5.TabIndex = 10;
            this.label5.Text = "Not Start";
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(474, 12);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Temp";
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(364, 280);
            this.chart1.TabIndex = 11;
            this.chart1.Text = "chart1";
            // 
            // FlirC3
            // 
            this.ClientSize = new System.Drawing.Size(841, 433);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Min);
            this.Controls.Add(this.Max);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dis);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.OK);
            this.MinimumSize = new System.Drawing.Size(720, 480);
            this.Name = "FlirC3";
            this.Text = "FlirC3";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.closing);
            this.Load += new System.EventHandler(this.FlirC3_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        //private System.Windows.Forms.Button OK;
        //static System.Windows.Forms.PictureBox PictureBox1;
        private System.Windows.Forms.Button OK;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button dis;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Max;
        private System.Windows.Forms.Label Min;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
    }
}

