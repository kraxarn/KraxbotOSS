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
    public partial class FormBotSettings : Form
    {
        public FormBotSettings()
        {
            InitializeComponent();
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Form1.UpdateBotSetttings(tbName.Text, (SteamKit2.EPersonaState)cbState.SelectedIndex);
        }
    }
}
