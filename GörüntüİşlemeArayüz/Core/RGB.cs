using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GörüntüİşlemeArayüz
{
    public partial class RGB : Form
    {
        public RGB()
        {
            InitializeComponent();
        }

        private void RGB_Load(object sender, EventArgs e)
        {

        }


        public  Bitmap AdjustImage(Bitmap originalImage, int redAdjustment, int greenAdjustment, int blueAdjustment)
        {
            Bitmap adjustedImage = new Bitmap(originalImage.Width, originalImage.Height);

            for (int x = 0; x < originalImage.Width; x++)
            {
                for (int y = 0; y < originalImage.Height; y++)
                {
                    Color originalPixel = originalImage.GetPixel(x, y);

                    int newR = Clamp(originalPixel.R + redAdjustment, 0, 255);
                    int newG = Clamp(originalPixel.G + greenAdjustment, 0, 255);
                    int newB = Clamp(originalPixel.B + blueAdjustment, 0, 255);

                    Color adjustedPixel = Color.FromArgb(newR, newG, newB);

                    adjustedImage.SetPixel(x, y, adjustedPixel);
                }
            }

            return adjustedImage;
        }

        public  int Clamp(int value, int min, int max)
        {
            return Math.Max(min, Math.Min(max, value));
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi pictureBox1'e yükleme
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }

        private void btnConvertToGrayscale_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = AdjustImage(new Bitmap(pictureBox1.Image), trackBar1.Value , trackBar2.Value , trackBar3.Value);
        }
    }
}
