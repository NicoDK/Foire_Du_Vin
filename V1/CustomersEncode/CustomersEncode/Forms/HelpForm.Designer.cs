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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // HowItWorkTitleLabel
            // 
            this.HowItWorkTitleLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HowItWorkTitleLabel.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HowItWorkTitleLabel.Location = new System.Drawing.Point(3, 11);
            this.HowItWorkTitleLabel.Name = "HowItWorkTitleLabel";
            this.HowItWorkTitleLabel.Size = new System.Drawing.Size(721, 28);
            this.HowItWorkTitleLabel.TabIndex = 0;
            this.HowItWorkTitleLabel.Text = "Comment ça marche ?";
            this.HowItWorkTitleLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // HelpTitleLabel
            // 
            this.HelpTitleLabel.Anchor = System.Windows.Forms.AnchorStyles.Top;
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
            this.HowItWorkText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HowItWorkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HowItWorkText.Location = new System.Drawing.Point(26, 51);
            this.HowItWorkText.Name = "HowItWorkText";
            this.HowItWorkText.Size = new System.Drawing.Size(675, 289);
            this.HowItWorkText.TabIndex = 3;
            this.HowItWorkText.Text = resources.GetString("HowItWorkText.Text");
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.HowItWorkTitleLabel);
            this.panel1.Controls.Add(this.HowItWorkText);
            this.panel1.Location = new System.Drawing.Point(49, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(727, 600);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Marcellus SC", 15F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(5, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(719, 28);
            this.label1.TabIndex = 4;
            this.label1.Text = "Où sont mes fichiers ?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(26, 406);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(675, 75);
            this.label2.TabIndex = 5;
            this.label2.Text = "- Les fichiers sont placés sur le disque C: dans le dossier \"FoireDuVin2024\" (che" +
    "min = C:/FoireDuVin2024/) ;";
            // 
            // HelpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 675);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.HelpTitleLabel);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "HelpForm";
            this.Text = "HelpForm";
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label HowItWorkTitleLabel;
        private System.Windows.Forms.Label HelpTitleLabel;
        private System.Windows.Forms.Label HowItWorkText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}