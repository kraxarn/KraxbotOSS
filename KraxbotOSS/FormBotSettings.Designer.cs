using MaterialSkin.Controls;

namespace KraxbotOSS
{
    partial class FormBotSettings
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
			this.gbName = new System.Windows.Forms.GroupBox();
			this.tbName = new MaterialSkin.Controls.MaterialSingleLineTextField();
			this.gbState = new System.Windows.Forms.GroupBox();
			this.cbState = new System.Windows.Forms.ComboBox();
			this.btnApply = new MaterialSkin.Controls.MaterialFlatButton();
			this.gbName.SuspendLayout();
			this.gbState.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbName
			// 
			this.gbName.Controls.Add(this.tbName);
			this.gbName.Location = new System.Drawing.Point(12, 73);
			this.gbName.Name = "gbName";
			this.gbName.Size = new System.Drawing.Size(165, 50);
			this.gbName.TabIndex = 0;
			this.gbName.TabStop = false;
			this.gbName.Text = "Persona Name";
			// 
			// tbName
			// 
			this.tbName.Depth = 0;
			this.tbName.Hint = "";
			this.tbName.Location = new System.Drawing.Point(6, 19);
			this.tbName.MaxLength = 32767;
			this.tbName.MouseState = MaterialSkin.MouseState.HOVER;
			this.tbName.Name = "tbName";
			this.tbName.PasswordChar = '\0';
			this.tbName.SelectedText = "";
			this.tbName.SelectionLength = 0;
			this.tbName.SelectionStart = 0;
			this.tbName.Size = new System.Drawing.Size(150, 23);
			this.tbName.TabIndex = 0;
			this.tbName.TabStop = false;
			this.tbName.UseSystemPasswordChar = false;
			// 
			// gbState
			// 
			this.gbState.Controls.Add(this.cbState);
			this.gbState.Location = new System.Drawing.Point(12, 131);
			this.gbState.Name = "gbState";
			this.gbState.Size = new System.Drawing.Size(165, 50);
			this.gbState.TabIndex = 1;
			this.gbState.TabStop = false;
			this.gbState.Text = "Persona State";
			// 
			// cbState
			// 
			this.cbState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbState.FormattingEnabled = true;
			this.cbState.Items.AddRange(new object[] {
            "Offline",
            "Online",
            "Busy",
            "Away",
            "Snooze",
            "Looking to Trade",
            "Looking to Play"});
			this.cbState.Location = new System.Drawing.Point(7, 20);
			this.cbState.Name = "cbState";
			this.cbState.Size = new System.Drawing.Size(149, 21);
			this.cbState.TabIndex = 0;
			// 
			// btnApply
			// 
			this.btnApply.AutoSize = true;
			this.btnApply.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.btnApply.Depth = 0;
			this.btnApply.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnApply.Icon = null;
			this.btnApply.Location = new System.Drawing.Point(114, 190);
			this.btnApply.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
			this.btnApply.MouseState = MaterialSkin.MouseState.HOVER;
			this.btnApply.Name = "btnApply";
			this.btnApply.Primary = false;
			this.btnApply.Size = new System.Drawing.Size(63, 36);
			this.btnApply.TabIndex = 2;
			this.btnApply.Text = "Apply";
			this.btnApply.UseVisualStyleBackColor = true;
			this.btnApply.Click += new System.EventHandler(this.BtnApply_Click);
			// 
			// FormBotSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(191, 238);
			this.Controls.Add(this.btnApply);
			this.Controls.Add(this.gbState);
			this.Controls.Add(this.gbName);
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "FormBotSettings";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Bot Settings";
			this.Shown += new System.EventHandler(this.FormBotSettings_Shown);
			this.gbName.ResumeLayout(false);
			this.gbState.ResumeLayout(false);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.GroupBox gbState;
        private MaterialSingleLineTextField tbName;
        private System.Windows.Forms.ComboBox cbState;
        private MaterialFlatButton btnApply;
    }
}