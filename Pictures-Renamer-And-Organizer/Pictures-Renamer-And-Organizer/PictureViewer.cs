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
using Pictures_Renamer_And_Organizer;
using System.Text.RegularExpressions;

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
            richTextBox1.Text = richTextBox1.Text + "\n" + "Date de prise: " + data.DateTake ;
            richTextBox1.Text = richTextBox1.Text + "\n" + "Marque de l'appareil: " + data.Maker;
            richTextBox1.Text = richTextBox1.Text + "\n" + "Modèle de l'appareil: " + data.Model;
            DateTime date = data.DateFormatDate;
            richTextBox1.Text = richTextBox1.Text + "\n" + "Année: " + date.Year.ToString("0000");
            richTextBox1.Text = richTextBox1.Text + "\n" + "Mois: " + date.Month.ToString("00");
            string newName = date.Year.ToString("0000") + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00") + " " + date.Hour.ToString("00") + "h" + date.Minute.ToString("00") + "mn" + date.Second.ToString("00") + "s";
            richTextBox1.Text = richTextBox1.Text + "\n" + newName;
            pict.Dispose();
           

            string newname2 = Organiser.Simple(Filename);
            //Regex myRegex = new Regex(@"\d\d\d\d-\d\d-\d\d");
            //bool needrename = myRegex.IsMatch(System.IO.Path.GetFileNameWithoutExtension(Filename));

            richTextBox1.Text = richTextBox1.Text + "\n" + "Renommage Simple: " + newname2;
            bool exist = System.IO.File.Exists(newname2);
            richTextBox1.Text = richTextBox1.Text + "\n" + exist.ToString();
            //richTextBox1.Text = richTextBox1.Text  + "Déjà sous le bon format: "+ needrename.ToString();


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
                label1.Text = openFileDialog1.FileName;
                setImage(openFileDialog1.FileName);


            }
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void testButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
