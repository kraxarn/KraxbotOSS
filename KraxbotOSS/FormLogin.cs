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
        public static string Username, Password, AuthCode;

        public FormLogin(string Argument = "None")
        {
            InitializeComponent();

            if (Argument == "NeedTwoFactor")
            {
                Console.WriteLine("Need two factor");
                tbUsername.Text = Username;
                tbUsername.Enabled = false;
                cbSaveLogin.Enabled = false;
                gbPassword.Text = "Mobile Authenticator Code";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Username = tbUsername.Text;
            Password = tbPassword.Text;

            if (gbPassword.Text == "Password")
                Form1.Login(Username, Password, cbSaveLogin.Checked);
            else if (gbPassword.Text == "Mobile Authenticator Code")
                Form1.Login(Username, Password, cbSaveLogin.Checked, null, tbPassword.Text);


            if (cbSaveLogin.Checked)
                Form1.Login(tbUsername.Text, tbPassword.Text, true);
            else
                Form1.Login(tbUsername.Text, tbPassword.Text, false);
            Close();
        }
    }
}
