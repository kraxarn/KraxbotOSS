using System;
using System.Windows.Forms;

namespace KraxbotOSS
{
    public partial class FormSaveLogin : Form
    {
        public FormSaveLogin()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbKey.Text))
            {
                FormLogin.EncryptKey = tbKey.Text;
                Close();
            }
        }
    }
}
