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
            System.Drawing.Bitmap bmp =
             new System.Drawing.Bitmap(Filename);

            // create a new instance of Extractor 
            // class. Here "\n" is the newline 
            // that is used to seprate output of two tags. 
            // You can replace it with "," if you want
            Goheer.EXIF.EXIFextractor er =
                         new Goheer.EXIF.EXIFextractor(ref bmp, "\n");

            // now dump all the tags on console
            labelDate.Text = er["Equip Make"].ToString();

            // to set a tag you have to specify the tag id
            // code 0x13B is for artist nam
            // since this number has ascii string with 
            // it pass the string you want to set
           

            // dispose the image here or do whatever you want.
            //

        }
    }
}
