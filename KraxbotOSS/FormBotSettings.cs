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

        private void FormBotSettings_Shown(object sender, EventArgs e)
        {
            string tag = Tag.ToString();
            // We assume that state is the last character (and it's an int)
            tbName.Text = tag.Substring(0, tag.Length - 1);
            cbState.SelectedIndex = int.Parse(tag.Substring(tag.Length - 1));
        }

        private void btnApply_Click(object sender, EventArgs e)
        {
            Form1.UpdateBotSetttings(tbName.Text, (SteamKit2.EPersonaState)cbState.SelectedIndex);
        }
    }
}
