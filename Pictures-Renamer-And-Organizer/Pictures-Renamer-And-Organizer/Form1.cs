using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pictures_Renamer_And_Organizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void openPictureViewerButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Filter = "JPEG Images (*.jpg)|*.jpg";
            openFileDialog1.FileName = "";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                PicturesViewer visualiseur = new PicturesViewer();
                visualiseur.setImage(openFileDialog1.FileName);
                visualiseur.Show();
                
            }

        }

        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //
        }

        private void simpleRenameButton_Click(object sender, EventArgs e)//Bouton de renommage simple
        {
            
            if (folderchoose)
            {
                string repertoire = labelFolder.Text;
                bool createdir = checkBox1.Checked;
                Organiser.Directory(repertoire,createdir);//On renomme les fichiers du dossier
            }
            
        }

        private bool folderchoose;

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogSimple = new FolderBrowserDialog();
            //On affiche une boite dialogue de sélection de dossier
            if (folderBrowserDialogSimple.ShowDialog() == DialogResult.OK)
            {
               labelFolder.Text= folderBrowserDialogSimple.SelectedPath;
                folderchoose = true;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }


    }

