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
    public partial class CropImage : Form
    {



        private bool isDragging = false;
        private Point startPoint;
        private Rectangle selection;
        public CropImage()
        {
            InitializeComponent();
        }

        private void CropImage_Load(object sender, EventArgs e)
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


        private void PictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            isDragging = true;
            startPoint = e.Location;
            pictureBox1.Invalidate();
        }

        private void PictureBox_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                selection = new Rectangle(
                    Math.Min(startPoint.X, e.X),
                    Math.Min(startPoint.Y, e.Y),
                    Math.Abs(startPoint.X - e.X),
                    Math.Abs(startPoint.Y - e.Y));
                pictureBox1.Invalidate();
            }
        }

        private void PictureBox_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;

        }

        private void BtnCrop_Click(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null && selection.Width > 0 && selection.Height > 0)
            {
                Bitmap originalImage = new Bitmap(pictureBox1.Image);
                Bitmap croppedImage = CropImages(originalImage, selection);
                pictureBox2.Image = croppedImage;
            }
            else
            {
                MessageBox.Show("Lütfen önce bir resim yükleyin ve bir alan seçin.");
            }
        }
        private Bitmap CropImages(Bitmap original, Rectangle cropArea)
        {
            Bitmap croppedImage = new Bitmap(cropArea.Width, cropArea.Height);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(original, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height), cropArea, GraphicsUnit.Pixel);
            }
            return croppedImage;
        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (isDragging && selection.Width > 0 && selection.Height > 0)
            {
                using (Pen pen = new Pen(Color.Red, 2))
                {
                    e.Graphics.DrawRectangle(pen, selection);
                }
            }
        }
    }
}
