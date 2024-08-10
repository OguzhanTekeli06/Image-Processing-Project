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
    public partial class SaltPepper : Form
    {
        private Bitmap originalImage;
        private Bitmap noisyImage;

        public SaltPepper()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            
        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = originalImage;
            }
        }
        private void SaltPepper_Load(object sender, EventArgs e)
        {

        }

        private void btnConvertToGrayscale_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                noisyImage = new Bitmap(originalImage);
                AddSaltAndPepperNoise(noisyImage, 0.05); // %5 gürültü
                pictureBox1.Image = noisyImage;
            }

        }

        private void AddSaltAndPepperNoise(Bitmap image, double noiseLevel)
        {
            Random random = new Random();
            int width = image.Width;
            int height = image.Height;

            int numPixels = (int)(width * height * noiseLevel);

            for (int i = 0; i < numPixels; i++)
            {
                int x = random.Next(width);
                int y = random.Next(height);

                // Tuz veya biber seçimi
                bool isSalt = random.NextDouble() < 0.5;

                Color newColor = isSalt ? Color.White : Color.Black;

                image.SetPixel(x, y, newColor);
            }
        }

        private void mean_Click(object sender, EventArgs e)
        {

            if (noisyImage != null)
            {
                Bitmap meanFiltered = ApplyMeanFilter(noisyImage);
                pictureBox2.Image = meanFiltered;
            }
        }
        private Bitmap ApplyMeanFilter(Bitmap image)
        {
            Bitmap output = new Bitmap(image.Width, image.Height);

            int[,] kernel = new int[3, 3];
            int kernelSize = 3;

            for (int y = 1; y < image.Height - 1; y++)
            {
                for (int x = 1; x < image.Width - 1; x++)
                {
                    int r = 0, g = 0, b = 0;

                    for (int ky = -1; ky <= 1; ky++)
                    {
                        for (int kx = -1; kx <= 1; kx++)
                        {
                            Color pixel = image.GetPixel(x + kx, y + ky);

                            r += pixel.R;
                            g += pixel.G;
                            b += pixel.B;
                        }
                    }

                    r /= kernelSize * kernelSize;
                    g /= kernelSize * kernelSize;
                    b /= kernelSize * kernelSize;

                    output.SetPixel(x, y, Color.FromArgb(r, g, b));
                }
            }

            return output;
        }

        // Median (medyan) filtresi
        private Bitmap ApplyMedianFilter(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;
            Bitmap result = new Bitmap(width, height);

            // 3x3 komşuluk için medyan filtreleme
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    // RGB için komşu pikselleri listele
                    var redValues = new int[9];
                    var greenValues = new int[9];
                    var blueValues = new int[9];

                    int index = 0;

                    for (int dy = -1; dy <= 1; dy++)
                    {
                        for (int dx = -1; dx <= 1; dx++)
                        {
                            Color pixel = image.GetPixel(x + dx, y + dy);
                            redValues[index] = pixel.R;
                            greenValues[index] = pixel.G;
                            blueValues[index] = pixel.B;
                            index++;
                        }
                    }

                    // Renk kanallarını sırala ve medyanı al
                    Array.Sort(redValues);
                    Array.Sort(greenValues);
                    Array.Sort(blueValues);

                    Color medianColor = Color.FromArgb(
                        redValues[4], // Medyan indeks
                        greenValues[4],
                        blueValues[4]
                    );

                    result.SetPixel(x, y, medianColor);
                }
            }

            // Kenarlar için yansıma uygulama veya bırakma gibi stratejiler kullanılabilir
            return result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (noisyImage != null)
            {
                Bitmap medianFiltered = ApplyMedianFilter(noisyImage);
                pictureBox3.Image = medianFiltered;
            }
        }
    }
}
