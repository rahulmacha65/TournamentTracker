namespace TrackerUI
{
    partial class TournamentDashboardForm
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
            this.loadTournamentDropdown = new System.Windows.Forms.ComboBox();
            this.loadTorunamentsLabel = new System.Windows.Forms.Label();
            this.loadTournamentBtn = new System.Windows.Forms.Button();
            this.createTournamentBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // headerLabel
            // 
            this.headerLabel.AutoSize = true;
            this.headerLabel.Font = new System.Drawing.Font("Calibri", 28F);
            this.headerLabel.ForeColor = System.Drawing.Color.Black;
            this.headerLabel.Location = new System.Drawing.Point(190, 36);
            this.headerLabel.Name = "headerLabel";
            this.headerLabel.Size = new System.Drawing.Size(479, 58);
            this.headerLabel.TabIndex = 13;
            this.headerLabel.Text = "Tournament Dashboard";
            this.headerLabel.Click += new System.EventHandler(this.headerLabel_Click);
            // 
            // loadTournamentDropdown
            // 
            this.loadTournamentDropdown.FormattingEnabled = true;
            this.loadTournamentDropdown.Location = new System.Drawing.Point(199, 181);
            this.loadTournamentDropdown.Name = "loadTournamentDropdown";
            this.loadTournamentDropdown.Size = new System.Drawing.Size(473, 41);
            this.loadTournamentDropdown.TabIndex = 20;
            this.loadTournamentDropdown.SelectedIndexChanged += new System.EventHandler(this.loadTournamentDropdown_SelectedIndexChanged);
            // 
            // loadTorunamentsLabel
            // 
            this.loadTorunamentsLabel.AutoSize = true;
            this.loadTorunamentsLabel.Location = new System.Drawing.Point(194, 143);
            this.loadTorunamentsLabel.Name = "loadTorunamentsLabel";
            this.loadTorunamentsLabel.Size = new System.Drawing.Size(227, 35);
            this.loadTorunamentsLabel.TabIndex = 19;
            this.loadTorunamentsLabel.Text = "Load Tournaments";
            // 
            // loadTournamentBtn
            // 
            this.loadTournamentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.loadTournamentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.loadTournamentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.loadTournamentBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.loadTournamentBtn.Location = new System.Drawing.Point(254, 277);
            this.loadTournamentBtn.Name = "loadTournamentBtn";
            this.loadTournamentBtn.Size = new System.Drawing.Size(388, 47);
            this.loadTournamentBtn.TabIndex = 21;
            this.loadTournamentBtn.Text = "Load Tournament";
            this.loadTournamentBtn.UseVisualStyleBackColor = true;
            this.loadTournamentBtn.Click += new System.EventHandler(this.loadTournamentBtn_Click);
            // 
            // createTournamentBtn
            // 
            this.createTournamentBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.createTournamentBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.DarkSlateGray;
            this.createTournamentBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.createTournamentBtn.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.createTournamentBtn.Location = new System.Drawing.Point(254, 383);
            this.createTournamentBtn.Name = "createTournamentBtn";
            this.createTournamentBtn.Size = new System.Drawing.Size(388, 90);
            this.createTournamentBtn.TabIndex = 22;
            this.createTournamentBtn.Text = "Create Tournament";
            this.createTournamentBtn.UseVisualStyleBackColor = true;
            this.createTournamentBtn.Click += new System.EventHandler(this.createTournamentBtn_Click);
            // 
            // TournamentDashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 33F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSkyBlue;
            this.ClientSize = new System.Drawing.Size(954, 541);
            this.Controls.Add(this.createTournamentBtn);
            this.Controls.Add(this.loadTournamentBtn);
            this.Controls.Add(this.loadTournamentDropdown);
            this.Controls.Add(this.loadTorunamentsLabel);
            this.Controls.Add(this.headerLabel);
            this.Font = new System.Drawing.Font("Calibri", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.Name = "TournamentDashboardForm";
            this.Text = "Tournament Dashboard";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label headerLabel;
        private System.Windows.Forms.ComboBox loadTournamentDropdown;
        private System.Windows.Forms.Label loadTorunamentsLabel;
        private System.Windows.Forms.Button loadTournamentBtn;
        private System.Windows.Forms.Button createTournamentBtn;
    }
}