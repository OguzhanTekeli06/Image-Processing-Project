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
    public partial class zoom1 : Form
    {
        public zoom1()
        {
            InitializeComponent();
            pictureBox1.MouseWheel += PictureBox1_MouseWheel;
        }

        private void PictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
           if (e.Delta>0 )
            {
                pictureBox1.Width += 50;
                pictureBox1.Height += 50;

            }
           else
            {
                pictureBox1.Width -= 50;
                pictureBox1.Height -= 50;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files(*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Seçilen resmi pictureBox1'e yükleme
                pictureBox1.Image = new Bitmap(openFileDialog.FileName);
            }
        }
    }
}
