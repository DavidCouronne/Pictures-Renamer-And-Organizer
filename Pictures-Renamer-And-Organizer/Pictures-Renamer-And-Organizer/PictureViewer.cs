using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pictures_Renamer_And_Organizer
{
    public partial class PicturesViewer : Form
    {
        public PicturesViewer()
        {
            InitializeComponent();
        }

        

        public void setImage(string Filename)
        {

            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.Load(Filename);
            ExifViewer(Filename);
        }

        private void LogWriteLigne(string ligne)//Permet d'écrire une ligne dans la richtextbox1
        {
            richTextBox1.Text = richTextBox1.Text + "\n" + ligne;
        }

        private void ExifViewer(string Filename)
        {
            //On décompresse l'image en mémoire pour lecture des données
            Image pict = Image.FromFile(Filename);
            // Récupère les propriétés de l'image
            PropertyItem[] propItems = pict.PropertyItems;
            // Initilisation 
            ExifData data = new ExifData();
            data.propItems = propItems;//on passe les items de propriétés

            //Ecriture dans la richtextbox1
            LogWriteLigne("===============================");
            LogWriteLigne("Date de prise: " + data.DateTake);
            LogWriteLigne("Marque de l'appareil: " + data.Maker);
            LogWriteLigne("Modèle de l'appareil: " + data.Model);
            DateTime date = data.DateFormatDate;
            LogWriteLigne("Année: " + date.Year.ToString("0000"));
            LogWriteLigne("Mois: " + date.Month.ToString("00"));
            string newName = date.Year.ToString("0000") + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00") + " " + date.Hour.ToString("00") + "h" + date.Minute.ToString("00") + "mn" + date.Second.ToString("00") + "s";
            LogWriteLigne("Formatage date pour renommage: " +newName);
            var dateTest = pict.GetPropertyItem(0x0132);
            string datestring = Encoding.ASCII.GetString(dateTest.Value).TrimEnd('\0');
            LogWriteLigne("Date retourné par lecture EXIF du 0x0132: " + datestring);
            pict.Dispose();
           
            //Test de la fonction de renommage simple
            string newname2 = Organiser.Simple(Filename);
            Regex myRegex = new Regex(@"\d\d\d\d-\d\d-\d\d");
            bool needrename = myRegex.IsMatch(System.IO.Path.GetFileNameWithoutExtension(Filename));

            LogWriteLigne( "Renommage Simple: " + newname2);
            bool exist = System.IO.File.Exists(newname2);
            LogWriteLigne( "Le fichier existe déjà ?:"+exist.ToString());
            LogWriteLigne("Déjà sous le bon format ?: "+ needrename.ToString());

            
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

        

        
    }
}
