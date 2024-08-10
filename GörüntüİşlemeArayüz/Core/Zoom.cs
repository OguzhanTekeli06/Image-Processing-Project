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

    public partial class Zoom : Form
    {

        private float zoomFactor = 1.0f;
        private const float zoomStep = 1.2f; // Yakınlaştırma adımı
        private Point zoomCenter;
        private bool isZoomed = false;
        private Bitmap originalBitmap;

        public Zoom()
        {
            InitializeComponent();
            pictureBox1.MouseClick += pictureBox1_MouseClick;
            pictureBox1.Paint += pictureBox1_Paint;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage; // Resmin boyutlandırılması için gerekli
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi yükleme
                originalBitmap = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = originalBitmap;
                zoomFactor = 1.0f;
                isZoomed = false;
                zoomCenter = new Point(pictureBox1.Width / 2, pictureBox1.Height / 2); // Varsayılan merkez
                pictureBox1.Invalidate(); // Yeniden çizmek için PictureBox'ı geçersiz kıl
            }
        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {
            if (originalBitmap == null)
                return;

            if (isZoomed)
            {
                // Uzaklaştırma
                zoomFactor = 1.0f;
                isZoomed = false;
            }
            else
            {
                // Yakınlaştırma
                zoomCenter = e.Location;
                zoomFactor *= zoomStep;
                isZoomed = true;
            }

            // Hata ayıklama için çıktı
            Console.WriteLine($"Zoom Factor: {zoomFactor}, Zoom Center: {zoomCenter}");

            pictureBox1.Invalidate(); // Yeniden çizmek için PictureBox'ı geçersiz kıl
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (originalBitmap == null)
                return;

            Graphics g = e.Graphics;
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;

            if (isZoomed)
            {
                int newWidth = (int)(originalBitmap.Width * zoomFactor);
                int newHeight = (int)(originalBitmap.Height * zoomFactor);

                int zoomedX = (int)(zoomCenter.X * zoomFactor - pictureBox1.Width / 2);
                int zoomedY = (int)(zoomCenter.Y * zoomFactor - pictureBox1.Height / 2);

                // Kırpma sınırlarını kontrol et
                if (zoomedX < 0) zoomedX = 0;
                if (zoomedY < 0) zoomedY = 0;
                if (zoomedX + pictureBox1.Width > newWidth) zoomedX = newWidth - pictureBox1.Width;
                if (zoomedY + pictureBox1.Height > newHeight) zoomedY = newHeight - pictureBox1.Height;

                Rectangle srcRect = new Rectangle(zoomedX, zoomedY, pictureBox1.Width, pictureBox1.Height);
                Rectangle destRect = new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height);

                // Hata ayıklama için çıktı
                Console.WriteLine($"Source Rect: {srcRect}, Destination Rect: {destRect}");

                g.DrawImage(originalBitmap, destRect, srcRect, GraphicsUnit.Pixel);
            }
            else
            {
                g.DrawImage(originalBitmap, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            }
        }
    }
}
