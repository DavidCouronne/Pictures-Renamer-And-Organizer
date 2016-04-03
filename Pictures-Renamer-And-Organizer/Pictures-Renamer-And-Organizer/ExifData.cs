using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
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

        private string Convertisseur(int item)
        {
            string str = Encoding.UTF8.GetString(propItems[item].Value, 0, propItems[item].Value.Length);
            int nullCharIndex = str.IndexOf('\0');
            if (nullCharIndex != -1)
                str = str.Substring(0, nullCharIndex);
            return str;
        }
        
        public string ValueItem (int item)
        {
            return Convertisseur(item);
        }
        // Date Time
        public string DateTake
        {
            get { return Convertisseur(13); }
        }
        public string Maker
        {
            get { return Convertisseur(0); }
        }
        public string Model
        {
            get { return Convertisseur(1); }
        }
    }
}
