using CustomersEncode.Models;
using System.Data;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using ExcelDataReader;
using System.Linq;
using System.Text;
using GemBox.Spreadsheet;
using Aspose.Cells;


namespace CustomersEncode.Controllers
{
    public class ExcelController
    {

        /// Initialize variables
        StorageFile _CustomersListFile, _TombolaListFile, _EditCustomersListFile, _NewCustomersListFile;
        HashSet<Customer> _CustomersSet = new HashSet<Customer>();
        Dictionary<Customer, int> _CustomersIndex = new Dictionary<Customer, int>();

        public ExcelController()
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
            _TombolaListFile = new StorageFile() { FullPathExcel = @"C:\FoireDuVin2024\Tombola.xls", FullPathCSV = @"C:\FoireDuVin2024\Tombola.csv" };
            _NewCustomersListFile = new StorageFile() { FullPathExcel = @"C:\FoireDuVin2024\NouveauxClients.xls", FullPathCSV = @"C:\FoireDuVin2024\NouveauxClients.csv" };
            _EditCustomersListFile = new StorageFile() { FullPathExcel = @"C:\FoireDuVin2024\ClientsAModifier.xls", FullPathCSV = @"C:\FoireDuVin2024\ClientsAModifier.csv" };
            CreateFiles();
        }

        /// <summary>
        /// Will create directory to the files containing users data
        /// Excel to see clearly information
        /// CSV to save data 
        /// </summary>
        private void CreateFiles()
        {
            // See if files exist or no and create them
            // Directory
            if (!Directory.Exists(@"C:\FoireDuVin2024"))
                Directory.CreateDirectory(@"C:\FoireDuVin2024");

            //Excel files
            if (!File.Exists(_TombolaListFile.FullPathExcel))
            {
                var tombolaWorkbook = new ExcelFile();
                tombolaWorkbook.Worksheets.Add("Tombola");
                tombolaWorkbook.Save(_TombolaListFile.FullPathExcel);
            }
            if (!File.Exists(_NewCustomersListFile.FullPathExcel))
            {
                var tombolaWorkbook = new ExcelFile();
                tombolaWorkbook.Worksheets.Add("Nouveaux Clients");
                tombolaWorkbook.Save(_NewCustomersListFile.FullPathExcel);
            }
            if (!File.Exists(_EditCustomersListFile.FullPathExcel))
            {
                var tombolaWorkbook = new ExcelFile();
                tombolaWorkbook.Worksheets.Add("Clients Modifiés");
                tombolaWorkbook.Save(_EditCustomersListFile.FullPathExcel);
            }

            byte[] csvBytes = Encoding.UTF8.GetBytes("Nom;Prenom;Adresse;Code_Postal;Localite;Mail");
            //Emergency files
            if (!File.Exists(_TombolaListFile.FullPathCSV))
            {
                FileStream TombolaFile = new FileStream(_TombolaListFile.FullPathCSV, FileMode.Create);
                TombolaFile.Write(csvBytes, 0, csvBytes.Length);
                TombolaFile.Close();
            }
            if (!File.Exists(_NewCustomersListFile.FullPathCSV))
            {
                FileStream NewUsersFile = new FileStream(_NewCustomersListFile.FullPathCSV, FileMode.Create);
                NewUsersFile.Write(csvBytes, 0, csvBytes.Length);
                NewUsersFile.Close();
            }
            if (!File.Exists(_EditCustomersListFile.FullPathCSV))
            {
                FileStream CustomerToEditFile = new FileStream(_EditCustomersListFile.FullPathCSV, FileMode.Create);
                CustomerToEditFile.Write(csvBytes, 0, csvBytes.Length);
                CustomerToEditFile.Close();
            }
            if (_CustomersListFile != null && !File.Exists(_CustomersListFile.FullPathCSV))
            {
                FileStream CustomersFile = new FileStream(_CustomersListFile.FullPathCSV, FileMode.Create);
                CustomersFile.Write(csvBytes, 0, csvBytes.Length);
                CustomersFile.Close();
            }
        }

