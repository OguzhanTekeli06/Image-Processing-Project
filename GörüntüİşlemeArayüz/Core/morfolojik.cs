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
    public partial class morfolojik : Form
    {
        private Bitmap originalImage;
        private Bitmap genısleyen;
        public morfolojik()
        {
            InitializeComponent();
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox3.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox4.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox5.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                originalImage = new Bitmap(openFileDialog.FileName);
                pictureBox1.Image = originalImage;
            }
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                Bitmap erodedImage = Erosion(originalImage);
                pictureBox2.Image = erodedImage;
            }
            else
            {
                MessageBox.Show("Please load an image first.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                Bitmap dilatedImage = Dilation(originalImage);
                pictureBox3.Image = dilatedImage;
            }
            else
            {
                MessageBox.Show("Please load an image first.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (originalImage != null)
            {
                Bitmap openden = Opening(originalImage);
                pictureBox4.Image = openden;
            }
            else
            {
                MessageBox.Show("Please load an image first.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (originalImage != null)
            {
                Bitmap closed = Cloasing(originalImage);
                pictureBox5.Image = closed;
            }
            else
            {
                MessageBox.Show("Please load an image first.");
            }
        }


        private Bitmap Erosion(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color minColor = Color.White;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int newX = x + j;
                            int newY = y + j;

                            if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                            {
                                Color currentcolor = image.GetPixel(newX, newY);
                                if (currentcolor.R < minColor.R)
                                    minColor = currentcolor;
                            }
                        }
                    }
                    result.SetPixel(x, y, minColor);
                }
            }
            return result;
        }

        private Bitmap Dilation(Bitmap image)
        {
            Bitmap result = new Bitmap(image.Width, image.Height);
            for (int x = 0; x < image.Width; x++)
            {
                for (int y = 0; y < image.Height; y++)
                {
                    Color maxColor = Color.Black;

                    for (int i = -1; i <= 1; i++)
                    {
                        for (int j = -1; j <= 1; j++)
                        {
                            int newX = x + j;
                            int newY = y + j;

                            if (newX >= 0 && newX < image.Width && newY >= 0 && newY < image.Height)
                            {
                                Color currentcolor = image.GetPixel(newX, newY);
                                if (currentcolor.R > maxColor.R)
                                    maxColor = currentcolor;
                            }
                        }
                    }
                    result.SetPixel(x, y, maxColor);
                }
            }
            return result;
        }

        private Bitmap Opening(Bitmap image)
        {
            Bitmap erozyonaugrayan = Dilation(image);
            Bitmap acılmıs = Erosion(erozyonaugrayan);
            return acılmıs;
        }
        private Bitmap Cloasing(Bitmap image)
        {
            Bitmap genısletılmıs = Erosion(image);
            Bitmap kapanmıs = Dilation(genısletılmıs);
            return kapanmıs;
        }
    }
}
