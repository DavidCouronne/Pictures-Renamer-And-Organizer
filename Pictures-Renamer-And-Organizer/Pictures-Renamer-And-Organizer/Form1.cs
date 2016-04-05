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
            PicturesViewer visualiseur = new PicturesViewer();
            visualiseur.StartPosition = FormStartPosition.CenterParent;


            visualiseur.Show();//On ouvre le visualiseur d'images
        }

        
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            //
        }

        private void simpleRenameButton_Click(object sender, EventArgs e)//Bouton de renommage simple
        {

            if (folderchoose)
            {
                ControlForm control = new ControlForm();
                control.currentDirectory = labelFolder.Text;
                control.Createsubdirectory = checkBox1.Checked;
                control.StartPosition = FormStartPosition.CenterScreen;
                control.Show();
                control.Start();//Démarrer le renommage
            }

        }

        private bool folderchoose = false;

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogSimple = new FolderBrowserDialog();
            //On affiche une boite dialogue de sélection de dossier
            if (folderBrowserDialogSimple.ShowDialog() == DialogResult.OK)
            {
                labelFolder.Text = folderBrowserDialogSimple.SelectedPath;// On met le nom du dossier dans le labelFolder
                folderchoose = true;//On signale qu'un dossier a bien été choisi
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }


    }


}

