using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
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
            Image pict = Image.FromFile(Filename);
            // Récupère les propriétés de l'image
            PropertyItem[] propItems = pict.PropertyItems;
            // Initilisation 
            ExifData data = new ExifData();
            data.propItems = propItems;
            richTextBox1.Text = richTextBox1.Text + "\n" + "Date de prise: " + data.DateTake + "   " + data.ItemDate;
            richTextBox1.Text = richTextBox1.Text + "\n" + "Marque de l'appareil: " + data.Maker;
            richTextBox1.Text = richTextBox1.Text + "\n" + "Modèle de l'appareil: " + data.Model;
            richTextBox1.Text = richTextBox1.Text + "\n" + "Année: " + data.DateFormatDate.Year.ToString();
            richTextBox1.Text = richTextBox1.Text + "\n" + "Mois: " + data.DateFormatDate.Month.ToString();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            pictureBox1.Dispose();
        }

        private void openButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "JPEG Images (*.jpg)|*.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                setImage(openFileDialog1.FileName);


            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
