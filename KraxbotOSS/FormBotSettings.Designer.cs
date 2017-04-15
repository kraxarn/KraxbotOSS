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
            this.gbState = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.gbName.SuspendLayout();
            this.gbState.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbName
            // 
            this.gbName.Controls.Add(this.textBox1);
            this.gbName.Location = new System.Drawing.Point(12, 12);
            this.gbName.Name = "gbName";
            this.gbName.Size = new System.Drawing.Size(165, 50);
            this.gbName.TabIndex = 0;
            this.gbName.TabStop = false;
            this.gbName.Text = "Persona Name";
            // 
            // gbState
            // 
            this.gbState.Controls.Add(this.comboBox1);
            this.gbState.Location = new System.Drawing.Point(12, 70);
            this.gbState.Name = "gbState";
            this.gbState.Size = new System.Drawing.Size(165, 50);
            this.gbState.TabIndex = 1;
            this.gbState.TabStop = false;
            this.gbState.Text = "Persona State";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(150, 20);
            this.textBox1.TabIndex = 0;
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Offline",
            "Online",
            "Busy",
            "Away",
            "Snooze",
            "Looking to Trade",
            "Looking to Play",
            "Max"});
            this.comboBox1.Location = new System.Drawing.Point(7, 20);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(149, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(19, 126);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(150, 25);
            this.btnApply.TabIndex = 2;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            // 
            // FormBotSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(187, 165);
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
            this.gbName.ResumeLayout(false);
            this.gbName.PerformLayout();
            this.gbState.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbName;
        private System.Windows.Forms.GroupBox gbState;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button btnApply;
    }
}