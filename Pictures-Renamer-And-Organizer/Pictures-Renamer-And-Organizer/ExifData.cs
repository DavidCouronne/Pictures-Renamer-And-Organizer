using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pictures_Renamer_And_Organizer
{
    class ExifData
    {

        public PropertyItem[] propItems
        {
            get; set;
        }

        private string Convertisseur(int item)//Retourne au format string la valeur de la la propriété de item.
        {
            string str = Encoding.UTF8.GetString(propItems[item].Value, 0, propItems[item].Value.Length);
            int nullCharIndex = str.IndexOf('\0');
            if (nullCharIndex != -1)// Si il y a un byte null à la fin, on le vire !
                str = str.Substring(0, nullCharIndex);
            return str;
        }

        public string ValueItem(int item)
        {
            return Convertisseur(item);
        }
        // Date Time
        public string DateTake // Retourne la date en format string
        {
            get
            {

                return Convertisseur(FindDate());
            }
        }
        public string Maker //Retourne le fabriquant (normalement...)
        {
            get { return Convertisseur(0); }
        }
        public string Model //Retourne le modèle de l'appareil (normalement..)
        {
            get { return Convertisseur(1); }
        }

        private DateTime ConvertisseurDate(string date) //Retourne la date au format DateTime pour manipulations
        {
            //Si le format de date n'est pas bon, on retourne la date minimale, à tester dans le programme principal
            if (date.Length < 10)
            {
                return DateTime.MinValue;
            }
            if (date.Length == 10)
            {
                return DateTime.ParseExact(date, "yyyy:MM:dd", CultureInfo.InvariantCulture);//Inutile maintenant
            }
            //Instruction trouvée dans la doc officielle de Microsoft sur DateTime
            return DateTime.ParseExact(date, "yyyy:MM:dd HH:mm:ss", CultureInfo.InvariantCulture);

        }

        public DateTime DateFormatDate
        {
            get { return ConvertisseurDate(Convertisseur(FindDate())); }
        }


        //La date n'est pas toujours au meme endroit !!!
        //Mais la date de prise de vue est "toujours" la deuxième date rencontrée
        //Testé sur plusieurs photos prises entre 2003 et 2016

        private int FindDate()
        {
            int counter = 0;//Compte le numéro de propriété
            int counter2 = 0;//Teste si c'est bien la deuxième date rencontrée.
            foreach (PropertyItem item in propItems)
            {
                if (item.Value.Length == 20)//Parti pris: finalement on ne cherche que les dates de longueur 20
                    
                {
                    if (counter2 != 0) { return counter; }
                    counter2 = counter2 + 1;
                }
                counter = counter + 1;

            }
            return 0; // Retourne 0 si aucune date valide trouvée
        }

        public int ItemDate { get { return FindDate(); } }
    }
}
