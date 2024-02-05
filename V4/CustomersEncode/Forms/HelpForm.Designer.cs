namespace CustomersEncode.Forms
{
    partial class HelpForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HelpForm));
            this.HowItWorkTitleLabel = new System.Windows.Forms.Label();
            this.HelpTitleLabel = new System.Windows.Forms.Label();
            this.HowItWorkText = new System.Windows.Forms.Label();
            this.MainPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.WhereAreMyFilesLabel = new System.Windows.Forms.Label();
            this.WhatAreErrorsLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.MainPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // HowItWorkTitleLabel
            // 
            this.HowItWorkTitleLabel.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HowItWorkTitleLabel.Location = new System.Drawing.Point(3, 11);
            this.HowItWorkTitleLabel.Name = "HowItWorkTitleLabel";
            this.HowItWorkTitleLabel.Size = new System.Drawing.Size(707, 28);
            this.HowItWorkTitleLabel.TabIndex = 0;
            this.HowItWorkTitleLabel.Text = "Comment ça marche ?";
            this.HowItWorkTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HelpTitleLabel
            // 
            this.HelpTitleLabel.Font = new System.Drawing.Font("Perpetua Titling MT", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpTitleLabel.Location = new System.Drawing.Point(-7, 9);
            this.HelpTitleLabel.Name = "HelpTitleLabel";
            this.HelpTitleLabel.Size = new System.Drawing.Size(815, 38);
            this.HelpTitleLabel.TabIndex = 1;
            this.HelpTitleLabel.Text = "Page d\'aide";
            this.HelpTitleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // HowItWorkText
            // 
            this.HowItWorkText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.HowItWorkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HowItWorkText.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.HowItWorkText.Location = new System.Drawing.Point(28, 44);
            this.HowItWorkText.Name = "HowItWorkText";
            this.HowItWorkText.Size = new System.Drawing.Size(682, 759);
            this.HowItWorkText.TabIndex = 3;
            this.HowItWorkText.Text = resources.GetString("HowItWorkText.Text");
            // 
            // MainPanel
            // 
            this.MainPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MainPanel.AutoScroll = true;
            this.MainPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.MainPanel.Controls.Add(this.label3);
            this.MainPanel.Controls.Add(this.label1);
            this.MainPanel.Controls.Add(this.WhereAreMyFilesLabel);
            this.MainPanel.Controls.Add(this.HowItWorkTitleLabel);
            this.MainPanel.Controls.Add(this.HowItWorkText);
            this.MainPanel.Controls.Add(this.WhatAreErrorsLabel);
            this.MainPanel.Location = new System.Drawing.Point(49, 63);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(727, 459);
            this.MainPanel.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 581);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(704, 28);
            this.label1.TabIndex = 7;
            this.label1.Text = "Quelles sont les erreurs ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WhereAreMyFilesLabel
            // 
            this.WhereAreMyFilesLabel.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhereAreMyFilesLabel.Location = new System.Drawing.Point(6, 326);
            this.WhereAreMyFilesLabel.Name = "WhereAreMyFilesLabel";
            this.WhereAreMyFilesLabel.Size = new System.Drawing.Size(704, 28);
            this.WhereAreMyFilesLabel.TabIndex = 4;
            this.WhereAreMyFilesLabel.Text = "Où sont mes fichiers ?";
            this.WhereAreMyFilesLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WhatAreErrorsLabel
            // 
            this.WhatAreErrorsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WhatAreErrorsLabel.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WhatAreErrorsLabel.Location = new System.Drawing.Point(3, 634);
            this.WhatAreErrorsLabel.Name = "WhatAreErrorsLabel";
            this.WhatAreErrorsLabel.Size = new System.Drawing.Size(25, 28);
            this.WhatAreErrorsLabel.TabIndex = 6;
            this.WhatAreErrorsLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 784);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(704, 28);
            this.label2.TabIndex = 8;
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaption;
            this.label3.Location = new System.Drawing.Point(6, 775);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(679, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = ".";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 554);
            this.Controls.Add(this.MainPanel);
            this.Controls.Add(this.HelpTitleLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(816, 550);
            this.Name = "HelpForm";
            this.Text = "Page d\'aide";
            this.MainPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label HowItWorkTitleLabel;
        private System.Windows.Forms.Label HelpTitleLabel;
        private System.Windows.Forms.Label HowItWorkText;
        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.Label WhereAreMyFilesLabel;
        private System.Windows.Forms.Label WhatAreErrorsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}