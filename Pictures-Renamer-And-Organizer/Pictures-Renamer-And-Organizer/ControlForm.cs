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
    public partial class ControlForm : Form
    {
        public ControlForm()
        {
            InitializeComponent();
        }

        

        public void progression(int pourcentage)
        {
            if (pourcentage > this.progressBar1.Maximum)
            {
                pourcentage = this.progressBar1.Maximum;
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
    }
}
