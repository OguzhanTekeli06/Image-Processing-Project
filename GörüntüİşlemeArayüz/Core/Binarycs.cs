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
    public partial class Binarycs : Form
    {
        public Binarycs()
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

        private void btnConvertToBinary_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                // PictureBox1'deki resmi Bitmap olarak al
                Bitmap originalBitmap = new Bitmap(pictureBox1.Image);

                // Resmi binary formata dönüştürme
                Bitmap binaryBitmap = ConvertToBinary(originalBitmap);

                // Yeni resmi pictureBox2'ye yükleme
                pictureBox2.Image = binaryBitmap;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin.");
            }
        }

        private Bitmap ConvertToBinary(Bitmap originalBitmap)
        {
            int width = originalBitmap.Width;
            int height = originalBitmap.Height;
            Bitmap binaryBitmap = new Bitmap(width, height);
            int threshold = 128; // Eşik değeri

            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    // Orijinal piksel rengini al
                    Color originalColor = originalBitmap.GetPixel(x, y);

                    // Gri tonlama hesapla (ortalama yöntemi)
                    int grayValue = (originalColor.R + originalColor.G + originalColor.B) / 3;

                    // Eşik değerine göre siyah veya beyaza dönüştür
                    Color binaryColor = grayValue < threshold ? Color.Black : Color.White;

                    // Yeni renkteki pikseli ata
                    binaryBitmap.SetPixel(x, y, binaryColor);
                }
            }

            return binaryBitmap;
        }
    }
}
