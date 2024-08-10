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
    public partial class ConvertToGray : Form
    {
        public ConvertToGray()
        {
            InitializeComponent();
        }

        private void ConvertToGray_Load(object sender, EventArgs e)
        {

        }

        public Bitmap ConvertToGrayscale(Bitmap original)
        {
            Bitmap grayscale = new Bitmap(original.Width, original.Height);

            for (int y = 0; y < original.Height; y++)
            {
                for (int x = 0; x < original.Width; x++)
                {
                    Color pixel = original.GetPixel(x, y);
                    int grayValue = (pixel.R + pixel.G + pixel.B) / 3;
                    Color grayPixel = Color.FromArgb(grayValue, grayValue, grayValue);
                    grayscale.SetPixel(x, y, grayPixel);
                }
            }

            return grayscale;
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
            if (pictureBox1.Image != null)
            {
                // Görüntüyü griye dönüştürme işlemi
                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                Bitmap grayscaleImage = ConvertToGrayscale(originalImage);

                // Griye dönüştürülmüş resmi pictureBox2'ye yükleme
                pictureBox2.Image = grayscaleImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim seçin.");
            }

        }
    }
}
