namespace TrackerUI
{
    partial class CreateTeamForm
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
            this.teamNameValue = new System.Windows.Forms.TextBox();
            this.teamNameLabel = new System.Windows.Forms.Label();
            this.headerLabel = new System.Windows.Forms.Label();
            this.addTeamMemberBtn = new System.Windows.Forms.Button();
            this.selectTeamMemberDropdown = new System.Windows.Forms.ComboBox();
            this.selectTeamMemeberLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createMemberBtn = new System.Windows.Forms.Button();
            this.cellPhoneNumberValue = new System.Windows.Forms.TextBox();
            this.lnValue = new System.Windows.Forms.TextBox();
            this.cellPhoneLabel = new System.Windows.Forms.Label();
            this.lnLabel = new System.Windows.Forms.Label();
            this.emailTextValue = new System.Windows.Forms.TextBox();
            this.fnValue = new System.Windows.Forms.TextBox();
            this.emailLabel = new System.Windows.Forms.Label();
            this.fnLabel = new System.Windows.Forms.Label();
            this.TeamMemberListbox = new System.Windows.Forms.ListBox();
            this.deleteSelectedMemberBtn = new System.Windows.Forms.Button();
            this.createTeamBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // teamNameValue
            // 
            this.teamNameValue.Location = new System.Drawing.Point(51, 121);
            this.teamNameValue.Name = "teamNameValue";
            this.teamNameValue.Size = new System.Drawing.Size(471, 40);
            this.teamNameValue.TabIndex = 13;
            // 
            // teamNameLabel
            // 
            this.teamNameLabel.AutoSize = true;
            this.teamNameLabel.Location = new System.Drawing.Point(45, 83);
            this.teamNameLabel.Name = "teamNameLabel";
            this.teamNameLabel.Size = new System.Drawing.Size(149, 35);
            this.teamNameLabel.TabIndex = 12;
            this.teamNameLabel.Text = "Team Name";
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Calibri", 28F);
            this.headerLabel.ForeColor = System.Drawing.Color.Black;
            this.headerLabel.Location = new System.Drawing.Point(37, 19);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(263, 58);
            this.headerLabel.TabIndex = 11;
            this.headerLabel.Text = "Create Team";
            // 
            // addTeamMemberBtn
            // 
            this.addTeamMemberBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.addTeamMemberBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.addTeamMemberBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addTeamMemberBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.addTeamMemberBtn.Location = new System.Drawing.Point(168, 301);
            this.addTeamMemberBtn.Name = "addTeamMemberBtn";
            this.addTeamMemberBtn.Size = new System.Drawing.Size(205, 47);
            this.addTeamMemberBtn.TabIndex = 20;
            this.addTeamMemberBtn.Text = "Add Member";
            this.addTeamMemberBtn.UseVisualStyleBackColor = true;
            this.addTeamMemberBtn.Click += new System.EventHandler(this.addTeamMemberBtn_Click);
            // 
            // selectTeamMemberDropdown
            // 
            this.selectTeamMemberDropdown.FormattingEnabled = true;
            this.selectTeamMemberDropdown.Location = new System.Drawing.Point(49, 236);
            this.selectTeamMemberDropdown.Name = "selectTeamMemberDropdown";
            this.selectTeamMemberDropdown.Size = new System.Drawing.Size(473, 41);
            this.selectTeamMemberDropdown.TabIndex = 18;
            // 
            // selectTeamMemeberLabel
            // 
            this.selectTeamMemeberLabel.AutoSize = true;
            this.selectTeamMemeberLabel.Location = new System.Drawing.Point(44, 198);
            this.selectTeamMemeberLabel.Name = "selectTeamMemeberLabel";
            this.selectTeamMemeberLabel.Size = new System.Drawing.Size(269, 35);
            this.selectTeamMemeberLabel.TabIndex = 17;
            this.selectTeamMemeberLabel.Text = "Select Team Memeber";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createMemberBtn);
            this.groupBox1.Controls.Add(this.cellPhoneNumberValue);
            this.groupBox1.Controls.Add(this.lnValue);
            this.groupBox1.Controls.Add(this.cellPhoneLabel);
            this.groupBox1.Controls.Add(this.lnLabel);
            this.groupBox1.Controls.Add(this.emailTextValue);
            this.groupBox1.Controls.Add(this.fnValue);
            this.groupBox1.Controls.Add(this.emailLabel);
            this.groupBox1.Controls.Add(this.fnLabel);
            this.groupBox1.Location = new System.Drawing.Point(51, 379);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(504, 305);
            this.groupBox1.TabIndex = 21;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Add New Member";
            // 
            // createMemberBtn
            // 
            this.createMemberBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.createMemberBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.createMemberBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createMemberBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.createMemberBtn.Location = new System.Drawing.Point(117, 246);
            this.createMemberBtn.Name = "createMemberBtn";
            this.createMemberBtn.Size = new System.Drawing.Size(205, 47);
            this.createMemberBtn.TabIndex = 26;
            this.createMemberBtn.Text = "Create Member";
            this.createMemberBtn.UseVisualStyleBackColor = true;
            this.createMemberBtn.Click += new System.EventHandler(this.createMemberBtn_Click);
            // 
            // cellPhoneNumberValue
            // 
            this.cellPhoneNumberValue.Location = new System.Drawing.Point(174, 200);
            this.cellPhoneNumberValue.Name = "cellPhoneNumberValue";
            this.cellPhoneNumberValue.Size = new System.Drawing.Size(276, 40);
            this.cellPhoneNumberValue.TabIndex = 25;
            // 
            // lnValue
            // 
            this.lnValue.Location = new System.Drawing.Point(174, 104);
            this.lnValue.Name = "lnValue";
            this.lnValue.Size = new System.Drawing.Size(276, 40);
            this.lnValue.TabIndex = 12;
            // 
            // cellPhoneLabel
            // 
            this.cellPhoneLabel.AutoSize = true;
            this.cellPhoneLabel.Location = new System.Drawing.Point(35, 200);
            this.cellPhoneLabel.Name = "cellPhoneLabel";
            this.cellPhoneLabel.Size = new System.Drawing.Size(141, 35);
            this.cellPhoneLabel.TabIndex = 24;
            this.cellPhoneLabel.Text = "Cell Phone ";
            // 
            // lnLabel
            // 
            this.lnLabel.AutoSize = true;
            this.lnLabel.Location = new System.Drawing.Point(35, 104);
            this.lnLabel.Name = "lnLabel";
            this.lnLabel.Size = new System.Drawing.Size(133, 35);
            this.lnLabel.TabIndex = 11;
            this.lnLabel.Text = "Last Name";
            // 
            // emailTextValue
            // 
            this.emailTextValue.Location = new System.Drawing.Point(174, 149);
            this.emailTextValue.Name = "emailTextValue";
            this.emailTextValue.Size = new System.Drawing.Size(276, 40);
            this.emailTextValue.TabIndex = 23;
            // 
            // fnValue
            // 
            this.fnValue.Location = new System.Drawing.Point(174, 53);
            this.fnValue.Name = "fnValue";
            this.fnValue.Size = new System.Drawing.Size(276, 40);
            this.fnValue.TabIndex = 10;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Location = new System.Drawing.Point(35, 149);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(76, 35);
            this.emailLabel.TabIndex = 22;
            this.emailLabel.Text = "Email";
            // 
            // fnLabel
            // 
            this.fnLabel.AutoSize = true;
            this.fnLabel.Location = new System.Drawing.Point(35, 53);
            this.fnLabel.Name = "fnLabel";
            this.fnLabel.Size = new System.Drawing.Size(137, 35);
            this.fnLabel.TabIndex = 9;
            this.fnLabel.Text = "First Name";
            // 
            // TeamMemberListbox
            // 
            this.TeamMemberListbox.FormattingEnabled = true;
            this.TeamMemberListbox.ItemHeight = 33;
            this.TeamMemberListbox.Location = new System.Drawing.Point(603, 83);
            this.TeamMemberListbox.Name = "TeamMemberListbox";
            this.TeamMemberListbox.Size = new System.Drawing.Size(363, 565);
            this.TeamMemberListbox.TabIndex = 22;
            // 
            // deleteSelectedMemberBtn
            // 
            this.deleteSelectedMemberBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.deleteSelectedMemberBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.deleteSelectedMemberBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteSelectedMemberBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.deleteSelectedMemberBtn.Location = new System.Drawing.Point(984, 286);
            this.deleteSelectedMemberBtn.Name = "deleteSelectedMemberBtn";
            this.deleteSelectedMemberBtn.Size = new System.Drawing.Size(134, 103);
            this.deleteSelectedMemberBtn.TabIndex = 23;
            this.deleteSelectedMemberBtn.Text = "Remove Member";
            this.deleteSelectedMemberBtn.UseVisualStyleBackColor = true;
            this.deleteSelectedMemberBtn.Click += new System.EventHandler(this.deleteSelectedMemberBtn_Click);
            // 
            // createTeamBtn
            // 
            this.createTeamBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.createTeamBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.createTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createTeamBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.createTeamBtn.Location = new System.Drawing.Point(461, 717);
            this.createTeamBtn.Name = "createTeamBtn";
            this.createTeamBtn.Size = new System.Drawing.Size(223, 56);
            this.createTeamBtn.TabIndex = 27;
            this.createTeamBtn.Text = "Create Team";
            this.createTeamBtn.UseVisualStyleBackColor = true;
            this.createTeamBtn.Click += new System.EventHandler(this.createTeamBtn_Click);
            // 
            // CreateTeamForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1203, 785);
            this.Controls.Add(this.createTeamBtn);
            this.Controls.Add(this.deleteSelectedMemberBtn);
            this.Controls.Add(this.TeamMemberListbox);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.addTeamMemberBtn);
            this.Controls.Add(this.selectTeamMemberDropdown);
            this.Controls.Add(this.selectTeamMemeberLabel);
            this.Controls.Add(this.teamNameValue);
            this.Controls.Add(this.teamNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CreateTeamForm";
            this.Text = "Create Team";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox teamNameValue;
        private System.Windows.Forms.Label teamNameLabel;
        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.Button addTeamMemberBtn;
        private System.Windows.Forms.ComboBox selectTeamMemberDropdown;
        private System.Windows.Forms.Label selectTeamMemeberLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button createMemberBtn;
        private System.Windows.Forms.TextBox cellPhoneNumberValue;
        private System.Windows.Forms.TextBox lnValue;
        private System.Windows.Forms.Label cellPhoneLabel;
        private System.Windows.Forms.Label lnLabel;
        private System.Windows.Forms.TextBox emailTextValue;
        private System.Windows.Forms.TextBox fnValue;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label fnLabel;
        private System.Windows.Forms.ListBox TeamMemberListbox;
        private System.Windows.Forms.Button deleteSelectedMemberBtn;
        private System.Windows.Forms.Button createTeamBtn;
    }
}