        /// <summary>
        /// Will write a customer to an Excel file, based on an add type
        /// </summary>
        /// <returns>The customers set to update the view</returns>
        /// <param name="customer">customer to add</param>
        /// <param name="addType">Type of add to switch on</param>
        /// <param name="customerToEdit">If it's an update, we need the old customer information to found it</param>
        public HashSet<Customer> WorkUserOnExcel(Customer customer, AddUserTypeEnum addType, Customer customerToEdit = null)
        {
            //Call "CreateFiles" function to be sure saving data
            CreateFiles();
            int index = 0;
            Workbook workbook = null;
            string path = "";
            switch (addType)
            {
                case AddUserTypeEnum.NEWONE:
                    // Add to files "New Customers" (Excel)
                    AddInWorkbook(customer, _NewCustomersListFile.FullPathExcel);

                    // Add in the full list file (== file imported)
                    path = _CustomersListFile.FullPathExcel;
                    workbook = new Workbook(path);
                    index = _CustomersIndex.Count;
                    _CustomersSet.Add(customer);
                    break;
                case AddUserTypeEnum.TOMBOLA:
                    // The comments works well but it's preferable the following
                    /*path = _TombolaListFile.FullPathExcel;
                    workbook = new Workbook(path);
                    index = workbook.Worksheets[0].Cells.Rows.Count;
                    if (index < 0) index = 0;
                    break;*/
                    AddInWorkbook(customer, _TombolaListFile.FullPathExcel);
                    return _CustomersSet;
                case AddUserTypeEnum.EDIT:
                    // Add to file "Edited Customers" Excel)
                    AddInWorkbook(customer, _EditCustomersListFile.FullPathExcel);

                    return EditUser(customer, customerToEdit);
                default:
                    path = _CustomersListFile.FullPathExcel;
                    workbook = new Workbook(path);
                    index = _CustomersIndex.Count;
                    _CustomersSet.Add(customer);
                    break;
            }
            var worksheet = workbook.Worksheets[0];

            // Write user info
            worksheet.Cells[index, 0].Value = customer.Name;
            worksheet.Cells[index, 1].Value = customer.FirstName;
            worksheet.Cells[index, 2].Value = customer.Address;
            worksheet.Cells[index, 3].Value = customer.PostalCode;
            worksheet.Cells[index, 4].Value = customer.Locality;
            worksheet.Cells[index, 5].Value = customer.Mail;

            // Remove useless advertissement worksheets
            for(int i = 1; i < workbook.Worksheets.Count; i++) workbook.Worksheets.RemoveAt(i);
            
            workbook.Save(path);

            //if (addType == AddUserTypeEnum.NEWONE) //following code
            _CustomersIndex.Add(customer, index);

            return _CustomersSet;
        }

        /// <summary>
        /// Append a customer in a workbook specified
        /// </summary>
        /// <param name="customer">Customer to add</param>
        /// <param name="path">Path to the Workbook (== excel file)</param>
        private void AddInWorkbook(Customer customer, string path)
        {
            Workbook workbook = new Workbook(path);
            int index = workbook.Worksheets[0].Cells.Rows.Count;
            if(index < 0) index = 0;
            var worksheet = workbook.Worksheets[0];

            // Write user info
            worksheet.Cells[index, 0].Value = customer.Name;
            worksheet.Cells[index, 1].Value = customer.FirstName;
            worksheet.Cells[index, 2].Value = customer.Address;
            worksheet.Cells[index, 3].Value = customer.PostalCode;
            worksheet.Cells[index, 4].Value = customer.Locality;
            worksheet.Cells[index, 5].Value = customer.Mail;

            // Remove useless advertissement worksheets
            for (int i = 1; i < workbook.Worksheets.Count; i++) workbook.Worksheets.RemoveAt(i);

            workbook.Save(path);
        }

