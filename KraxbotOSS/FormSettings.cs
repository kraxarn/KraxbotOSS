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
    public partial class FormSettings : Form
    {
        public FormSettings()
        {
            InitializeComponent();

            // TODO: For now, default to all, but get from settings later
            cbUpdates.SelectedIndex = 2;
            cbFriendRequest.SelectedIndex = 0;
            cbChatRequest.SelectedIndex = 0;
            cbLoginAs.SelectedIndex = 0;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Save, close and show main form again
            // TODO: Actually save and stuff
            this.Close();
        }
    }
}
