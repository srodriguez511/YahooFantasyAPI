namespace YahooService
{
    partial class Form1
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
            this.mainTextBox = new System.Windows.Forms.RichTextBox();
            this.RequestTokenButton = new System.Windows.Forms.Button();
            this.VerifierButton = new System.Windows.Forms.Button();
            this.webBrowserPage = new System.Windows.Forms.WebBrowser();
            this.VerifierTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.accessTokenButton = new System.Windows.Forms.Button();
            this.getUserInformationButton = new System.Windows.Forms.Button();
            this.getUserGamesButton = new System.Windows.Forms.Button();
            this.getUserLeaguesButton = new System.Windows.Forms.Button();
            this.gamesTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.getUserTeamsButton = new System.Windows.Forms.Button();
            this.leagueIdTextBox = new System.Windows.Forms.TextBox();
            this.requestedLeagueLabel = new System.Windows.Forms.Label();
            this.getLeagueInfoButton = new System.Windows.Forms.Button();
            this.subresourceTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // mainTextBox
            // 
            this.mainTextBox.Location = new System.Drawing.Point(12, 12);
            this.mainTextBox.Name = "mainTextBox";
            this.mainTextBox.Size = new System.Drawing.Size(596, 529);
            this.mainTextBox.TabIndex = 0;
            this.mainTextBox.Text = "";
            // 
            // RequestTokenButton
            // 
            this.RequestTokenButton.Location = new System.Drawing.Point(614, 12);
            this.RequestTokenButton.Name = "RequestTokenButton";
            this.RequestTokenButton.Size = new System.Drawing.Size(124, 23);
            this.RequestTokenButton.TabIndex = 1;
            this.RequestTokenButton.Text = "GetRequestToken";
            this.RequestTokenButton.UseVisualStyleBackColor = true;
            this.RequestTokenButton.Click += new System.EventHandler(this.RequestTokenButton_Click);
            // 
            // VerifierButton
            // 
            this.VerifierButton.Enabled = false;
            this.VerifierButton.Location = new System.Drawing.Point(614, 41);
            this.VerifierButton.Name = "VerifierButton";
            this.VerifierButton.Size = new System.Drawing.Size(124, 23);
            this.VerifierButton.TabIndex = 2;
            this.VerifierButton.Text = "GetVerifier";
            this.VerifierButton.UseVisualStyleBackColor = true;
            this.VerifierButton.Click += new System.EventHandler(this.VerifierButton_Click);
            // 
            // webBrowserPage
            // 
            this.webBrowserPage.Location = new System.Drawing.Point(12, 12);
            this.webBrowserPage.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserPage.Name = "webBrowserPage";
            this.webBrowserPage.Size = new System.Drawing.Size(596, 517);
            this.webBrowserPage.TabIndex = 3;
            this.webBrowserPage.Visible = false;
            // 
            // VerifierTextBox
            // 
            this.VerifierTextBox.Enabled = false;
            this.VerifierTextBox.Location = new System.Drawing.Point(614, 96);
            this.VerifierTextBox.Name = "VerifierTextBox";
            this.VerifierTextBox.Size = new System.Drawing.Size(124, 20);
            this.VerifierTextBox.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(614, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Enter Verifier Code";
            // 
            // accessTokenButton
            // 
            this.accessTokenButton.Enabled = false;
            this.accessTokenButton.Location = new System.Drawing.Point(614, 131);
            this.accessTokenButton.Name = "accessTokenButton";
            this.accessTokenButton.Size = new System.Drawing.Size(124, 23);
            this.accessTokenButton.TabIndex = 6;
            this.accessTokenButton.Text = "Get Access Token";
            this.accessTokenButton.UseVisualStyleBackColor = true;
            this.accessTokenButton.Click += new System.EventHandler(this.AccessTokenButton_Click);
            // 
            // getUserInformationButton
            // 
            this.getUserInformationButton.Enabled = false;
            this.getUserInformationButton.Location = new System.Drawing.Point(614, 215);
            this.getUserInformationButton.Name = "getUserInformationButton";
            this.getUserInformationButton.Size = new System.Drawing.Size(124, 23);
            this.getUserInformationButton.TabIndex = 7;
            this.getUserInformationButton.Text = "Get User Information";
            this.getUserInformationButton.UseVisualStyleBackColor = true;
            this.getUserInformationButton.Click += new System.EventHandler(this.getUserInformationButton_Click);
            // 
            // getUserGamesButton
            // 
            this.getUserGamesButton.Enabled = false;
            this.getUserGamesButton.Location = new System.Drawing.Point(614, 244);
            this.getUserGamesButton.Name = "getUserGamesButton";
            this.getUserGamesButton.Size = new System.Drawing.Size(124, 23);
            this.getUserGamesButton.TabIndex = 8;
            this.getUserGamesButton.Text = "Get User Games";
            this.getUserGamesButton.UseVisualStyleBackColor = true;
            this.getUserGamesButton.Click += new System.EventHandler(this.getUserGamesButton_Click);
            // 
            // getUserLeaguesButton
            // 
            this.getUserLeaguesButton.Enabled = false;
            this.getUserLeaguesButton.Location = new System.Drawing.Point(614, 338);
            this.getUserLeaguesButton.Name = "getUserLeaguesButton";
            this.getUserLeaguesButton.Size = new System.Drawing.Size(124, 23);
            this.getUserLeaguesButton.TabIndex = 9;
            this.getUserLeaguesButton.Text = "Get User Leagues";
            this.getUserLeaguesButton.UseVisualStyleBackColor = true;
            this.getUserLeaguesButton.Click += new System.EventHandler(this.getUserLeaguesButton_Click);
            // 
            // gamesTextBox
            // 
            this.gamesTextBox.Enabled = false;
            this.gamesTextBox.Location = new System.Drawing.Point(614, 312);
            this.gamesTextBox.Name = "gamesTextBox";
            this.gamesTextBox.Size = new System.Drawing.Size(124, 20);
            this.gamesTextBox.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(614, 296);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Requested Games (,)";
            // 
            // getUserTeamsButton
            // 
            this.getUserTeamsButton.Enabled = false;
            this.getUserTeamsButton.Location = new System.Drawing.Point(614, 367);
            this.getUserTeamsButton.Name = "getUserTeamsButton";
            this.getUserTeamsButton.Size = new System.Drawing.Size(124, 23);
            this.getUserTeamsButton.TabIndex = 12;
            this.getUserTeamsButton.Text = "Get User Teams";
            this.getUserTeamsButton.UseVisualStyleBackColor = true;
            this.getUserTeamsButton.Click += new System.EventHandler(this.getUserTeamsButton_Click);
            // 
            // leagueIdTextBox
            // 
            this.leagueIdTextBox.Enabled = false;
            this.leagueIdTextBox.Location = new System.Drawing.Point(614, 425);
            this.leagueIdTextBox.Name = "leagueIdTextBox";
            this.leagueIdTextBox.Size = new System.Drawing.Size(124, 20);
            this.leagueIdTextBox.TabIndex = 13;
            // 
            // requestedLeagueLabel
            // 
            this.requestedLeagueLabel.AutoSize = true;
            this.requestedLeagueLabel.Location = new System.Drawing.Point(614, 409);
            this.requestedLeagueLabel.Name = "requestedLeagueLabel";
            this.requestedLeagueLabel.Size = new System.Drawing.Size(98, 13);
            this.requestedLeagueLabel.TabIndex = 14;
            this.requestedLeagueLabel.Text = "Requested League";
            // 
            // getLeagueInfoButton
            // 
            this.getLeagueInfoButton.Enabled = false;
            this.getLeagueInfoButton.Location = new System.Drawing.Point(614, 506);
            this.getLeagueInfoButton.Name = "getLeagueInfoButton";
            this.getLeagueInfoButton.Size = new System.Drawing.Size(124, 23);
            this.getLeagueInfoButton.TabIndex = 15;
            this.getLeagueInfoButton.Text = "Get League Info";
            this.getLeagueInfoButton.UseVisualStyleBackColor = true;
            this.getLeagueInfoButton.Click += new System.EventHandler(this.getLeagueInfoButton_Click);
            // 
            // subresourceTextBox
            // 
            this.subresourceTextBox.Enabled = false;
            this.subresourceTextBox.Location = new System.Drawing.Point(614, 480);
            this.subresourceTextBox.Name = "subresourceTextBox";
            this.subresourceTextBox.Size = new System.Drawing.Size(124, 20);
            this.subresourceTextBox.TabIndex = 16;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(614, 464);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Subresource";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 553);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subresourceTextBox);
            this.Controls.Add(this.getLeagueInfoButton);
            this.Controls.Add(this.requestedLeagueLabel);
            this.Controls.Add(this.leagueIdTextBox);
            this.Controls.Add(this.getUserTeamsButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gamesTextBox);
            this.Controls.Add(this.getUserLeaguesButton);
            this.Controls.Add(this.getUserGamesButton);
            this.Controls.Add(this.getUserInformationButton);
            this.Controls.Add(this.accessTokenButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.VerifierTextBox);
            this.Controls.Add(this.webBrowserPage);
            this.Controls.Add(this.VerifierButton);
            this.Controls.Add(this.RequestTokenButton);
            this.Controls.Add(this.mainTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox mainTextBox;
        private System.Windows.Forms.Button RequestTokenButton;
        private System.Windows.Forms.Button VerifierButton;
        private System.Windows.Forms.WebBrowser webBrowserPage;
        private System.Windows.Forms.TextBox VerifierTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button accessTokenButton;
        private System.Windows.Forms.Button getUserInformationButton;
        private System.Windows.Forms.Button getUserGamesButton;
        private System.Windows.Forms.Button getUserLeaguesButton;
        private System.Windows.Forms.TextBox gamesTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button getUserTeamsButton;
        private System.Windows.Forms.TextBox leagueIdTextBox;
        private System.Windows.Forms.Label requestedLeagueLabel;
        private System.Windows.Forms.Button getLeagueInfoButton;
        private System.Windows.Forms.TextBox subresourceTextBox;
        private System.Windows.Forms.Label label3;

    }
}