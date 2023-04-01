namespace TrackerUI
{
    partial class CreateTournamentForm
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
            this.headerLabel = new System.Windows.Forms.Label();
            this.tournamentNameValue = new System.Windows.Forms.TextBox();
            this.tournamentNameLabel = new System.Windows.Forms.Label();
            this.entryFeeValue = new System.Windows.Forms.TextBox();
            this.entryFeeLabel = new System.Windows.Forms.Label();
            this.selectTeamDropdown = new System.Windows.Forms.ComboBox();
            this.selectTeamLabel = new System.Windows.Forms.Label();
            this.createNewTeamLink = new System.Windows.Forms.LinkLabel();
            this.addTeamBtn = new System.Windows.Forms.Button();
            this.createPrizeBtn = new System.Windows.Forms.Button();
            this.TournamentPlayerListBox = new System.Windows.Forms.ListBox();
            this.tournamentPlayerLabel = new System.Windows.Forms.Label();
            this.PrizesLabel = new System.Windows.Forms.Label();
            this.PrizesListBox = new System.Windows.Forms.ListBox();
            this.deleteSelectedPlayerBtn = new System.Windows.Forms.Button();
            this.deleteSelctedPrize = new System.Windows.Forms.Button();
            this.createTournamentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Calibri", 28F);
            this.headerLabel.ForeColor = System.Drawing.Color.Black;
            this.headerLabel.Location = new System.Drawing.Point(52, 43);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(395, 58);
            this.headerLabel.TabIndex = 1;
            this.headerLabel.Text = "Create Tournament";
            // 
            // tournamentNameValue
            // 
            this.tournamentNameValue.Location = new System.Drawing.Point(66, 145);
            this.tournamentNameValue.Name = "tournamentNameValue";
            this.tournamentNameValue.Size = new System.Drawing.Size(309, 40);
            this.tournamentNameValue.TabIndex = 10;
            // 
            // tournamentNameLabel
            // 
            this.tournamentNameLabel.AutoSize = true;
            this.tournamentNameLabel.Location = new System.Drawing.Point(60, 107);
            this.tournamentNameLabel.Name = "tournamentNameLabel";
            this.tournamentNameLabel.Size = new System.Drawing.Size(228, 35);
            this.tournamentNameLabel.TabIndex = 9;
            this.tournamentNameLabel.Text = "Tournament Name";
            // 
            // entryFeeValue
            // 
            this.entryFeeValue.Location = new System.Drawing.Point(189, 215);
            this.entryFeeValue.Name = "entryFeeValue";
            this.entryFeeValue.Size = new System.Drawing.Size(100, 40);
            this.entryFeeValue.TabIndex = 12;
            this.entryFeeValue.Text = "0";
            // 
            // entryFeeLabel
            // 
            this.entryFeeLabel.AutoSize = true;
            this.entryFeeLabel.Location = new System.Drawing.Point(60, 220);
            this.entryFeeLabel.Name = "entryFeeLabel";
            this.entryFeeLabel.Size = new System.Drawing.Size(123, 35);
            this.entryFeeLabel.TabIndex = 11;
            this.entryFeeLabel.Text = "Entry Fee";
            // 
            // selectTeamDropdown
            // 
            this.selectTeamDropdown.FormattingEnabled = true;
            this.selectTeamDropdown.Location = new System.Drawing.Point(62, 316);
            this.selectTeamDropdown.Name = "selectTeamDropdown";
            this.selectTeamDropdown.Size = new System.Drawing.Size(313, 41);
            this.selectTeamDropdown.TabIndex = 14;
            // 
            // selectTeamLabel
            // 
            this.selectTeamLabel.AutoSize = true;
            this.selectTeamLabel.Location = new System.Drawing.Point(57, 278);
            this.selectTeamLabel.Name = "selectTeamLabel";
            this.selectTeamLabel.Size = new System.Drawing.Size(150, 35);
            this.selectTeamLabel.TabIndex = 13;
            this.selectTeamLabel.Text = "Select Team";
            // 
            // createNewTeamLink
            // 
            this.createNewTeamLink.AutoSize = true;
            this.createNewTeamLink.Font = new System.Drawing.Font("Calibri", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createNewTeamLink.Location = new System.Drawing.Point(260, 285);
            this.createNewTeamLink.Name = "createNewTeamLink";
            this.createNewTeamLink.Size = new System.Drawing.Size(115, 28);
            this.createNewTeamLink.TabIndex = 15;
            this.createNewTeamLink.TabStop = true;
            this.createNewTeamLink.Text = "create new";
            this.createNewTeamLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.createNewTeamLink_LinkClicked);
            // 
            // addTeamBtn
            // 
            this.addTeamBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.addTeamBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.addTeamBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.addTeamBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.addTeamBtn.Location = new System.Drawing.Point(105, 380);
            this.addTeamBtn.Name = "addTeamBtn";
            this.addTeamBtn.Size = new System.Drawing.Size(205, 47);
            this.addTeamBtn.TabIndex = 16;
            this.addTeamBtn.Text = "Add Team";
            this.addTeamBtn.UseVisualStyleBackColor = true;
            this.addTeamBtn.Click += new System.EventHandler(this.addTeamBtn_Click);
            // 
            // createPrizeBtn
            // 
            this.createPrizeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.createPrizeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.createPrizeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createPrizeBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.createPrizeBtn.Location = new System.Drawing.Point(105, 455);
            this.createPrizeBtn.Name = "createPrizeBtn";
            this.createPrizeBtn.Size = new System.Drawing.Size(205, 47);
            this.createPrizeBtn.TabIndex = 17;
            this.createPrizeBtn.Text = " Create Prize";
            this.createPrizeBtn.UseVisualStyleBackColor = true;
            this.createPrizeBtn.Click += new System.EventHandler(this.createPrizeBtn_Click);
            // 
            // TournamentPlayerListBox
            // 
            this.TournamentPlayerListBox.FormattingEnabled = true;
            this.TournamentPlayerListBox.ItemHeight = 33;
            this.TournamentPlayerListBox.Location = new System.Drawing.Point(494, 107);
            this.TournamentPlayerListBox.Name = "TournamentPlayerListBox";
            this.TournamentPlayerListBox.Size = new System.Drawing.Size(363, 235);
            this.TournamentPlayerListBox.TabIndex = 18;
            // 
            // tournamentPlayerLabel
            // 
            this.tournamentPlayerLabel.AutoSize = true;
            this.tournamentPlayerLabel.Location = new System.Drawing.Point(488, 69);
            this.tournamentPlayerLabel.Name = "tournamentPlayerLabel";
            this.tournamentPlayerLabel.Size = new System.Drawing.Size(167, 35);
            this.tournamentPlayerLabel.TabIndex = 19;
            this.tournamentPlayerLabel.Text = "Team/Players";
            // 
            // PrizesLabel
            // 
            this.PrizesLabel.AutoSize = true;
            this.PrizesLabel.Location = new System.Drawing.Point(488, 349);
            this.PrizesLabel.Name = "PrizesLabel";
            this.PrizesLabel.Size = new System.Drawing.Size(80, 35);
            this.PrizesLabel.TabIndex = 22;
            this.PrizesLabel.Text = "Prizes";
            // 
            // PrizesListBox
            // 
            this.PrizesListBox.FormattingEnabled = true;
            this.PrizesListBox.ItemHeight = 33;
            this.PrizesListBox.Location = new System.Drawing.Point(494, 387);
            this.PrizesListBox.Name = "PrizesListBox";
            this.PrizesListBox.Size = new System.Drawing.Size(363, 235);
            this.PrizesListBox.TabIndex = 21;
            // 
            // deleteSelectedPlayerBtn
            // 
            this.deleteSelectedPlayerBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.deleteSelectedPlayerBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.deleteSelectedPlayerBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteSelectedPlayerBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.deleteSelectedPlayerBtn.Location = new System.Drawing.Point(912, 171);
            this.deleteSelectedPlayerBtn.Name = "deleteSelectedPlayerBtn";
            this.deleteSelectedPlayerBtn.Size = new System.Drawing.Size(124, 84);
            this.deleteSelectedPlayerBtn.TabIndex = 24;
            this.deleteSelectedPlayerBtn.Text = "Delete Team";
            this.deleteSelectedPlayerBtn.UseVisualStyleBackColor = true;
            this.deleteSelectedPlayerBtn.Click += new System.EventHandler(this.deleteSelectedPlayerBtn_Click);
            // 
            // deleteSelctedPrize
            // 
            this.deleteSelctedPrize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.deleteSelctedPrize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.deleteSelctedPrize.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.deleteSelctedPrize.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.deleteSelctedPrize.Location = new System.Drawing.Point(902, 421);
            this.deleteSelctedPrize.Name = "deleteSelctedPrize";
            this.deleteSelctedPrize.Size = new System.Drawing.Size(144, 81);
            this.deleteSelctedPrize.TabIndex = 25;
            this.deleteSelctedPrize.Text = "Delete Prize";
            this.deleteSelctedPrize.UseVisualStyleBackColor = true;
            this.deleteSelctedPrize.Click += new System.EventHandler(this.deleteSelctedPrize_Click);
            // 
            // createTournamentBtn
            // 
            this.createTournamentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.createTournamentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.createTournamentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createTournamentBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.createTournamentBtn.Location = new System.Drawing.Point(284, 633);
            this.createTournamentBtn.Name = "createTournamentBtn";
            this.createTournamentBtn.Size = new System.Drawing.Size(305, 47);
            this.createTournamentBtn.TabIndex = 26;
            this.createTournamentBtn.Text = "Create Tournament";
            this.createTournamentBtn.UseVisualStyleBackColor = true;
            // 
            // CreateTournamentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(1091, 750);
            this.Controls.Add(this.createTournamentBtn);
            this.Controls.Add(this.deleteSelctedPrize);
            this.Controls.Add(this.deleteSelectedPlayerBtn);
            this.Controls.Add(this.PrizesLabel);
            this.Controls.Add(this.PrizesListBox);
            this.Controls.Add(this.tournamentPlayerLabel);
            this.Controls.Add(this.TournamentPlayerListBox);
            this.Controls.Add(this.createPrizeBtn);
            this.Controls.Add(this.addTeamBtn);
            this.Controls.Add(this.createNewTeamLink);
            this.Controls.Add(this.selectTeamDropdown);
            this.Controls.Add(this.selectTeamLabel);
            this.Controls.Add(this.entryFeeValue);
            this.Controls.Add(this.entryFeeLabel);
            this.Controls.Add(this.tournamentNameValue);
            this.Controls.Add(this.tournamentNameLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.Name = "CreateTournamentForm";
            this.Text = "Create Tournament";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.TextBox tournamentNameValue;
        private System.Windows.Forms.Label tournamentNameLabel;
        private System.Windows.Forms.TextBox entryFeeValue;
        private System.Windows.Forms.Label entryFeeLabel;
        private System.Windows.Forms.ComboBox selectTeamDropdown;
        private System.Windows.Forms.Label selectTeamLabel;
        private System.Windows.Forms.LinkLabel createNewTeamLink;
        private System.Windows.Forms.Button addTeamBtn;
        private System.Windows.Forms.Button createPrizeBtn;
        private System.Windows.Forms.ListBox TournamentPlayerListBox;
        private System.Windows.Forms.Label tournamentPlayerLabel;
        private System.Windows.Forms.Label PrizesLabel;
        private System.Windows.Forms.ListBox PrizesListBox;
        private System.Windows.Forms.Button deleteSelectedPlayerBtn;
        private System.Windows.Forms.Button deleteSelctedPrize;
        private System.Windows.Forms.Button createTournamentBtn;
    }
}