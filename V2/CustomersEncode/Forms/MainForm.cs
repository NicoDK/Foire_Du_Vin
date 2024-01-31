using CustomersEncode.Controllers;
using CustomersEncode.Forms;
using CustomersEncode.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CustomersEncode
{
    public partial class MainForm : Form
    {
        HashSet<Customer> CustomersSet = new HashSet<Customer>();
        ExcelController _ExcelController = new ExcelController();
        private string previousSearch = "";

        public MainForm()
        {
            InitializeComponent();
            CustomersListView.Scrollable = true;
        }


        /// <summary>
        /// Import an excel file to get customers and put them in the collection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImportExcelButton_Click(object sender, EventArgs e)
        {
            try
            {
                Enabled = false;
                CustomersSet = _ExcelController.ImportUsers();
            }catch (Exception ex)
            {
                MessageBox.Show("Une erreur inconnue est survenue durant l'importation du fichier EXCEL : \n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } finally
            {
                Enabled = true;
            }
        }

        private void AddTombolaButton_Click(object sender, EventArgs e)
        {
            var customer = GetCustomer();
            try
            {
                CustomersSet = _ExcelController.AddUserToExcel(customer, AddUserTypeEnum.TOMBOLA);
                if(sender != null)
                    ShowSuccessOperationAdd();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur inconnue est survenue dans l'ajout dans EXCEL :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Save the information that we wanted to add
                //CSV part
                try
                {
                    _ExcelController.AddUserToCSV(customer, AddUserTypeEnum.TOMBOLA);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inconnue est survenue pour ajouter dans le CSV :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// By clicking on this button, we will add a new customer in the list and in the tombola part
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNewUser_Click(object sender, EventArgs e)
        {
            var customer = GetCustomer();
            try
            {
                _ExcelController.AddUserToExcel(customer, AddUserTypeEnum.NEWONE);
                ShowSuccessOperationAdd();
                // after we add to tombola, perhaps he will be add 2 times if user didn't import excel file
                AddTombolaButton_Click(null, null);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Aucun fichier importé !\nImporter d'abord un fichier Excel !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur inconnue est survenue dans l'ajout dans EXCEL :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Save the information that we wanted to add
                //CSV part
                try
                {
                    _ExcelController.AddUserToCSV(customer, AddUserTypeEnum.TOMBOLA);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inconnue est survenue pour ajouter dans le CSV :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditUserButton_Click(object sender, EventArgs e)
        {
            AddTombolaButton_Click(null, null);

            var customer = GetCustomer();
            try
            {
                _ExcelController.AddUserToExcel(customer, AddUserTypeEnum.EDIT);
                ShowSuccessOperationEdit();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Aucun fichier importé !\nImporter d'abord un fichier Excel !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur inconnue est survenue dans l'ajout dans EXCEL :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Save the information that we wanted to add
                //CSV part
                try
                {
                    _ExcelController.AddUserToCSV(customer, AddUserTypeEnum.EDIT);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inconnue est survenue pour ajouter dans le CSV :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void ShowSuccessOperationAdd()
        {
            MessageBox.Show("Le client a été ajouté avec succès ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            ClearAllTextsBox();
        }

        private void ShowSuccessOperationEdit()
        {
            MessageBox.Show("Le client a été modifié avec succès ! ", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
