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
    public partial class Gauss : Form
    {
        public Gauss()
        {
            InitializeComponent();
        }

        private void Gauss_Load(object sender, EventArgs e)
        {
            InitializeDataGridView();


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

        private Bitmap ApplyGaussianBlur(Bitmap original)
        {
            double[,] kernel = {
        { 1, 2, 1 },
        { 2, 4, 2 },
        { 1, 2, 1 }
    };

            // Kernel boyutu
            int kernelSize = 3;
            int kernelRadius = kernelSize / 2;

            // Görüntü boyutları
            int width = original.Width;
            int height = original.Height;

            // Yeni bir görüntü oluştur
            Bitmap resultImage = new Bitmap(width, height);

            // Konvolüsyon işlemi
            for (int y = kernelRadius; y < height - kernelRadius; y++)
            {
                for (int x = kernelRadius; x < width - kernelRadius; x++)
                {
                    double sumR = 0, sumG = 0, sumB = 0;

                    // Kernel üzerinde dolaşarak konvolüsyon işlemini uygula
                    for (int i = -kernelRadius; i <= kernelRadius; i++)
                    {
                        for (int j = -kernelRadius; j <= kernelRadius; j++)
                        {
                            Color pixel = original.GetPixel(x + j, y + i);
                            double valueR = pixel.R;
                            double valueG = pixel.G;
                            double valueB = pixel.B;
                            sumR += kernel[i + kernelRadius, j + kernelRadius] * valueR;
                            sumG += kernel[i + kernelRadius, j + kernelRadius] * valueG;
                            sumB += kernel[i + kernelRadius, j + kernelRadius] * valueB;
                        }
                    }

                    // Sonuç piksel değerlerini sınırla
                    int newValueR = Math.Min(Math.Max((int)(sumR / 16), 0), 255);
                    int newValueG = Math.Min(Math.Max((int)(sumG / 16), 0), 255);
                    int newValueB = Math.Min(Math.Max((int)(sumB / 16), 0), 255);

                    // Yeni pikseli sonuç görüntüsüne ekle
                    Color newPixel = Color.FromArgb(newValueR, newValueG, newValueB);
                    resultImage.SetPixel(x, y, newPixel);
                }
            }

            return resultImage;

        }

        private void btnApplyGaussianBlur_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // İşlenmiş görüntüyü al
                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                Bitmap processedImage = ApplyGaussianBlur(originalImage);

                // İşlenmiş görüntüyü PictureBox2'ye yükle
                pictureBox2.Image = processedImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }















        private void btnApplyCustomFilter_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // Çekirdek matrisini oluştur
                double[,] kernel = ReadKernelFromDataGridView();

                // İşlenmiş görüntüyü al
                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                Bitmap processedImage = ApplyCustomFilter(originalImage, kernel);

                // İşlenmiş görüntüyü PictureBox2'ye yükle
                pictureBox2.Image = processedImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }
        }

        private double[,] ReadKernelFromDataGridView()
        {
            // DataGridView'deki verileri okuyarak çekirdek matrisi oluştur
            const int size = 3; // 3x3'lük matris boyutu
            double[,] kernel = new double[size, size];

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (dataGridView1.Rows[i].Cells[j].Value != null)
                    {
                        double value;
                        if (double.TryParse(dataGridView1.Rows[i].Cells[j].Value.ToString(), out value))
                        {
                            kernel[i, j] = value;
                        }
                        else
                        {
                            MessageBox.Show("Geçersiz değer: " + dataGridView1.Rows[i].Cells[j].Value.ToString());
                            return null;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Değer girilmemiş.");
                        return null;
                    }
                }
            }
            return kernel;
        }

        private void InitializeDataGridView()
        {
            // DataGridView için 3x3'lük bir matris oluştur
            const int size = 3; // 3x3'lük matris boyutu
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            for (int i = 0; i < size; i++)
            {
                dataGridView1.Columns.Add("Column" + i, "Column" + i);
            }
            for (int i = 0; i < size; i++)
            {
                dataGridView1.Rows.Add();
            }

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private Bitmap ApplyCustomFilter(Bitmap original, double[,] kernel)
        {
            // Görüntü boyutları
            int width = original.Width;
            int height = original.Height;

            // Yeni bir görüntü oluştur
            Bitmap resultImage = new Bitmap(width, height);

            // Kernel boyutu
            int kernelSize = kernel.GetLength(0);
            int kernelRadius = kernelSize / 2;

            // Konvolüsyon işlemi
            for (int y = kernelRadius; y < height - kernelRadius; y++)
            {
                for (int x = kernelRadius; x < width - kernelRadius; x++)
                {
                    double sumR = 0, sumG = 0, sumB = 0;

                    // Kernel üzerinde dolaşarak konvolüsyon işlemini uygula
                    for (int i = -kernelRadius; i <= kernelRadius; i++)
                    {
                        for (int j = -kernelRadius; j <= kernelRadius; j++)
                        {
                            Color pixel = original.GetPixel(x + j, y + i);
                            double valueR = pixel.R;
                            double valueG = pixel.G;
                            double valueB = pixel.B;
                            sumR += kernel[i + kernelRadius, j + kernelRadius] * valueR;
                            sumG += kernel[i + kernelRadius, j + kernelRadius] * valueG;
                            sumB += kernel[i + kernelRadius, j + kernelRadius] * valueB;
                        }
                    }

                    // Sonuç piksel değerlerini sınırla
                    int newValueR = Math.Min(Math.Max((int)(sumR), 0), 255);
                    int newValueG = Math.Min(Math.Max((int)(sumG), 0), 255);
                    int newValueB = Math.Min(Math.Max((int)(sumB), 0), 255);

                    // Yeni pikseli sonuç görüntüsüne ekle
                    Color newPixel = Color.FromArgb(newValueR, newValueG, newValueB);
                    resultImage.SetPixel(x, y, newPixel);
                }
            }

            return resultImage;
        }

    }
}
