using System;
using System.Windows.Forms;
using MaterialSkin.Controls;

namespace KraxbotOSS
{
    public partial class FormBotSettings : MaterialForm
    {
	    private readonly Form1 form;

        public FormBotSettings(Form1 form1)
        {
            InitializeComponent();
			Tools.SetMaterialSkin(this);
	        form = form1;
        }

	    protected override void OnShown(EventArgs e)
	    {
		    cbState.BackColor = BackColor;

			base.OnShown(e);
	    }

	    private void FormBotSettings_Shown(object sender, EventArgs e)
        {
            var tag = Tag.ToString();
            // We assume that state is the last character (and it's an int)
            tbName.Text = tag.Substring(0, tag.Length - 1);
            cbState.SelectedIndex = int.Parse(tag.Substring(tag.Length - 1));
        }

		private void BtnApply_Click(object sender, EventArgs e) 
			=> form.UpdateBotSetttings(tbName.Text, (SteamKit2.EPersonaState)cbState.SelectedIndex);
	}
}
