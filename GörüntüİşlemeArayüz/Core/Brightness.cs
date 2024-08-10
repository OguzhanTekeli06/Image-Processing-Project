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
    public partial class Brightness : Form
    {

        private Bitmap originalBitmap; // Orijinal görüntü
        private Bitmap currentBitmap; // Mevcut görüntü (üzerinde çalıştığımız)
        public Brightness()
        {


            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void Brightness_Load(object sender, EventArgs e)
        {

        }

        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalBitmap = new Bitmap(openFileDialog.FileName);
                currentBitmap = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = currentBitmap;
            }
        }
        private Bitmap AdjustBrightness(Bitmap bitmap, float adjustment)
        {
            Bitmap adjustedBitmap = new Bitmap(bitmap.Width, bitmap.Height);

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color originalColor = bitmap.GetPixel(x, y);

                    // Her bir renk bileşeni için parlaklık ayarlaması
                    int r = Clamp((int)(originalColor.R + adjustment), 0, 255);
                    int g = Clamp((int)(originalColor.G + adjustment), 0, 255);
                    int b = Clamp((int)(originalColor.B + adjustment), 0, 255);

                    Color adjustedColor = Color.FromArgb(r, g, b);
                    adjustedBitmap.SetPixel(x, y, adjustedColor);
                }
            }

            return adjustedBitmap;
        }

        private int Clamp(int value, int min, int max)
        {
            // Değeri minimum ve maksimum arasında tutar
            return Math.Max(min, Math.Min(max, value));
        }

        private void düsür_Click(object sender, EventArgs e)
        {
            if (currentBitmap == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü seçin.");
                return;
            }

            currentBitmap = AdjustBrightness(currentBitmap, 20); // Parlaklığı artır
            pictureBox1.Image = currentBitmap; // PictureBox'ı güncelle
        }

        private void arttır_Click(object sender, EventArgs e)
        {
            if (currentBitmap == null)
            {
                MessageBox.Show("Lütfen önce bir görüntü seçin.");
                return;
            }

            currentBitmap = AdjustBrightness(currentBitmap, -20); // Parlaklığı azalt
            pictureBox1.Image = currentBitmap; // PictureBox'ı güncelle
        }
    }
}
