using CustomersEncode.Controllers;
using CustomersEncode.Forms;
using CustomersEncode.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CustomersEncode
{
    public partial class MainForm : Form
    {
        private HashSet<Customer> _CustomersSet;
        private ExcelController _ExcelController = new ExcelController();
        private string previousSearch = "";
        private Customer customerToEdit;

        public MainForm()
        {
            InitializeComponent();
            CustomersListView.MultiSelect = false;
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
                _CustomersSet = _ExcelController.ImportUsers();
                ClearAllTextsBox();
                ClearSearch();
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
                _ExcelController.WorkUserOnExcel(customer, AddUserTypeEnum.TOMBOLA);
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
                    _ExcelController.WorkUserOnCSV(customer, AddUserTypeEnum.TOMBOLA);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inconnue est survenue pour ajouter dans le CSV tombola :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                _ExcelController.WorkUserOnExcel(customer, AddUserTypeEnum.NEWONE);
                // after we add to tombola, perhaps he will be add 2 times if user didn't import excel file
                AddTombolaButton_Click(null, null);
                ShowSuccessOperationAdd();
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
                    _ExcelController.WorkUserOnCSV(customer, AddUserTypeEnum.NEWONE);
                }
                catch (NullReferenceException)
                {
                    //Do nothing because a message has been send already to warn the user
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inconnue est survenue pour ajouter dans le CSV :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Will call update customer function of the excel file imported
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EditUserButton_Click(object sender, EventArgs e)
        {
            // Add to tombola
            AddTombolaButton_Click(null, null);

            var customer = GetCustomer();
            try
            {
                _CustomersSet = _ExcelController.WorkUserOnExcel(customer, AddUserTypeEnum.EDIT, customerToEdit);
                ShowSuccessOperationEdit();
                EditUserButton.BackColor = System.Drawing.Color.Red;
                EditUserButton.Enabled = false;
            }
            catch (NullReferenceException)
            {
                if(_CustomersSet == null)
                    MessageBox.Show("Aucun fichier importé !\nImporter d'abord un fichier Excel !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    MessageBox.Show("Aucun utilisateur trouvé !", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Une erreur inconnue est survenue dans la modification dans EXCEL :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                //Save the information that we wanted to edit
                //CSV part
                try
                {
                    _ExcelController.WorkUserOnCSV(customer, AddUserTypeEnum.EDIT);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Une erreur inconnue est survenue pour éditer dans le CSV :\n" + ex.Message, "Erreur inconnue", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            ClearSearch();
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

        private void ClearSearch()
        {
            SearchTextBox.Clear();
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
            return new Customer { Name = name, FirstName = firstName, Address = address, PostalCode = postalCode, Locality = locality, Mail = mail };
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
            if ((e.KeyChar == '.') && ((sender as System.Windows.Forms.TextBox).Text.IndexOf('.') > -1))
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
                //Clear the listview for removing recent results
                CustomersListView.Items.Clear();
                int index = 1;
                if (search.Length >= 3)
                {
                    foreach (Customer customer in _CustomersSet)
                    {
                        // If the customer contains something in the search bar, we add him in the list view
                        if (CustomerHasOneOfManySearch(customer, words))
                        {
                            // Add customer to the listview
                            ListViewItem lvItem = new ListViewItem("" + index);
                            lvItem.SubItems.AddRange(customer.AsTab());
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
                return customer.FirstName.ToLower().Contains(words[0]) ||
                               customer.Name.ToLower().Contains(words[0]) ||
                               customer.Mail.ToLower().Contains(words[0]);
            bool statement = false;
            foreach(string word in words)
            {
                statement = customer.FirstName.ToLower().Contains(word) ||
                               customer.Name.ToLower().Contains(word) ||
                               customer.Mail.ToLower().Contains(word);
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

        private void CustomersListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CustomersListView.SelectedItems.Count == 0)
                return;
            var item = CustomersListView.SelectedItems[0];

            NameTextBox.Text = item.SubItems[1].Text;
            FirstNameTextBox.Text = item.SubItems[2].Text;
            AddressTextBox.Text = item.SubItems[3].Text;
            PostalCodeTextBox.Text = item.SubItems[4].Text;
            LocalityTextBox.Text = item.SubItems[5].Text;
            MailTextBox.Text = item.SubItems[6].Text;


            customerToEdit = _CustomersSet.First(c => c.Mail.Equals(item.SubItems[6].Text) && c.FirstName.Equals(item.SubItems[2].Text) && c.Name.Equals(item.SubItems[1].Text));

            EditUserButton.BackColor = System.Drawing.Color.Chartreuse;
            EditUserButton.Enabled = true;
        }
    }
}
