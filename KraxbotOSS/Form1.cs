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
    public partial class Form1 : Form
    {
        // Some variables
        string version = "0.1.0";

        public Form1()
        {
            InitializeComponent();

            lbChatrooms.Items.Add("Test");
            log.AppendText("Welcome to KraxBotOSS " + version);
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            // Hide the main form and show the settings form
            //this.Hide();
            Form settings = new FormSettings();
            settings.Show();
        }
    }
}
