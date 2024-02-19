namespace CustomersEncode
{
    partial class MainForm
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.SearchTextBox = new System.Windows.Forms.TextBox();
            this.SearchLabel = new System.Windows.Forms.Label();
            this.CustomersListView = new System.Windows.Forms.ListView();
            this.N = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Nom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prénom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adresse = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.code_Postal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Localité = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mail = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.AddUseLabel = new System.Windows.Forms.Label();
            this.FirstNameLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.PostalCodeLabel = new System.Windows.Forms.Label();
            this.PostalCodeTextBox = new System.Windows.Forms.TextBox();
            this.AddressLabel = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.MailLabel = new System.Windows.Forms.Label();
            this.MailTextBox = new System.Windows.Forms.TextBox();
            this.LocalityLabel = new System.Windows.Forms.Label();
            this.LocalityTextBox = new System.Windows.Forms.TextBox();
            this.AddTombolaButton = new System.Windows.Forms.Button();
            this.ImportExcelButton = new System.Windows.Forms.Button();
            this.AddUserAndTombolaButton = new System.Windows.Forms.Button();
            this.EditUserButton = new System.Windows.Forms.Button();
            this.HelpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SearchTextBox
            // 
            this.SearchTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.SearchTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchTextBox.Location = new System.Drawing.Point(271, 13);
            this.SearchTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.SearchTextBox.Name = "SearchTextBox";
            this.SearchTextBox.Size = new System.Drawing.Size(352, 38);
            this.SearchTextBox.TabIndex = 0;
            this.SearchTextBox.TextChanged += new System.EventHandler(this.SearchTextBox_TextChanged);
            // 
            // SearchLabel
            // 
            this.SearchLabel.BackColor = System.Drawing.Color.Transparent;
            this.SearchLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SearchLabel.Location = new System.Drawing.Point(12, 9);
            this.SearchLabel.Name = "SearchLabel";
            this.SearchLabel.Size = new System.Drawing.Size(246, 44);
            this.SearchLabel.TabIndex = 1;
            this.SearchLabel.Text = "Rechercher client :";
            this.SearchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CustomersListView
            // 
            this.CustomersListView.AllowColumnReorder = true;
            this.CustomersListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.CustomersListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.N,
            this.Nom,
            this.Prénom,
            this.Adresse,
            this.code_Postal,
            this.Localité,
            this.Mail});
            this.CustomersListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomersListView.FullRowSelect = true;
            this.CustomersListView.HideSelection = false;
            this.CustomersListView.Location = new System.Drawing.Point(18, 77);
            this.CustomersListView.Name = "CustomersListView";
            this.CustomersListView.Size = new System.Drawing.Size(605, 533);
            this.CustomersListView.TabIndex = 2;
            this.CustomersListView.TileSize = new System.Drawing.Size(605, 30);
            this.CustomersListView.UseCompatibleStateImageBehavior = false;
            this.CustomersListView.View = System.Windows.Forms.View.Details;
            this.CustomersListView.SelectedIndexChanged += new System.EventHandler(this.CustomersListView_SelectedIndexChanged);
            // 
            // N
            // 
            this.N.Text = "N";
            this.N.Width = 30;
            // 
            // Nom
            // 
            this.Nom.Text = "Nom";
            this.Nom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Nom.Width = 100;
            // 
            // Prénom
            // 
            this.Prénom.Tag = "Prénom";
            this.Prénom.Text = "Prénom";
            this.Prénom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Prénom.Width = 100;
            // 
            // Adresse
            // 
            this.Adresse.Tag = "Adresse";
            this.Adresse.Text = "Adresse";
            this.Adresse.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Adresse.Width = 175;
            // 
            // code_Postal
            // 
            this.code_Postal.Tag = "Code postal";
            this.code_Postal.Text = "Code postal";
            this.code_Postal.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.code_Postal.Width = 100;
            // 
            // Localité
            // 
            this.Localité.Tag = "Localité";
            this.Localité.Text = "Localité";
            this.Localité.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Localité.Width = 100;
            // 
            // Mail
            // 
            this.Mail.Tag = "Mail";
            this.Mail.Text = "Mail";
            this.Mail.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Mail.Width = 345;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FirstNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameTextBox.Location = new System.Drawing.Point(682, 127);
            this.FirstNameTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(471, 38);
            this.FirstNameTextBox.TabIndex = 3;
            this.FirstNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.FirstNameTextBox.TextChanged += new System.EventHandler(this.NamesTextBoxChanged);
            // 
            // AddUseLabel
            // 
            this.AddUseLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddUseLabel.BackColor = System.Drawing.Color.Transparent;
            this.AddUseLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUseLabel.Location = new System.Drawing.Point(682, 13);
            this.AddUseLabel.Name = "AddUseLabel";
            this.AddUseLabel.Size = new System.Drawing.Size(471, 60);
            this.AddUseLabel.TabIndex = 4;
            this.AddUseLabel.Text = "Ajouter client";
            this.AddUseLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FirstNameLabel
            // 
            this.FirstNameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FirstNameLabel.BackColor = System.Drawing.Color.Transparent;
            this.FirstNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FirstNameLabel.Location = new System.Drawing.Point(682, 73);
            this.FirstNameLabel.Name = "FirstNameLabel";
            this.FirstNameLabel.Size = new System.Drawing.Size(471, 44);
            this.FirstNameLabel.TabIndex = 5;
            this.FirstNameLabel.Text = "Prénom :";
            this.FirstNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameLabel
            // 
            this.NameLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameLabel.BackColor = System.Drawing.Color.Transparent;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameLabel.Location = new System.Drawing.Point(682, 166);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(471, 44);
            this.NameLabel.TabIndex = 7;
            this.NameLabel.Text = "Nom :";
            this.NameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NameTextBox
            // 
            this.NameTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.NameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NameTextBox.Location = new System.Drawing.Point(682, 220);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(471, 38);
            this.NameTextBox.TabIndex = 6;
            this.NameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.NameTextBox.TextChanged += new System.EventHandler(this.NamesTextBoxChanged);
            // 
            // PostalCodeLabel
            // 
            this.PostalCodeLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PostalCodeLabel.BackColor = System.Drawing.Color.Transparent;
            this.PostalCodeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostalCodeLabel.Location = new System.Drawing.Point(682, 354);
            this.PostalCodeLabel.Name = "PostalCodeLabel";
            this.PostalCodeLabel.Size = new System.Drawing.Size(471, 44);
            this.PostalCodeLabel.TabIndex = 11;
            this.PostalCodeLabel.Text = "Code postal :";
            this.PostalCodeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PostalCodeTextBox
            // 
            this.PostalCodeTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.PostalCodeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PostalCodeTextBox.Location = new System.Drawing.Point(682, 408);
            this.PostalCodeTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.PostalCodeTextBox.Name = "PostalCodeTextBox";
            this.PostalCodeTextBox.Size = new System.Drawing.Size(471, 38);
            this.PostalCodeTextBox.TabIndex = 10;
            this.PostalCodeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PostalCodeTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.NumbersBox_KeyPress);
            // 
            // AddressLabel
            // 
            this.AddressLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddressLabel.BackColor = System.Drawing.Color.Transparent;
            this.AddressLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressLabel.Location = new System.Drawing.Point(682, 259);
            this.AddressLabel.Name = "AddressLabel";
            this.AddressLabel.Size = new System.Drawing.Size(471, 44);
            this.AddressLabel.TabIndex = 9;
            this.AddressLabel.Text = "Adresse :";
            this.AddressLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddressTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddressTextBox.Location = new System.Drawing.Point(682, 313);
            this.AddressTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(471, 38);
            this.AddressTextBox.TabIndex = 8;
            this.AddressTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // MailLabel
            // 
            this.MailLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MailLabel.BackColor = System.Drawing.Color.Transparent;
            this.MailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MailLabel.Location = new System.Drawing.Point(682, 541);
            this.MailLabel.Name = "MailLabel";
            this.MailLabel.Size = new System.Drawing.Size(471, 44);
            this.MailLabel.TabIndex = 15;
            this.MailLabel.Text = "Mail :";
            this.MailLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MailTextBox
            // 
            this.MailTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.MailTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MailTextBox.Location = new System.Drawing.Point(682, 595);
            this.MailTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.MailTextBox.Name = "MailTextBox";
            this.MailTextBox.Size = new System.Drawing.Size(471, 38);
            this.MailTextBox.TabIndex = 14;
            this.MailTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LocalityLabel
            // 
            this.LocalityLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LocalityLabel.BackColor = System.Drawing.Color.Transparent;
            this.LocalityLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalityLabel.Location = new System.Drawing.Point(682, 448);
            this.LocalityLabel.Name = "LocalityLabel";
            this.LocalityLabel.Size = new System.Drawing.Size(471, 44);
            this.LocalityLabel.TabIndex = 13;
            this.LocalityLabel.Text = "Localité :";
            this.LocalityLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LocalityTextBox
            // 
            this.LocalityTextBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LocalityTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocalityTextBox.Location = new System.Drawing.Point(682, 502);
            this.LocalityTextBox.Margin = new System.Windows.Forms.Padding(10);
            this.LocalityTextBox.Name = "LocalityTextBox";
            this.LocalityTextBox.Size = new System.Drawing.Size(471, 38);
            this.LocalityTextBox.TabIndex = 12;
            this.LocalityTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // AddTombolaButton
            // 
            this.AddTombolaButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddTombolaButton.BackColor = System.Drawing.Color.Red;
            this.AddTombolaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddTombolaButton.Enabled = false;
            this.AddTombolaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddTombolaButton.Location = new System.Drawing.Point(1268, 150);
            this.AddTombolaButton.Name = "AddTombolaButton";
            this.AddTombolaButton.Size = new System.Drawing.Size(180, 92);
            this.AddTombolaButton.TabIndex = 16;
            this.AddTombolaButton.Text = "Ajouter tombola";
            this.AddTombolaButton.UseVisualStyleBackColor = false;
            this.AddTombolaButton.Click += new System.EventHandler(this.AddTombolaButton_Click);
            // 
            // ImportExcelButton
            // 
            this.ImportExcelButton.AllowDrop = true;
            this.ImportExcelButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportExcelButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ImportExcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImportExcelButton.Location = new System.Drawing.Point(194, 616);
            this.ImportExcelButton.MinimumSize = new System.Drawing.Size(206, 51);
            this.ImportExcelButton.Name = "ImportExcelButton";
            this.ImportExcelButton.Size = new System.Drawing.Size(206, 51);
            this.ImportExcelButton.TabIndex = 17;
            this.ImportExcelButton.Text = "Charger fichier Excel";
            this.ImportExcelButton.UseVisualStyleBackColor = true;
            this.ImportExcelButton.Click += new System.EventHandler(this.ImportExcelButton_Click);
            // 
            // AddUserAndTombolaButton
            // 
            this.AddUserAndTombolaButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.AddUserAndTombolaButton.BackColor = System.Drawing.Color.Red;
            this.AddUserAndTombolaButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AddUserAndTombolaButton.Enabled = false;
            this.AddUserAndTombolaButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AddUserAndTombolaButton.Location = new System.Drawing.Point(1268, 337);
            this.AddUserAndTombolaButton.Name = "AddUserAndTombolaButton";
            this.AddUserAndTombolaButton.Size = new System.Drawing.Size(180, 92);
            this.AddUserAndTombolaButton.TabIndex = 18;
            this.AddUserAndTombolaButton.Text = "Créer client";
            this.AddUserAndTombolaButton.UseVisualStyleBackColor = false;
            this.AddUserAndTombolaButton.Click += new System.EventHandler(this.AddNewUser_Click);
            // 
            // EditUserButton
            // 
            this.EditUserButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.EditUserButton.BackColor = System.Drawing.Color.Red;
            this.EditUserButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EditUserButton.Enabled = false;
            this.EditUserButton.FlatAppearance.BorderColor = System.Drawing.Color.Red;
            this.EditUserButton.FlatAppearance.BorderSize = 0;
            this.EditUserButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditUserButton.Location = new System.Drawing.Point(1268, 518);
            this.EditUserButton.Name = "EditUserButton";
            this.EditUserButton.Size = new System.Drawing.Size(180, 92);
            this.EditUserButton.TabIndex = 19;
            this.EditUserButton.Text = "Modifier client";
            this.EditUserButton.UseVisualStyleBackColor = false;
            this.EditUserButton.Click += new System.EventHandler(this.EditUserButton_Click);
            // 
            // HelpButton
            // 
            this.HelpButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.HelpButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.HelpButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HelpButton.Location = new System.Drawing.Point(1526, 9);
            this.HelpButton.Name = "HelpButton";
            this.HelpButton.Size = new System.Drawing.Size(30, 27);
            this.HelpButton.TabIndex = 20;
            this.HelpButton.Text = "?";
            this.HelpButton.UseVisualStyleBackColor = true;
            this.HelpButton.Click += new System.EventHandler(this.HelpButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1568, 679);
            this.Controls.Add(this.HelpButton);
            this.Controls.Add(this.EditUserButton);
            this.Controls.Add(this.AddUserAndTombolaButton);
            this.Controls.Add(this.ImportExcelButton);
            this.Controls.Add(this.AddTombolaButton);
            this.Controls.Add(this.MailLabel);
            this.Controls.Add(this.MailTextBox);
            this.Controls.Add(this.LocalityLabel);
            this.Controls.Add(this.LocalityTextBox);
            this.Controls.Add(this.PostalCodeLabel);
            this.Controls.Add(this.PostalCodeTextBox);
            this.Controls.Add(this.AddressLabel);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.FirstNameLabel);
            this.Controls.Add(this.AddUseLabel);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.CustomersListView);
            this.Controls.Add(this.SearchLabel);
            this.Controls.Add(this.SearchTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(1400, 675);
            this.Name = "MainForm";
            this.Text = "Foire du vin - Aywaille";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox SearchTextBox;
        private System.Windows.Forms.Label SearchLabel;
        private System.Windows.Forms.ListView CustomersListView;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.Label AddUseLabel;
        private System.Windows.Forms.Label FirstNameLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.Label PostalCodeLabel;
        private System.Windows.Forms.TextBox PostalCodeTextBox;
        private System.Windows.Forms.Label AddressLabel;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Label MailLabel;
        private System.Windows.Forms.TextBox MailTextBox;
        private System.Windows.Forms.Label LocalityLabel;
        private System.Windows.Forms.TextBox LocalityTextBox;
        private System.Windows.Forms.Button AddTombolaButton;
        private System.Windows.Forms.Button ImportExcelButton;
        private System.Windows.Forms.Button AddUserAndTombolaButton;
        private System.Windows.Forms.Button EditUserButton;
        private System.Windows.Forms.ColumnHeader Prénom;
        private System.Windows.Forms.ColumnHeader Adresse;
        private System.Windows.Forms.ColumnHeader code_Postal;
        private System.Windows.Forms.ColumnHeader Localité;
        private System.Windows.Forms.ColumnHeader Mail;
        private System.Windows.Forms.ColumnHeader Nom;
        private System.Windows.Forms.ColumnHeader N;
        private System.Windows.Forms.Button HelpButton;
    }
}

