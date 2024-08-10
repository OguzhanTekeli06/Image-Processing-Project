namespace GörüntüİşlemeArayüz
{
    partial class Blurring
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.btnConvertToGrayscale = new System.Windows.Forms.Button();
            this.radioButtonMedian = new System.Windows.Forms.RadioButton();
            this.radioButtonMean = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(583, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Çıktı Görüntüsü";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(59, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 23);
            this.label1.TabIndex = 12;
            this.label1.Text = "Girdi Görüntüsü";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(511, 76);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(285, 327);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(5, 76);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(287, 337);
            this.pictureBox1.TabIndex = 10;
            this.pictureBox1.TabStop = false;
            // 
            // btnOpen
            // 
            this.btnOpen.BackColor = System.Drawing.Color.Ivory;
            this.btnOpen.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnOpen.Location = new System.Drawing.Point(323, 133);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(144, 29);
            this.btnOpen.TabIndex = 8;
            this.btnOpen.Text = "Görüntü Ekle";
            this.btnOpen.UseVisualStyleBackColor = false;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // btnConvertToGrayscale
            // 
            this.btnConvertToGrayscale.BackColor = System.Drawing.Color.Ivory;
            this.btnConvertToGrayscale.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnConvertToGrayscale.Location = new System.Drawing.Point(314, 168);
            this.btnConvertToGrayscale.Name = "btnConvertToGrayscale";
            this.btnConvertToGrayscale.Size = new System.Drawing.Size(166, 44);
            this.btnConvertToGrayscale.TabIndex = 7;
            this.btnConvertToGrayscale.Text = "Blurring";
            this.btnConvertToGrayscale.UseVisualStyleBackColor = false;
            this.btnConvertToGrayscale.Click += new System.EventHandler(this.btnBlurring_Click);
            // 
            // radioButtonMedian
            // 
            this.radioButtonMedian.AutoSize = true;
            this.radioButtonMedian.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonMedian.Location = new System.Drawing.Point(359, 311);
            this.radioButtonMedian.Name = "radioButtonMedian";
            this.radioButtonMedian.Size = new System.Drawing.Size(79, 20);
            this.radioButtonMedian.TabIndex = 14;
            this.radioButtonMedian.TabStop = true;
            this.radioButtonMedian.Text = "Median";
            this.radioButtonMedian.UseVisualStyleBackColor = true;
            // 
            // radioButtonMean
            // 
            this.radioButtonMean.AutoSize = true;
            this.radioButtonMean.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.radioButtonMean.Location = new System.Drawing.Point(359, 275);
            this.radioButtonMean.Name = "radioButtonMean";
            this.radioButtonMean.Size = new System.Drawing.Size(66, 20);
            this.radioButtonMean.TabIndex = 13;
            this.radioButtonMean.TabStop = true;
            this.radioButtonMean.Text = "Mean";
            this.radioButtonMean.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label3.Location = new System.Drawing.Point(337, 238);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(138, 23);
            this.label3.TabIndex = 15;
            this.label3.Text = "Filtre Seçiniz  :";
            // 
            // Blurring
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(839, 526);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.radioButtonMedian);
            this.Controls.Add(this.radioButtonMean);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.btnConvertToGrayscale);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Blurring";
            this.ShowInTaskbar = false;
            this.Text = "Blurring";
            this.Load += new System.EventHandler(this.Blurring_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Button btnConvertToGrayscale;
        private System.Windows.Forms.RadioButton radioButtonMedian;
        private System.Windows.Forms.RadioButton radioButtonMean;
        private System.Windows.Forms.Label label3;
    }
}