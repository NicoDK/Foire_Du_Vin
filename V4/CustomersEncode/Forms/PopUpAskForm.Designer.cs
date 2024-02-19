namespace CustomersEncode.Forms
{
    partial class WarningForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WarningForm));
            this.DenyButton = new System.Windows.Forms.Button();
            this.AffirmButton = new System.Windows.Forms.Button();
            this.TextWarn = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DenyButton
            // 
            this.DenyButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.DenyButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.DenyButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.DenyButton.FlatAppearance.BorderSize = 0;
            this.DenyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DenyButton.Location = new System.Drawing.Point(312, 204);
            this.DenyButton.Name = "DenyButton";
            this.DenyButton.Size = new System.Drawing.Size(87, 50);
            this.DenyButton.TabIndex = 6;
            this.DenyButton.Text = "Non";
            this.DenyButton.UseVisualStyleBackColor = false;
            this.DenyButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // AffirmButton
            // 
            this.AffirmButton.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.AffirmButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.AffirmButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AffirmButton.FlatAppearance.BorderSize = 0;
            this.AffirmButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AffirmButton.Location = new System.Drawing.Point(89, 204);
            this.AffirmButton.Name = "AffirmButton";
            this.AffirmButton.Size = new System.Drawing.Size(87, 50);
            this.AffirmButton.TabIndex = 5;
            this.AffirmButton.Text = "Oui\r\n";
            this.AffirmButton.UseVisualStyleBackColor = false;
            this.AffirmButton.Click += new System.EventHandler(this.Button_Click);
            // 
            // TextWarn
            // 
            this.TextWarn.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextWarn.Font = new System.Drawing.Font("MS Reference Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextWarn.Location = new System.Drawing.Point(-1, 38);
            this.TextWarn.Name = "TextWarn";
            this.TextWarn.Size = new System.Drawing.Size(485, 144);
            this.TextWarn.TabIndex = 4;
            this.TextWarn.Text = "Des données sont déja présentes. \r\nSi vous chargez un nouveau fichier Excel, vous" +
    " n\'aurez plus les clients sur l\'application du fichier actuel !\r\nVoulez-vous con" +
    "tinuer ?";
            this.TextWarn.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // WarningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(484, 311);
            this.Controls.Add(this.DenyButton);
            this.Controls.Add(this.AffirmButton);
            this.Controls.Add(this.TextWarn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WarningForm";
            this.Text = "Attention";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button DenyButton;
        private System.Windows.Forms.Button AffirmButton;
        private System.Windows.Forms.Label TextWarn;
    }
}