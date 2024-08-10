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
    public partial class Adaptif : Form
    {
        public Adaptif()
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

        private Bitmap ApplyOtsuThreshold(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Bitmap grayBitmap = new Bitmap(width, height);

            // Convert to grayscale
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    int gray = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.11);
                    grayBitmap.SetPixel(x, y, Color.FromArgb(gray, gray, gray));
                }
            }

            // Compute histogram
            int[] histogram = new int[256];
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int gray = grayBitmap.GetPixel(x, y).R;
                    histogram[gray]++;
                }
            }

            // Compute Otsu threshold
            int total = width * height;
            float sum = 0;
            for (int i = 0; i < 256; i++)
            {
                sum += i * histogram[i];
            }

            float sumB = 0;
            int wB = 0;
            int wF = 0;
            float varMax = 0;
            int threshold = 0;

            for (int t = 0; t < 256; t++)
            {
                wB += histogram[t];
                if (wB == 0)
                    continue;
                wF = total - wB;
                if (wF == 0)
                    break;

                sumB += (float)(t * histogram[t]);

                float mB = sumB / wB;
                float mF = (sum - sumB) / wF;

                float varBetween = (float)wB * (float)wF * (mB - mF) * (mB - mF);

                if (varBetween > varMax)
                {
                    varMax = varBetween;
                    threshold = t;
                }
            }

            // Apply threshold
            Bitmap result = new Bitmap(width, height);
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int gray = grayBitmap.GetPixel(x, y).R;
                    if (gray >= threshold)
                    {
                        result.SetPixel(x, y, Color.White);
                    }
                    else
                    {
                        result.SetPixel(x, y, Color.Black);
                    }
                }
            }

            return result;
        }

        private Bitmap ApplyMeanFilter(Bitmap bitmap)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Bitmap result = new Bitmap(width, height);
            int filterSize = 3;
            int filterOffset = filterSize / 2;

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    int rSum = 0, gSum = 0, bSum = 0;
                    int count = 0;

                    for (int fy = -filterOffset; fy <= filterOffset; fy++)
                    {
                        for (int fx = -filterOffset; fx <= filterOffset; fx++)
                        {
                            int imgX = Math.Min(width - 1, Math.Max(0, x + fx));
                            int imgY = Math.Min(height - 1, Math.Max(0, y + fy));

                            Color pixelColor = bitmap.GetPixel(imgX, imgY);

                            rSum += pixelColor.R;
                            gSum += pixelColor.G;
                            bSum += pixelColor.B;
                            count++;
                        }
                    }

                    int rMean = rSum / count;
                    int gMean = gSum / count;
                    int bMean = bSum / count;

                    result.SetPixel(x, y, Color.FromArgb(rMean, gMean, bMean));
                }
            }

            return result;
        }
        private void btnConvertToGrayscale_Click(object sender, EventArgs e)
        {

            Bitmap bitmap = new Bitmap(pictureBox1.Image);
            Bitmap meanFilteredBitmap = ApplyMeanFilter(bitmap);
            Bitmap resultBitmap = ApplyOtsuThreshold(meanFilteredBitmap);
            pictureBox2.Image = resultBitmap;
        }

        private void Adaptif_Load(object sender, EventArgs e)
        {

        }
    }
}
