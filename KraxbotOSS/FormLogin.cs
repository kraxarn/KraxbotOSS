using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace KraxbotOSS
{
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (cbSaveLogin.Checked)
                Form1.Login(tbUsername.Text, tbPassword.Text, true);
            else
                Form1.Login(tbUsername.Text, tbPassword.Text, false);
            Close();
        }
    }
}
