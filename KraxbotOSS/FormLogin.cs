using System;
using System.Windows.Forms;

using System.IO;

namespace KraxbotOSS
{
    public partial class FormLogin : Form
    {
        public static string Username, Password;
	    private readonly Form1 form;

        public FormLogin(Form1 form1, string argument = "None")
        {
            InitializeComponent();

	        form = form1;

            if (argument == "NeedTwoFactor")
            {
                Console.WriteLine("Need two factor");
                tbUsername.Text = Username;
                tbUsername.Enabled = false;
                cbSaveLogin.Enabled = false;
                gbPassword.Text = "Mobile Authenticator Code";
            }
            else if (argument == "NeedGuard")
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
                File.WriteAllText(Path.Combine(Form1.ConfigPath, "user"), Username);

            switch (gbPassword.Text)
            {
	            case "Password":
		            Password = tbPassword.Text;
		            form.Login(Username, Password, cbSaveLogin.Checked);
		            break;
	            case "Mobile Authenticator Code":
		            form.Login(Username, Password, cbSaveLogin.Checked, null, tbPassword.Text);
		            break;
	            case "Steam Guard Code":
		            form.Login(Username, Password, cbSaveLogin.Checked, tbPassword.Text);
		            break;
            }
            Close();
        }
    }
}
