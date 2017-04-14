using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KraxbotOSS
{
    public partial class FormAdvSettings : Form
    {
        public FormAdvSettings()
        {
            InitializeComponent();
        }

        private void btnMoreInfo_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/KraXarN/KraxbotOSS/wiki/API-Keys");
        }
    }
}
