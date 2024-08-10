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
    public partial class İmageRotate : Form
    {
        private Bitmap originalBitmap;

        public İmageRotate()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;


        }

        private void İmageRotate_Load(object sender, EventArgs e)
        {

        }


        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalBitmap = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = originalBitmap;
            }
        }

        private Bitmap ManualRotateImage(Bitmap sourceBitmap, float angle)
        {
            int sourceWidth = sourceBitmap.Width;
            int sourceHeight = sourceBitmap.Height;

            double radians = angle * (Math.PI / 180); // Dereceyi radyana dönüştür
            double cos = Math.Abs(Math.Cos(radians));
            double sin = Math.Abs(Math.Sin(radians));

            int newWidth = (int)(sourceWidth * cos + sourceHeight * sin);
            int newHeight = (int)(sourceWidth * sin + sourceHeight * cos);

            Bitmap rotatedBitmap = new Bitmap(newWidth, newHeight);

            int centerX = sourceWidth / 2;
            int centerY = sourceHeight / 2;
            int newCenterX = newWidth / 2;
            int newCenterY = newHeight / 2;

            // Tüm piksel konumlarını yeni bitmap'e hesaplayarak yerleştir
            for (int x = 0; x < sourceWidth; x++)
            {
                for (int y = 0; y < sourceHeight; y++)
                {
                    int newX = (int)((x - centerX) * Math.Cos(radians) - (y - centerY) * Math.Sin(radians)) + newCenterX;
                    int newY = (int)((x - centerX) * Math.Sin(radians) + (y - centerY) * Math.Cos(radians)) + newCenterY;

                    if (newX >= 0 && newX < newWidth && newY >= 0 && newY < newHeight)
                    {
                        rotatedBitmap.SetPixel(newX, newY, sourceBitmap.GetPixel(x, y));
                    }
                }
            }

            return rotatedBitmap;
        }

        private void btnRotate_Click(object sender, EventArgs e)
        {
            if (originalBitmap == null)
            {
                MessageBox.Show("Önce bir resim seçin.");
                return;
            }

            float angle;
            if (float.TryParse(txtAngle.Text, out angle))
            {
                Bitmap rotatedBitmap = ManualRotateImage(originalBitmap, angle);
                pictureBox2.Image = rotatedBitmap;
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir açı girin.");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
