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

        private void simpleRenameButton_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialogSimple = new FolderBrowserDialog();
            if (folderBrowserDialogSimple.ShowDialog() == DialogResult.OK)
            {
                string repertoire = folderBrowserDialogSimple.SelectedPath;
                Organiser.Directory(repertoire);
            }
                


        }

        
    }
}