        /// <summary>
        /// Will write a new customer in the file given
        /// </summary>
        /// <param name="customer">Customer information</param>
        /// <param name="addType">Type of the add to switch on it</param>
        public void WorkUserOnCSV(Customer customer, AddUserTypeEnum addType)
        {
            //Call "CreateFiles" function to be sure saving data
            CreateFiles();
            string csvCustomer = customer.ToCSV();
            switch (addType)
            {
                case AddUserTypeEnum.NEWONE:
                    FileStream csvUsersFile = new FileStream(_CustomersListFile.FullPathCSV, FileMode.Append);
                    csvUsersFile.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length);
                    csvUsersFile.Close();
                    // Write to keep the new one (could use as mergency files too)
                    FileStream csvNewUsersFile = new FileStream(_NewCustomersListFile.FullPathCSV, FileMode.Append);
                    csvNewUsersFile.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length);
                    csvNewUsersFile.Close();
                    break;
                case AddUserTypeEnum.TOMBOLA:
                    FileStream csvTombolaFile = new FileStream(_TombolaListFile.FullPathCSV, FileMode.Append);
                    csvTombolaFile.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length);
                    csvTombolaFile.Close();
                    break;
                case AddUserTypeEnum.EDIT:
                    FileStream csvEditUserFile = new FileStream(_EditCustomersListFile.FullPathCSV, FileMode.Append);
                    csvEditUserFile.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length);
                    csvEditUserFile.Close();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Function will allow to edit the collection to show to the user.
        /// Moreover, the Excel file imported will be edited
        /// </summary>
        /// <param name="customer">Customer updated</param>
        /// <param name="customerToEdit">Needed to get the customer in our collection</param>
        private HashSet<Customer> EditUser(Customer customer, Customer customerToEdit)
        {
            var workbook = new Workbook(_CustomersListFile.FullPathExcel);
            var worksheet = workbook.Worksheets[0];
            int index = _CustomersIndex.First(kv => kv.Key.Mail.Equals(customerToEdit.Mail) && kv.Key.Name.Equals(customerToEdit.Name) && kv.Key.FirstName.Equals(customerToEdit.FirstName)).Value - 1;

            worksheet.Cells[index, 0].Value = customer.Name;
            worksheet.Cells[index, 1].Value = customer.FirstName;
            worksheet.Cells[index, 2].Value = customer.Address;
            worksheet.Cells[index, 3].Value = customer.PostalCode;
            worksheet.Cells[index, 4].Value = customer.Locality;
            worksheet.Cells[index, 5].Value = customer.Mail;

            for (int i = 1; i < workbook.Worksheets.Count; i++) workbook.Worksheets.RemoveAt(i);

            workbook.Save(_CustomersListFile.FullPathExcel);

            Customer customerStored = _CustomersSet.First(c => c.Mail.Equals(customerToEdit.Mail) && c.FirstName.Equals(customerToEdit.FirstName) && c.Name.Equals(customerToEdit.Name));

            // Delete the user to add him == update
            _CustomersSet.Remove(customerStored);
            _CustomersSet.Add(customer);

            _CustomersIndex.Remove(customerStored);
            _CustomersIndex.Add(customer, index);
            return _CustomersSet;
        }


        /// <summary>
        /// Import an excel file to get customers and put them in the collection
        /// </summary>
        public HashSet<Customer> ImportUsers()
        {
            // Problem if we import a second time a excel file : 
            // The program said that we can't write because this one is in progress..
            OpenFileDialog file = new OpenFileDialog();
            file.Filter = "Excel Files|*.xls;*.xlsx;*.xlsm";
            if (file.ShowDialog() == DialogResult.OK)
            {
                /// Check if it's an excel file
                string fileExt = Path.GetExtension(file.FileName);
                if (fileExt.CompareTo(".xls") == 0 || fileExt.CompareTo(".xlsx") == 0)
                {

                    _CustomersIndex.Clear();
                    _CustomersSet.Clear();
                    // Create the CSV file to save data
                    string extension = Path.GetExtension(file.FileName);
                    string directoryCSV = file.FileName.Substring(0, file.FileName.Length - extension.Length) + ".csv";

                    LoadCollections(file.FileName, directoryCSV);
                }
                else
                {
                    MessageBox.Show("Sélectionnez un fichier Excel uniquement !", "Erreur !", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return _CustomersSet;
        }

        private void LoadCollections(string filePath, string directoryCSV)
        {
            if (File.Exists(directoryCSV)) File.Delete(directoryCSV);

            // Variable index == customer index in the XLS
            int index = 1;

            FileStream usersFileCSV = new FileStream(directoryCSV, FileMode.Create);
            // Write header
            byte[] csvBytes = Encoding.UTF8.GetBytes("Nom;Prenom;Adresse;Code_Postal;Localite;Mail");
            usersFileCSV.Write(csvBytes, 0, csvBytes.Length);
            usersFileCSV.Close();

            _CustomersListFile = new StorageFile() { FullPathExcel = Path.GetFullPath(filePath), FullPathCSV = directoryCSV };
            DataTable dtExcel = ReadExcel(filePath);

            // For every customer, we get information to set them in the collection and add them in the CSV
            foreach (DataRow row in dtExcel.Rows)
            {
                // Get customer object
                var name = GetNextValue(row, 0);
                var firstName = GetNextValue(row, 1);
                var address = GetNextValue(row, 2);
                var postalCode = GetNextValue(row, 3);
                var locality = GetNextValue(row, 4);
                var mail = GetNextValue(row, 5);
                var customer = new Customer { Name = name, FirstName = firstName, Address = address, PostalCode = postalCode, Locality = locality, Mail = mail };

                // Add it to the index table
                _CustomersIndex.Add(customer, index);

                // Write it in CSV
                string csvCustomer = customer.ToCSV();
                FileStream usersListCSV = new FileStream(directoryCSV, FileMode.Append);
                usersListCSV.Write(Encoding.UTF8.GetBytes(csvCustomer + "\n"), 0, customer.ToCSV().Length);
                usersListCSV.Close();
                _CustomersSet.Add(customer);
                index++;
            }
            MessageBox.Show("Les données ont bien été importées !\nVeuillez ne plus toucher ce fichier !\nOu relancer l'application pour le recharger !", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// this method will read the excel file and copy its data into a datatable
        /// </summary>
        /// <param name="fileName">name of the file</param>
        /// <returns>DataTable of the Users</returns>
        private DataTable ReadExcel(string fileName)
        {
            var stream = File.Open(fileName, FileMode.Open, FileAccess.Read);
            var reader = ExcelReaderFactory.CreateReader(stream);
            var result = reader.AsDataSet();
            var tables = result.Tables.Cast<DataTable>();
            foreach (var table in tables)
            {
                stream.Close();
                return table;
            }
            stream.Close();
            return null;
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
            }
            catch (IndexOutOfRangeException)
            {
                //There's no value in this case so we return an empty string !
                return "-";
            }
        }

    }
}
