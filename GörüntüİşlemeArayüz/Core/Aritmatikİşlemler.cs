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
    public partial class Aritmatikİşlemler : Form
    {
        public Aritmatikİşlemler()
        {
            InitializeComponent();
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

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi pictureBox1'e yükleme
                pictureBox2.Image = new Bitmap(openFileDialog.FileName);
            }
        }


        public Bitmap SumImages(Bitmap image1, Bitmap image2)
        {
            if (image1 == null || image2 == null)
            {
                MessageBox.Show("Please load both images first.");
                return null;
            }

            // Resize images to ensure they have the same dimensions
            ResizeImages(ref image1, ref image2);

            Bitmap resultImage = new Bitmap(image1.Width, image1.Height);

            for (int i = 0; i < image1.Width; i++)
            {
                for (int j = 0; j < image1.Height; j++)
                {
                    Color pixel1 = image1.GetPixel(i, j);
                    Color pixel2 = image2.GetPixel(i, j);

                    // Perform addition operation on each pixel
                    int red = Math.Min(pixel1.R + pixel2.R, 255);
                    int green = Math.Min(pixel1.G + pixel2.G, 255);
                    int blue = Math.Min(pixel1.B + pixel2.B, 255);

                    resultImage.SetPixel(i, j, Color.FromArgb(red, green, blue));
                }
            }

            return resultImage;
        }


        public Bitmap MultiplyImages(Bitmap image1, Bitmap image2)
        {
            if (image1 == null || image2 == null)
            {
                MessageBox.Show("Please load both images first.");
                return null;
            }

            int width = Math.Min(image1.Width, image2.Width);
            int height = Math.Min(image1.Height, image2.Height);

            Bitmap result = new Bitmap(width, height);

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color color1 = image1.GetPixel(x, y);
                    Color color2 = image2.GetPixel(x, y);

                    int r = (color1.R * color2.R) / 255;
                    int g = (color1.G * color2.G) / 255;
                    int b = (color1.B * color2.B) / 255;

                    result.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return result;
        }

        private void ResizeImages(ref Bitmap image1, ref Bitmap image2)
        {
            if (image1.Size != image2.Size)
            {
                int minWidth = Math.Min(image1.Width, image2.Width);
                int minHeight = Math.Min(image1.Height, image2.Height);

                image1 = new Bitmap(image1, minWidth, minHeight);
                image2 = new Bitmap(image2, minWidth, minHeight);
            }
        }

        private void btnConvertToGrayscale_Click(object sender, EventArgs e)
        {
            pictureBox3.Image =SumImages(new Bitmap(pictureBox1.Image),new Bitmap(pictureBox2.Image));
        }

        private void mean_Click(object sender, EventArgs e)
        {
            pictureBox3.Image = MultiplyImages(new Bitmap(pictureBox1.Image), new Bitmap(pictureBox2.Image));

        }
    }
}
