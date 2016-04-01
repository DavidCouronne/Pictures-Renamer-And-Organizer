using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictures_Renamer_And_Organizer
{
    public partial class PicturesViewer : Form
    {
        public PicturesViewer()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void labelDate_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void setImage(string Filename)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Load(Filename);
            ExifViewer(Filename);
            

        }

        private void ExifViewer(string Filename)
        {
            richTextBox1.Text = "Rien pour le moment !!! \n Ca marchera un jour ....";
        }
    }
}
