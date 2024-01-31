using CustomersEncode.Forms;
using CustomersEncode.Models;
using IronXL;
using SixLabors.ImageSharp.ColorSpaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace CustomersEncode
{
    public partial class MainForm : Form
    {
        HashSet<Customer> CustomersSet = new HashSet<Customer>();

        public MainForm()
        {
            InitializeComponent();
            CustomersListView.Scrollable = true;
            // See if files exist or no and create them

            // Directory
            if (!Directory.Exists(@"C:\FoireDuVin2024"))
                Directory.CreateDirectory(@"C:\FoireDuVin2024");

            //Excel files
            if (!File.Exists(@"C:\FoireDuVin2024\Tombola.xls"))
            {
                FileStream TombolaFile = new FileStream(@"C:\FoireDuVin2024\Tombola.xls", FileMode.Create);
                TombolaFile.Close();
            }
            if (!File.Exists(@"C:\FoireDuVin2024\ClientsAModifier.xls"))
            {
                FileStream CustomerToEditFile = new FileStream(@"C:\FoireDuVin2024\ClientsAModifier.xls", FileMode.Create);
                CustomerToEditFile.Close();
            }
            if (!File.Exists(@"C:\FoireDuVin2024\NouveauxClients.xls"))
            {
                FileStream NewCustomerile = new FileStream(@"C:\FoireDuVin2024\NouveauxClients.xls", FileMode.Create);
                NewCustomerile.Close();
            }

            byte[] csvBytes = Encoding.UTF8.GetBytes("Nom;Prenom;Adresse;Code_Postal;Localite;Mail");
            //Emergency files
            if (!File.Exists(@"C:\FoireDuVin2024\Tombola.csv"))
            {
                FileStream TombolaFile = new FileStream(@"C:\FoireDuVin2024\Tombola.csv", FileMode.Create);
                TombolaFile.Write(csvBytes, 0, csvBytes.Length);
                TombolaFile.Close();
            }
            if (!File.Exists(@"C:\FoireDuVin2024\ClientsAModifier.csv"))
            {
                FileStream CustomerToEditFile = new FileStream(@"C:\FoireDuVin2024\ClientsAModifier.csv", FileMode.Create);
                CustomerToEditFile.Write(csvBytes, 0, csvBytes.Length);
                CustomerToEditFile.Close();
            }
            if (!File.Exists(@"C:\FoireDuVin2024\NouveauxClients.csv"))
            {
                FileStream NewCustomerile = new FileStream(@"C:\FoireDuVin2024\NouveauxClients.csv", FileMode.Create);
                NewCustomerile.Write(csvBytes, 0, csvBytes.Length);
                NewCustomerile.Close();
            }
        }


        /// <summary>
        /// Import an excel file to get customers and put them in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportExcelButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            if (file.ShowDialog() == DialogResult.OK)
            {
                string fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {
                    CustomersSet.Clear();
                    this.Enabled = false;
                    try
                    {
                        DataTable dtExcel = ReadExcel(file.FileName);
                        foreach(DataRow row in dtExcel.Rows )
                        {
                            var name = GetNextValue(row, 0);
                            var firstName = GetNextValue(row, 1);
                            var address = GetNextValue(row, 2);
                            var postalCode = GetNextValue(row, 3);
                            var locality = GetNextValue(row, 4);
                            var mail = GetNextValue(row, 5);
                            var customer = new Customer{ name = name, firstName = firstName, address = address, postalCode = postalCode, locality = locality, mail = mail };

                            CustomersSet.Add(customer);
                        }
                        this.Enabled = true;
                        MessageBox.Show("Les données ont bien été importées !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message.ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Sélectionnez un fichier Excel uniquement !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Read the next case in the row of the excel file.
        /// </summary>
        /// <param name="currentRow"></param>
        /// <param name="index"></param>
        /// <returns>the string value of the next case</returns>
        private string GetNextValue(DataRow currentRow, int index)
        {
            try
            {
                return currentRow[index].ToString();
            } catch (IndexOutOfRangeException)
            {
                //There's no value in this case so we return an empty string !
                return "-";
            }
        }

        /// <summary>
        /// this method will read the excel file and copy its data into a datatable
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>DataTable of the Users</returns>
        private DataTable ReadExcel(string fileName)
        {
            WorkBook workbook = WorkBook.Load(fileName);
            WorkSheet sheet = workbook.DefaultWorkSheet;
            return sheet.ToDataTable();
        }

        private void AddTombolaButton_Click(object sender, EventArgs e)
        {
            AddUserToTombola();
            ShowSuccessOperationAdd();
        }

        private void AddUserAndTombolaButton_Click(object sender, EventArgs e)
        {
            AddUserToTombola();

            var customer = GetCustomer();
            try
            {
                //Excel part
                WorkBook workBook = WorkBook.Load(@"C:\FoireDuVin2024\NouveauxClients.xls");
                WorkSheet workSheet = workBook.DefaultWorkSheet;
                int rowNumber = workSheet.PhysicalRowCount + 1;
                workSheet["A" + rowNumber].Value = customer.name;
                workSheet["B" + rowNumber].Value = customer.firstName;
                workSheet["C" + rowNumber].Value = customer.address;
                workSheet["D" + rowNumber].Value = customer.postalCode;
                workSheet["E" + rowNumber].Value = customer.locality;
                workSheet["F" + rowNumber].Value = customer.mail;
                workBook.Save();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier \"ClientsAModifier.xls\" n'a pas été trouvé dans \"C:\\FoireDuVin2024\"\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Le chemin \"C:\\FoireDuVin2024\" n'a pas été trouvé.\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Save the information that we wanted to add
                //CSV part
                string csvCustomer = customer.ToCSV();
                try
                { 
                    FileStream fl = new FileStream(@"C:\FoireDuVin2024\NouveauxClients.csv", FileMode.Append);
                    fl.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length + 1);
                    fl.Close();
                    ShowSuccessOperationAdd();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Le fichier \"NouveauxClients.csv\" n'a pas été trouvé dans \"C:\\FoireDuVin2024\"\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            AddUserToTombola();

            var customer = GetCustomer();
            try
            {
                //Excel part
                WorkBook workBook = WorkBook.Load(@"C:\FoireDuVin2024\ClientsAModifier.xls");
                WorkSheet workSheet = workBook.DefaultWorkSheet;
                int rowNumber = workSheet.PhysicalRowCount + 1;
                workSheet["A" + rowNumber].Value = customer.name;
                workSheet["B" + rowNumber].Value = customer.firstName;
                workSheet["C" + rowNumber].Value = customer.address;
                workSheet["D" + rowNumber].Value = customer.postalCode;
                workSheet["E" + rowNumber].Value = customer.locality;
                workSheet["F" + rowNumber].Value = customer.mail;
                workBook.Save();
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier \"ClientsAModifier.xls\" n'a pas été trouvé dans \"C:\\FoireDuVin2024\"\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Le chemin \"C:\\FoireDuVin2024\" n'a pas été trouvé.\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Save the information that we wanted to add
                //CSV part
                string csvCustomer = customer.ToCSV();
                try
                {
                    FileStream fl = new FileStream(@"C:\FoireDuVin2024\ClientsAModifier.csv", FileMode.Append);
                    fl.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length + 1);
                    fl.Close();
                    ShowSuccessOperationAdd();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Le fichier \"ClientsAModifier.csv\" n'a pas été trouvé dans \"C:\\FoireDuVin2024\"\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        private void ShowSuccessOperationAdd()
        {
            MessageBox.Show("L'utilisateur a été ajouté avec succès ! ", "Information",MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAllTextsBox();
        }


        private void ClearAllTextsBox()
        {
            NameTextBox.Clear();
            FirstNameTextBox.Clear();
            AddressTextBox.Clear();
            PostalCodeTextBox.Clear();
            LocalityTextBox.Clear();
            MailTextBox.Clear();
        }

        /// <summary>
        /// Add user in the tombola CSV and Excel file
        /// </summary>
        private void AddUserToTombola()
        {
            var customer = GetCustomer();
            try
            {
                //Excel part
                WorkBook workBook = WorkBook.Load(@"C:\FoireDuVin2024\Tombola.xls");
                WorkSheet workSheet = workBook.DefaultWorkSheet;
                int rowNumber = workSheet.PhysicalRowCount + 1;
                workSheet["A" + rowNumber].Value = customer.name;
                workSheet["B" + rowNumber].Value = customer.firstName;
                workSheet["C" + rowNumber].Value = customer.address;
                workSheet["D" + rowNumber].Value = customer.postalCode;
                workSheet["E" + rowNumber].Value = customer.locality;
                workSheet["F" + rowNumber].Value = customer.mail;
                workBook.Save();
            }
            catch (DirectoryNotFoundException)
            {
                MessageBox.Show("Le chemin \"C:\\FoireDuVin2024\" n'a pas été trouvé.\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (FileNotFoundException)
            {
                MessageBox.Show("Le fichier \"Tombola.xls\" n'a pas été trouvé dans \"C:\\FoireDuVin2024\"\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (IOException ex)
            {
                MessageBox.Show("Erreur inconnue !\nError Message: " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Save the information that we wanted to add
                //CSV part
                string csvCustomer = customer.ToCSV();
                try
                {
                    FileStream fl = new FileStream(@"C:\FoireDuVin2024\Tombola.csv", FileMode.Append);
                    fl.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length);
                    fl.Close();
                }
                catch (FileNotFoundException)
                {
                    MessageBox.Show("Le fichier \"Tombola.csv\" n'a pas été trouvé dans \"C:\\FoireDuVin2024\"\nVeuillez relancer l'application où le créer vous-même !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }

        /// <summary>
        /// Get the information in the textbox
        /// </summary>
        /// <returns>the customer's object</returns>
        private Customer GetCustomer()
        {
            string name = NameTextBox.Text.Trim();
            string firstName = FirstNameTextBox.Text.Trim();
            string address = AddressTextBox.Text.Trim();
            string postalCode = PostalCodeTextBox.Text.Trim();
            string locality = LocalityTextBox.Text.Trim();
            string mail = MailTextBox.Text.Trim();
            return new Customer { name = name, firstName = firstName, address = address, postalCode = postalCode, locality = locality, mail = mail };
        }

        /// <summary>
        /// Switch cursor to hand to see it's clickable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddTombolaButton_MouseHover(object sender, EventArgs e)
        {
            AddTombolaButton.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Switch cursor to hand to see it's clickable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddUserAndTombolaButton_MouseHover(object sender, EventArgs e)
        {
            AddUserAndTombolaButton.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// Switch cursor to hand to see it's clickable
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUserButton_MouseHover(object sender, EventArgs e)
        {
            EditUserButton.Cursor = Cursors.Hand;
        }

        /// <summary>
        /// For the postalcode, we only need numbers. The function'll check and will write if it's number that are input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NumbersBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }

        private string previousSearch = "";

        /// <summary>
        /// Will search customers by name, firstname and email
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            var search = SearchTextBox.Text.ToLower().Trim();
            //If we just have added a space in the search bar, it won't search
            if (!search.Equals(previousSearch))
            {
                previousSearch = search;
                //Split space to get differents words
                string[] words = search.Split();
                CustomersListView.Items.Clear();
                int index = 1;
                if (search.Length >= 3)
                {
                    foreach (Customer customer in CustomersSet)
                    {
                        if (CustomerHasOneOfManySearch(customer, words))
                        {
                            ListViewItem lvItem = new ListViewItem("" + index);
                            lvItem.SubItems.Add(customer.name);
                            lvItem.SubItems.Add(customer.firstName);
                            lvItem.SubItems.Add(customer.address);
                            lvItem.SubItems.Add(customer.postalCode);
                            lvItem.SubItems.Add(customer.locality);
                            lvItem.SubItems.Add(customer.mail);
                            CustomersListView.Items.Add(lvItem);
                            index += 1;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Will check for a multi-reseach by name, firstname and email on a customer
        /// </summary>
        /// <param name="customer">current customer</param>
        /// <param name="words">words table</param>
        /// <returns>true if the customer has one or more words in his features</returns>
        private bool CustomerHasOneOfManySearch(Customer customer, string[] words)
        {
            //If one word in search
            if(words.Length == 1)
                return customer.firstName.ToLower().Contains(words[0]) ||
                               customer.name.ToLower().Contains(words[0]) ||
                               customer.mail.ToLower().Contains(words[0]);
            bool statement = false;
            foreach(string word in words)
            {
                statement = customer.firstName.ToLower().Contains(word) ||
                               customer.name.ToLower().Contains(word) ||
                               customer.mail.ToLower().Contains(word);
                //If no result in any of name, firstname and email => customer undesired
                //Else, it continues to check with the next word in the tab
                if(!statement)
                    return false;
            }
            return statement;
        }

        /// <summary>
        /// To add an user, we need at least the name and the firstname
        /// So buttons won't be enable if we don't have theses informations
        /// Set the color to indicate to the user that we can't use theses
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NamesTextBoxChanged(object sender, EventArgs e)
       {
            string firstName = FirstNameTextBox.Text.Trim();
            string name = NameTextBox.Text.Trim();
             if(!firstName.Equals("") && !name.Equals(""))
            {
                AddTombolaButton.BackColor = System.Drawing.Color.Chartreuse;
                AddTombolaButton.Enabled = true;
                AddUserAndTombolaButton.BackColor = System.Drawing.Color.Chartreuse;
                AddUserAndTombolaButton.Enabled = true;
                EditUserButton.BackColor = System.Drawing.Color.Chartreuse;
                EditUserButton.Enabled = true;
            } else
            {
                AddTombolaButton.BackColor = System.Drawing.Color.Red;
                AddTombolaButton.Enabled = false;
                AddUserAndTombolaButton.BackColor = System.Drawing.Color.Red;
                AddUserAndTombolaButton.Enabled = false;
                EditUserButton.BackColor = System.Drawing.Color.Red;
                EditUserButton.Enabled = false;
            }
        }

        /// <summary>
        /// Show help page to the user
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HelpButton_Click(object sender, EventArgs e)
        {
            var _HelpForm = new HelpForm();
            _HelpForm.Show();
        }

        private void HelpButton_MouseHover(object sender, EventArgs e)
        {
            HelpButton.Cursor = Cursors.Hand;
        }
    }
}
