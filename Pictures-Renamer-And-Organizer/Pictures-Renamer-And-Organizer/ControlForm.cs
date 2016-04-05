using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pictures_Renamer_And_Organizer
{
    public partial class ControlForm : Form
    {
        public ControlForm()
        {
            InitializeComponent();
        }
        private void ReportProgress(int pourcentage)
        {
            if (pourcentage > progressBar1.Maximum)//Bizarrement il compte parfois plus de fichiers qu'initialement...
            {
                pourcentage = progressBar1.Maximum;
            }
            progressBar1.Value = pourcentage;
            label1.Text = string.Format("Fichiers traités: {0} / {1}",pourcentage.ToString(), progressBar1.Maximum.ToString());
        }

        private CancellationTokenSource cts;

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
            progressBar1.Value = pourcentage;
           
            
        }
        public void maxBarre(int maximum)
        {
            this.progressBar1.Maximum = maximum;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cts.Cancel();
            Close(); 
        }

        public async void Start()
        {
            if (start == false)
            {
                cts = new CancellationTokenSource();
                var progressIndicator = new Progress<int>(ReportProgress);
                start = true;
                try { int x = await DirectoryAsync(currentdirectory, createsubdirectory, progressIndicator, cts.Token);
                    //ReportProgress(progressBar1.Maximum);
                }
                catch (OperationCanceledException) { }

                
                start = false;
            }
        }
        
        
        //Test méthode asynchrone
        private async Task<int> DirectoryAsync(string currentDirectory, bool createdir, IProgress<int> progress,CancellationToken ct)
        {
            IEnumerable<string> txtFiles = System.IO.Directory.EnumerateFiles(currentDirectory, "*.*", System.IO.SearchOption.TopDirectoryOnly);
            int totalCount = txtFiles.Count();

            
            maxBarre(totalCount);//On intialisise le max de la progressBar au nombre de fichiers

            //Ici démarrer le truc asynchrone...
            int processCount = await Task.Run(async () =>
           {

               int tempCount = 0;
               foreach (string currentFile in txtFiles)
               {
                   
                   string extension = System.IO.Path.GetExtension(currentFile);
                   if (extension == ".jpg" || extension == ".JPG")
                   {
                       if (ct.IsCancellationRequested) { break; }
                       await Organiser.RenameFileAsync(currentFile);
                       
                       
                       if (progress != null)
                       {
                           progress.Report(tempCount);
                       }

                   }
                   
                   tempCount++;
               }
               return tempCount;
           },ct);
            
             

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
            progression(totalCount); //On mets la barre au maximum: bizarrement parfois elle n'y est pas...
            return 1;

        }
//

        //Méthode qui fonctionne de manière synchrone
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

        private void stopButton_Click(object sender, EventArgs e)
        {
            if (cts != null)
            {
                cts.Cancel();
            }
        }
    }
}
