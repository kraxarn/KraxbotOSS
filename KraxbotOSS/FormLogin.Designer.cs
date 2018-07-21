using MaterialSkin.Controls;

namespace KraxbotOSS
{
    partial class FormLogin
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbUsername = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.gbPassword = new System.Windows.Forms.GroupBox();
			this.tbPassword = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.btnLogin = new MaterialSkin.Controls.MaterialFlatButton();
			this.cbSaveLogin = new MaterialSkin.Controls.MaterialCheckBox();
			this.groupBox1.SuspendLayout();
			this.gbPassword.SuspendLayout();
			this.SuspendLayout();
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbUsername);
			this.groupBox1.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.groupBox1.Location = new System.Drawing.Point(12, 74);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(165, 50);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Username";
			// 
			// tbUsername
			// 
			this.tbUsername.Depth = 0;
			this.tbUsername.Hint = "";
			this.tbUsername.Location = new System.Drawing.Point(7, 20);
			this.tbUsername.MaxLength = 32767;
			this.tbUsername.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbUsername.Name = "tbUsername";
			this.tbUsername.PasswordChar = '\0';
			this.tbUsername.SelectedText = "";
			this.tbUsername.SelectionLength = 0;
			this.tbUsername.SelectionStart = 0;
			this.tbUsername.Size = new System.Drawing.Size(150, 23);
			this.tbUsername.TabIndex = 0;
			this.tbUsername.TabStop = false;
			this.tbUsername.UseSystemPasswordChar = false;
			// 
			// gbPassword
			// 
			this.gbPassword.Controls.Add(this.tbPassword);
			this.gbPassword.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.gbPassword.Location = new System.Drawing.Point(12, 130);
			this.gbPassword.Name = "gbPassword";
			this.gbPassword.Size = new System.Drawing.Size(165, 50);
			this.gbPassword.TabIndex = 1;
			this.gbPassword.TabStop = false;
			this.gbPassword.Text = "Password";
			// 
			// tbPassword
			// 
			this.tbPassword.Depth = 0;
			this.tbPassword.Hint = "";
			this.tbPassword.Location = new System.Drawing.Point(7, 20);
			this.tbPassword.MaxLength = 32767;
			this.tbPassword.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.PasswordChar = '\0';
			this.tbPassword.SelectedText = "";
			this.tbPassword.SelectionLength = 0;
			this.tbPassword.SelectionStart = 0;
			this.tbPassword.Size = new System.Drawing.Size(150, 23);
			this.tbPassword.TabIndex = 0;
			this.tbPassword.TabStop = false;
			this.tbPassword.UseSystemPasswordChar = true;
			// 
			// btnLogin
			// 
			this.btnLogin.AutoSize = true;
			this.btnLogin.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnLogin.Depth = 0;
			this.btnLogin.Icon = null;
			this.btnLogin.Location = new System.Drawing.Point(12, 223);
			this.btnLogin.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnLogin.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnLogin.Name = "btnLogin";
			this.btnLogin.Primary = true;
			this.btnLogin.Size = new System.Drawing.Size(61, 36);
			this.btnLogin.TabIndex = 2;
			this.btnLogin.Text = "Login";
			this.btnLogin.UseVisualStyleBackColor = true;
			this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
			// 
			// cbSaveLogin
			// 
			this.cbSaveLogin.AutoSize = true;
			this.cbSaveLogin.Depth = 0;
			this.cbSaveLogin.Font = new System.Drawing.Font("Roboto", 10F);
			this.cbSaveLogin.Location = new System.Drawing.Point(12, 187);
			this.cbSaveLogin.Margin = new System.Windows.Forms.Padding(0);
			this.cbSaveLogin.MouseLocation = new System.Drawing.Point(-1, -1);
			this.cbSaveLogin.MouseState = MaterialSkin.MouseState.HOVER;
			this.cbSaveLogin.Name = "cbSaveLogin";
			this.cbSaveLogin.Ripple = true;
			this.cbSaveLogin.Size = new System.Drawing.Size(120, 30);
			this.cbSaveLogin.TabIndex = 3;
			this.cbSaveLogin.Text = "Remember Me";
			this.cbSaveLogin.UseVisualStyleBackColor = true;
			// 
			// FormLogin
			// 
			this.AcceptButton = this.btnLogin;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(187, 270);
			this.Controls.Add(this.cbSaveLogin);
			this.Controls.Add(this.btnLogin);
			this.Controls.Add(this.gbPassword);
			this.Controls.Add(this.groupBox1);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormLogin";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Login";
			this.TopMost = true;
			this.groupBox1.ResumeLayout(false);
			this.gbPassword.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSingleLineTextField tbUsername;
        private System.Windows.Forms.GroupBox gbPassword;
        private MaterialSingleLineTextField tbPassword;
        private MaterialFlatButton btnLogin;
        private MaterialCheckBox cbSaveLogin;
    }
}