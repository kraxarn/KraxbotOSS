﻿namespace KraxbotOSS
{
    partial class FormSettings
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
            this.cbUpdates = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tbSuperAdmin = new System.Windows.Forms.TextBox();
            this.cbFriendRequest = new System.Windows.Forms.ComboBox();
            this.cbChatRequest = new System.Windows.Forms.ComboBox();
            this.cbLoginAs = new System.Windows.Forms.ComboBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbUpdates);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(180, 50);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Updates to Recieve";
            // 
            // cbUpdates
            // 
            this.cbUpdates.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUpdates.FormattingEnabled = true;
            this.cbUpdates.Items.AddRange(new object[] {
            "None",
            "Only Major",
            "All"});
            this.cbUpdates.Location = new System.Drawing.Point(6, 19);
            this.cbUpdates.Name = "cbUpdates";
            this.cbUpdates.Size = new System.Drawing.Size(169, 21);
            this.cbUpdates.TabIndex = 0;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(260, 295);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(140, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tbSuperAdmin);
            this.groupBox2.Location = new System.Drawing.Point(13, 70);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(180, 50);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Superadmin";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbFriendRequest);
            this.groupBox3.Location = new System.Drawing.Point(13, 126);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(180, 50);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Friend requests";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.cbChatRequest);
            this.groupBox4.Location = new System.Drawing.Point(12, 182);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(183, 50);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chat requests";
            // 
            // tbSuperAdmin
            // 
            this.tbSuperAdmin.Location = new System.Drawing.Point(7, 20);
            this.tbSuperAdmin.Name = "tbSuperAdmin";
            this.tbSuperAdmin.Size = new System.Drawing.Size(167, 20);
            this.tbSuperAdmin.TabIndex = 0;
            // 
            // cbFriendRequest
            // 
            this.cbFriendRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFriendRequest.FormattingEnabled = true;
            this.cbFriendRequest.Items.AddRange(new object[] {
            "Accept All",
            "Ignore All"});
            this.cbFriendRequest.Location = new System.Drawing.Point(7, 20);
            this.cbFriendRequest.Name = "cbFriendRequest";
            this.cbFriendRequest.Size = new System.Drawing.Size(167, 21);
            this.cbFriendRequest.TabIndex = 0;
            // 
            // cbChatRequest
            // 
            this.cbChatRequest.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbChatRequest.FormattingEnabled = true;
            this.cbChatRequest.Items.AddRange(new object[] {
            "Accept All",
            "Superadmin Only",
            "Ignore All"});
            this.cbChatRequest.Location = new System.Drawing.Point(8, 20);
            this.cbChatRequest.Name = "cbChatRequest";
            this.cbChatRequest.Size = new System.Drawing.Size(167, 21);
            this.cbChatRequest.TabIndex = 0;
            // 
            // cbLoginAs
            // 
            this.cbLoginAs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLoginAs.FormattingEnabled = true;
            this.cbLoginAs.Items.AddRange(new object[] {
            "Online",
            "Away",
            "Snooze",
            "Offline"});
            this.cbLoginAs.Location = new System.Drawing.Point(7, 19);
            this.cbLoginAs.Name = "cbLoginAs";
            this.cbLoginAs.Size = new System.Drawing.Size(167, 21);
            this.cbLoginAs.TabIndex = 5;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.cbLoginAs);
            this.groupBox5.Location = new System.Drawing.Point(13, 238);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(182, 50);
            this.groupBox5.TabIndex = 6;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Login As";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.checkedListBox1);
            this.groupBox6.Location = new System.Drawing.Point(199, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(200, 275);
            this.groupBox6.TabIndex = 7;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Chats to Auto Join";
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(6, 19);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(188, 244);
            this.checkedListBox1.TabIndex = 0;
            // 
            // FormSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 330);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormSettings";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Settings";
            this.TopMost = true;
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbUpdates;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tbSuperAdmin;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ComboBox cbFriendRequest;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox cbChatRequest;
        private System.Windows.Forms.ComboBox cbLoginAs;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
    }
}