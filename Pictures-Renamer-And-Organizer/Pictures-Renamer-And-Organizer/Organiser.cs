using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Pictures_Renamer_And_Organizer
{
    public static class Organiser
    {
        private static Regex dateRegex = new Regex(@"\d\d\d\d-\d\d-\d\d");


        public static string Simple(string currentFile)
        {
            string currentDirectory = System.IO.Path.GetDirectoryName(currentFile); 
            return Simple(currentFile, currentDirectory);
        }

        public static string Simple(string currentFile, string newdirectory)
        // Transformation de l'ancien nom en nouveau nom, sans action sur les fichiers
        //Demande le chemin du fichier et le répertoire d'arrivée.
        {
            string extension = System.IO.Path.GetExtension(currentFile);
            string oldName = System.IO.Path.GetFileNameWithoutExtension(currentFile);

            // Récupère les propriétés de l'image

            Image pict = Image.FromFile(currentFile);
                PropertyItem[] propItems = pict.PropertyItems;


                // Initilisation 
                ExifData data = new ExifData();
                data.propItems = propItems;
                DateTime date = data.DateFormatDate;
                //Si la date n'a pas été trouvé, on renvoie le nom initial
                if (date == DateTime.MinValue)
                {
                    return currentFile;
                }
                string newName = date.Year.ToString("0000") + "-" + date.Month.ToString("00") + "-" + date.Day.ToString("00") + " " + date.Hour.ToString("00") + "h" + date.Minute.ToString("00") + "mn" + date.Second.ToString("00") + "s";
                string newPath = newdirectory + System.IO.Path.DirectorySeparatorChar + newName + extension;
            bool exist = System.IO.File.Exists(newPath);
            if (exist == true)
            {
                string nameindex = newName;
                int count = 1;
                while (System.IO.File.Exists(newPath) == true)
                {
                    nameindex = newName + "-" + count.ToString("00");
                    newPath = newdirectory + System.IO.Path.DirectorySeparatorChar + nameindex + extension;
                    count++;
                }
            }
            pict.Dispose();
            return newPath; 
            
        }

        public static void RenameFile(string currentFile)//Renommage effectif de fichiers !
        {
            
                string name = System.IO.Path.GetFileName(currentFile);
                bool IsdateFormat = dateRegex.IsMatch(System.IO.Path.GetFileNameWithoutExtension(name));


            if (IsdateFormat == false) //Si le nom n'est pas déjà sous le bon format
            {
                string newname = Simple(currentFile);

                if (currentFile != newname) // Si le "renommage" a réussit
                {
                    System.IO.File.Move(currentFile, newname);//On renomme !
                }
            }
            
        }

        public static void Directory(string currentDirectory, bool createdir)
        {
            
            IEnumerable<string> txtFiles = System.IO.Directory.EnumerateFiles(currentDirectory, "*.*", System.IO.SearchOption.TopDirectoryOnly);
            int totalCount = txtFiles.Count();

            int tempCount = 0;
            ControlForm control = new ControlForm();
            control.Show();
            control.maxBarre(totalCount);
            foreach (string currentFile in txtFiles)
                {
                
                    string extension = System.IO.Path.GetExtension(currentFile);
                    if (extension == ".jpg" || extension == ".JPG")
                    {
                        RenameFile(currentFile);
                    
                    }
                control.progression(tempCount);
                tempCount++;
                
                
            }
            control.progression(totalCount);

            if (createdir)
            {
                txtFiles = System.IO.Directory.EnumerateFiles(currentDirectory, "*.*", System.IO.SearchOption.TopDirectoryOnly);
                foreach (string currentFile in txtFiles) { 
                    string name = System.IO.Path.GetFileName(currentFile);
                    bool IsdateFormat = dateRegex.IsMatch(System.IO.Path.GetFileNameWithoutExtension(name));
                    if (IsdateFormat)
                    {
                        string newdir = name.Substring(0, 10);
                        string currentFolder = System.IO.Path.GetDirectoryName(currentFile);
                        string pathString = System.IO.Path.Combine(currentFolder, newdir);
                        if (System.IO.Directory.Exists(pathString) == false) { System.IO.Directory.CreateDirectory(pathString); }

                        string destFile = System.IO.Path.Combine(pathString, name);
                        System.IO.File.Move(currentFile, destFile);
                    }
                }
            }

            }



        }

        
    }


