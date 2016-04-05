using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Pictures_Renamer_And_Organizer
{
    public partial class ControlForm : Form
    {
        public ControlForm()
        {
            InitializeComponent();
        }

        private bool start = false;
        private static Regex dateRegex = new Regex(@"\d\d\d\d-\d\d-\d\d");
        private string currentdirectory;//contient le nom du répertoire d'action
        public string currentDirectory {
            get { return currentdirectory; }
            set {
                currentdirectory = value;
                labelDirName.Text = value;
            } }
        private bool createsubdirectory=false;//pour savoir si on doit créer des sous-repertoires
        public bool Createsubdirectory { get { return createsubdirectory; }
            set {
                createsubdirectory = value;
                if (createsubdirectory) { labelSubDirCheck.Text = "Oui"; }
                else { labelSubDirCheck.Text = "Non"; }
            }
        }
        public void progression(int pourcentage)
        {
            if (pourcentage > progressBar1.Maximum)//Bizarrement il compte parfois plus de fichiers qu'initialement...
            {
                pourcentage = progressBar1.Maximum;
            }
            this.progressBar1.Value = pourcentage;
           
            
        }
        public void maxBarre(int maximum)
        {
            this.progressBar1.Maximum = maximum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (start==false) {
                
                start = true;
                
                Directory(currentdirectory, createsubdirectory);
                label1.Text = "Terminé !";
                buttonStart.Hide();//On cache le bouton démarrer pour ne pas relancer une autre fois.
                
            }
            else {  start = false;  }
        }

        
        //Test méthode avec progress bar
        private void Directory(string currentDirectory, bool createdir)
        {

            IEnumerable<string> txtFiles = System.IO.Directory.EnumerateFiles(currentDirectory, "*.*", System.IO.SearchOption.TopDirectoryOnly);
            int totalCount = txtFiles.Count();

            int tempCount = 0;
            maxBarre(totalCount);//On intialisise le max de la progressBar au nombre de fichiers
            foreach (string currentFile in txtFiles)
            {
                if (!start) { break; }//tentative de mettre une possibilité d'annuler, mais ça ne marche pas...
                string extension = System.IO.Path.GetExtension(currentFile);
                if (extension == ".jpg" || extension == ".JPG")
                {
                    Organiser.RenameFile(currentFile);

                }
                progression(tempCount);
                tempCount++;
            }

            progression(totalCount);//On mets la barre au maximum: bizarrement parfois elle n'y est pas...

            if (createdir)// Si on doit créer des répertoires...
            {
                txtFiles = System.IO.Directory.EnumerateFiles(currentDirectory, "*.*", System.IO.SearchOption.TopDirectoryOnly);
                foreach (string currentFile in txtFiles)
                {
                    string name = System.IO.Path.GetFileName(currentFile);
                    bool IsdateFormat = dateRegex.IsMatch(System.IO.Path.GetFileNameWithoutExtension(name));
                    if (IsdateFormat)// Si c'est bien des fichiers renommés, on les déplace
                    {
                        string newdir = name.Substring(0, 10);
                        string currentFolder = System.IO.Path.GetDirectoryName(currentFile);
                        string pathString = System.IO.Path.Combine(currentFolder, newdir);
                        if (System.IO.Directory.Exists(pathString) == false) { System.IO.Directory.CreateDirectory(pathString); }
                        //On créé le répertoire YYYY-MM-DD si il n'existe pas
                        string destFile = System.IO.Path.Combine(pathString, name);
                        System.IO.File.Move(currentFile, destFile);
                    }
                }
            }
            
         

        }
    }
}
