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
        public static string Username, Password, AuthCode, EncryptKey;
        public static bool AutoGenerateKey;

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
            else if (Argument == "NeedGuard")
            {
                tbUsername.Text     = Username;
                tbUsername.Enabled  = false;
                cbSaveLogin.Enabled = false;
                gbPassword.Text     = "Steam Guard Code";
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Username = tbUsername.Text;

            if (cbSaveLogin.Checked)
                File.WriteAllText(Path.Combine(Form1.configPath, "user"), Username);

            if (gbPassword.Text == "Password")
            {
                Password = tbPassword.Text;
                Form1.Login(Username, Password, cbSaveLogin.Checked);
            }
            else if (gbPassword.Text == "Mobile Authenticator Code")
                Form1.Login(Username, Password, cbSaveLogin.Checked, null, tbPassword.Text);
            else if (gbPassword.Text == "Steam Guard Code")
                Form1.Login(Username, Password, cbSaveLogin.Checked, tbPassword.Text, null);
            Close();
        }
    }
}
