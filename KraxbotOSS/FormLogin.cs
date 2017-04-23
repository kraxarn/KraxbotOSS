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

        private void cbSaveLogin_CheckedChanged(object sender, EventArgs e)
        {
            if (cbSaveLogin.Checked)
            {
                EncryptKey = null;
                DialogResult result = MessageBox.Show(
                    "To save your password, it needs to be encrypted." +
                    "\nWould you like me to automatically generate a key for you?" +
                    "\nIf you select 'No', you'll need to manually enter a key." +
                    "\nIf you are unsure, just press 'Yes'",
                    "Password Encryption",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question
                );
                if (result == DialogResult.Yes)
                    EncryptKey = Environment.MachineName;
                else if (result == DialogResult.No)
                {
                    FormSaveLogin saveLogin = new FormSaveLogin();
                    DialogResult encryptResult = saveLogin.ShowDialog(this);
                    if (string.IsNullOrEmpty(EncryptKey))
                        cbSaveLogin.Checked = false;
                }
                else
                    cbSaveLogin.Checked = false;
            }
        }

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

            if (gbPassword.Text == "Password")
            {
                Password = tbPassword.Text;
                Form1.Login(Username, Password, cbSaveLogin.Checked);
            }
            else if (gbPassword.Text == "Mobile Authenticator Code")
                Form1.Login(Username, Password, cbSaveLogin.Checked, null, tbPassword.Text);
            Close();
        }
    }
}
