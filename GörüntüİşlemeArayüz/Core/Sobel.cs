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
    public partial class Sobel : Form
    {
        public Sobel()
        {
            InitializeComponent();
        }

        private void Sobel_Load(object sender, EventArgs e)
        {

        }


        public static Bitmap grayBitmap;
        public static Bitmap output;

        private  Bitmap ConvertToGray(Bitmap input)
        {
            Bitmap bt = (Bitmap)input.Clone();
            for (int y = 0; y < bt.Height; y++)
            {
                for (int x = 0; x < bt.Width; x++)
                {
                    Color c = bt.GetPixel(x, y);

                    var avg = getColorAvgValue(c);
                    bt.SetPixel(x, y, Color.FromArgb(avg, avg, avg));
                }
            }
            return bt;
        }
        private  int getColorAvgValue(Color c)
        {
            int r = c.R;
            int g = c.G;
            int b = c.B;
            int result = (r + g + b) / 3;
            //aslında bu grileştirme işlemini insan gözü için yapsaydık R .3, G .59, B  .11 oranları daha anlamlı olabilirdi; tercihen istenilen yöntem kullanılabilir
            // result = (int) (0.3 * r + 0.59 * g + 0.11 * b);

            result = result >= 255 ? 255 : result <= 0 ? 0 : result;

            return result;
        }

        public Bitmap ApplySobel(Bitmap image)
        {
            grayBitmap = image;

            Bitmap b = grayBitmap;
            Bitmap output = (Bitmap)grayBitmap.Clone();

            int width = b.Width;
            int height = b.Height;
            int[,] gx = new int[,] { { -1, 0, 1 }, { -2, 0, 2 }, { -1, 0, 1 } };
            int[,] gy = new int[,] { { -1, -2, -1 }, { 0, 0, 0 }, { 1, 2, 1 } };
            int[,] pixelArray = new int[width, height];

            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    pixelArray[i, j] = getColorAvgValue(b.GetPixel(i, j));
                }
            }
            for (int i = 1; i < width - 1; i++)
            {
                for (int j = 1; j < height - 1; j++)
                {

                    int resultPixel = 0;
                    int pixelValue;
                    int totalGx = 0;
                    int totalGy = 0;
                    for (int wi = -1; wi <= 1; wi++)
                    {
                        for (int hw = -1; hw <= 1; hw++)
                        {

                            pixelValue = pixelArray[i + wi, j + hw];
                            totalGx += gx[wi + 1, hw + 1] * pixelValue;
                            totalGy += gy[wi + 1, hw + 1] * pixelValue;

                        }
                    }
                    resultPixel = Convert.ToInt32(Math.Sqrt(totalGx * totalGx + totalGy * totalGy));
                    resultPixel = resultPixel > 255 ? 255 : resultPixel;

                    output.SetPixel(i, j, Color.FromArgb(resultPixel, resultPixel, resultPixel));

                }
            }
            return output;
        }

        public  Bitmap DetectEdge(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            Bitmap resultImage = new Bitmap(width, height);

            for (int i = 1; i < height - 1; i++)
            {
                for (int j = 1; j < width - 1; j++)
                {
                    // Sobel mask for x direction
                    int Gx = ((2 * image.GetPixel(j + 1, i - 1).R + image.GetPixel(j + 1, i).R + image.GetPixel(j + 1, i + 1).R) -
                              (2 * image.GetPixel(j - 1, i - 1).R + image.GetPixel(j - 1, i).R + image.GetPixel(j - 1, i + 1).R));

                    // Sobel mask for y direction
                    int Gy = ((2 * image.GetPixel(j - 1, i + 1).R + image.GetPixel(j, i + 1).R + image.GetPixel(j + 1, i + 1).R) -
                              (2 * image.GetPixel(j - 1, i - 1).R + image.GetPixel(j, i - 1).R + image.GetPixel(j + 1, i - 1).R));

                    // The gradient of the image
                    int gradient = (int)Math.Sqrt(Gx * Gx + Gy * Gy);

                    // Ensure the gradient is within [0, 255]
                    gradient = Math.Max(0, Math.Min(gradient, 255));

                    // Set the pixel value in the result image
                    resultImage.SetPixel(j, i, Color.FromArgb(gradient, gradient, gradient));
                }
            }

            return resultImage;
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
            pictureBox2.Image = DetectEdge(new Bitmap(pictureBox1.Image));
        }
    }
}
