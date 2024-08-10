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
    public partial class Form1 : Form
    {
        bool sidebarExpand;
        bool homeExpand;
        bool teknikExpand;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


        }



        private void sidebartimer_Tick(object sender, EventArgs e)
        {
            if(sidebarExpand)
            {
                sidebar.Width -= 10;

                if(sidebar.Width == sidebar.MinimumSize.Width)
                {
                    sidebarExpand = false;
                    sidebartimer.Stop();
                }
            }
            else
            {
                sidebar.Width += 10;
                if(sidebar.Width == sidebar.MaximumSize.Width)
                {
                    sidebarExpand = true;
                    sidebartimer.Stop();
                }
            }

        }

        private void menubutton_Click(object sender, EventArgs e)
        {
            sidebartimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sidebar.AutoScroll = true;
           
        }

        private void temeltimer1_Tick(object sender, EventArgs e)
        {
            if(homeExpand)
            {
                temelteknikcontainer.Height += 10;
                if (temelteknikcontainer.Height == temelteknikcontainer.MaximumSize.Height)
                {
                    homeExpand= false;
                    temeltimer1.Stop();

                }

               
            }
            else
            {
                temelteknikcontainer.Height -= 10;
                if(temelteknikcontainer.Height == temelteknikcontainer.MinimumSize.Height)
                {
                    homeExpand = true;
                    temeltimer1.Stop();
                }
            } 
                
        }



        private void button1_Click_1(object sender, EventArgs e)
        {
            temeltimer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
                ConvertToGray converttogray = new ConvertToGray();

                converttogray.TopLevel = false;
                contentPanel.Controls.Clear(); // Mevcut içeriği temizleyin
                contentPanel.Controls.Add(converttogray);
                converttogray.Dock = DockStyle.Fill;
                converttogray.Show();
        
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            CropImage cropImage = new CropImage();
            cropImage.TopLevel = false;
            contentPanel.Controls.Clear(); // Mevcut içeriği temizleyin
            contentPanel.Controls.Add(cropImage);
            cropImage.Dock = DockStyle.Fill; 
            cropImage.Show();

        }

        private void button16_Click(object sender, EventArgs e)
        {
            Blurring blurring = new Blurring();
            blurring.TopLevel = false;  
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(blurring);
            blurring.Dock = DockStyle.Fill;
            blurring.Show();
        }

        private void button17_Click(object sender, EventArgs e)
        {
            Gauss gauss = new Gauss();
            gauss.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(gauss);
            gauss.Dock = DockStyle.Fill;
            gauss.Show();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            RGB rgb = new RGB();
            rgb.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(rgb);
            rgb.Dock = DockStyle.Fill;
            rgb.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            İmageRotate imagerotate =new İmageRotate();
            imagerotate.TopLevel = false;   
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(imagerotate);
            imagerotate.Dock = DockStyle.Fill;
            imagerotate.Show();

        }

        private void button9_Click(object sender, EventArgs e)
        {
            Brightness brightness = new Brightness();
            brightness.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(brightness);
            brightness.Dock = DockStyle.Fill;
            brightness.Show();
        }

        private void button18_Click(object sender, EventArgs e)
        {
            SaltPepper saltPepper = new SaltPepper();
            saltPepper.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(saltPepper);
            saltPepper.Dock= DockStyle.Fill;
            saltPepper.Show();

        }

        private void button19_Click(object sender, EventArgs e)
        {
            Sobel sobel = new Sobel();
            sobel.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(sobel);
            sobel.Dock = DockStyle.Fill;
            sobel.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Aritmatikİşlemler aritmatikişlem = new Aritmatikİşlemler();
            aritmatikişlem.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(aritmatikişlem);
            aritmatikişlem.Dock = DockStyle.Fill;
            aritmatikişlem.Show();

        }

        private void button20_Click(object sender, EventArgs e)
        {
            Histogram histogram = new Histogram();
            histogram.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(histogram);
            histogram.Dock = DockStyle.Fill;
            histogram.Show();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            Binarycs binary = new Binarycs();
            binary.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(binary);
            binary.Dock = DockStyle.Fill;
            binary.Show();

        }

        private void button21_Click(object sender, EventArgs e)
        {
            Adaptif adaptif = new Adaptif();
            adaptif.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(adaptif);
            adaptif.Dock = DockStyle.Fill;
            adaptif.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Zoom zoom = new Zoom();
            zoom.TopLevel = false;
            contentPanel.Controls.Clear();
            contentPanel.Controls.Add(zoom);
            zoom.Dock = DockStyle.Fill;
            zoom.Show();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            önislemetimer.Start();
        }

        private void önislemetimer_Tick(object sender, EventArgs e)
        {
            if (teknikExpand)
            {
                onislemeteknikcontainer.Height += 10;
                if (onislemeteknikcontainer.Height == onislemeteknikcontainer.MaximumSize.Height)
                {
                    teknikExpand = false;
                    önislemetimer.Stop();

                }


            }
            else
            {
                onislemeteknikcontainer.Height -= 10;
                if (onislemeteknikcontainer.Height == onislemeteknikcontainer.MinimumSize.Height)
                {
                    teknikExpand = true;
                    önislemetimer.Stop();
                }
            }
        }
    }
}
