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
    public partial class Blurring : Form
    {
        public Blurring()
        {
            InitializeComponent();
        }

        private void Blurring_Load(object sender, EventArgs e)
        {

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

        private Bitmap BlurringMedian(Bitmap original)
        {
            // Görüntü boyutları
            int width = original.Width;
            int height = original.Height;

            // Yeni bir görüntü oluştur
            Bitmap resultImage = new Bitmap(width, height);

            // Konvolüsyon işlemi
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    // Piksel değerlerini toplamak için bir dizi oluştur
                    List<int> redValues = new List<int>();
                    List<int> greenValues = new List<int>();
                    List<int> blueValues = new List<int>();

                    // Pikselin etrafındaki 3x3'lük alanı tarayarak piksel değerlerini topla
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = original.GetPixel(x + j, y + i);
                            redValues.Add(pixel.R);
                            greenValues.Add(pixel.G);
                            blueValues.Add(pixel.B);
                        }
                    }

                    // Piksel değerlerini sırala
                    redValues.Sort();
                    greenValues.Sort();
                    blueValues.Sort();

                    // Orta piksel değerlerini al
                    int medianRed = redValues[4];
                    int medianGreen = greenValues[4];
                    int medianBlue = blueValues[4];

                    // Yeni pikseli sonuç görüntüsüne ekle
                    Color newPixel = Color.FromArgb(medianRed, medianGreen, medianBlue);
                    resultImage.SetPixel(x, y, newPixel);
                }
            }

            return resultImage;
        }




        private Bitmap BlurringMean(Bitmap original)
        {
            // Görüntü boyutları
            int width = original.Width;
            int height = original.Height;

            // Yeni bir görüntü oluştur
            Bitmap resultImage = new Bitmap(width, height);

            // Konvolüsyon işlemi
            for (int y = 1; y < height - 1; y++)
            {
                for (int x = 1; x < width - 1; x++)
                {
                    // Piksel değerlerini toplamak için bir dizi oluştur
                    int totalRed = 0;
                    int totalGreen = 0;
                    int totalBlue = 0;

                    // Pikselin etrafındaki 3x3'lük alanı tarayarak piksel değerlerini topla
                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            Color pixel = original.GetPixel(x + j, y + i);
                            totalRed += pixel.R;
                            totalGreen += pixel.G;
                            totalBlue += pixel.B;
                        }
                    }

                    // Ortalama piksel değerlerini al
                    int meanRed = totalRed / 9;
                    int meanGreen = totalGreen / 9;
                    int meanBlue = totalBlue / 9;

                    // Yeni pikseli sonuç görüntüsüne ekle
                    Color newPixel = Color.FromArgb(meanRed, meanGreen, meanBlue);
                    resultImage.SetPixel(x, y, newPixel);
                }
            }

            return resultImage;
        }

        private void btnBlurring_Click(object sender, EventArgs e)
        {
            if (radioButtonMean.Checked)
            {
                // Mean blurring işlemi
                if (pictureBox1.Image != null)
                {
                    Bitmap originalImage = new Bitmap(pictureBox1.Image);
                    Bitmap processedImage = BlurringMean(originalImage);
                    pictureBox2.Image = processedImage;
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir resim seçin.");
                }
            }
            else if (radioButtonMedian.Checked)
            {
                // Median blurring işlemi
                if (pictureBox1.Image != null)
                {
                    Bitmap originalImage = new Bitmap(pictureBox1.Image);
                    Bitmap processedImage = BlurringMedian(originalImage);
                    pictureBox2.Image = processedImage;
                }
                else
                {
                    MessageBox.Show("Lütfen önce bir resim seçin.");
                }
            }
            else
            {
                MessageBox.Show("Lütfen bir blurring işlemi seçin.");
            }
        }

    }
}
