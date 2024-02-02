using CustomersEncode.Models;
using System.Data;
using System;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using ExcelDataReader;
using System.Linq;
using System.Text;
using Spire.Xls;


namespace CustomersEncode.Controllers
{
    public class ExcelController
    {

        /// Initialize variables
        ExcelFile _UsersList, _TombolaList, _EditUsersList;
        HashSet<Customer> _CustomersSet = new HashSet<Customer>();
        Dictionary<Customer, int> _CustomersIndex = new Dictionary<Customer, int>();

        public ExcelController()
        {
            _TombolaList = new ExcelFile() { FullPathExcel = @"C:\FoireDuVin2024\Tombola.xls", FullPathCSV = @"C:\FoireDuVin2024\Tombola.csv" };
            _EditUsersList = new ExcelFile() { FullPathExcel = @"C:\FoireDuVin2024\ClientsAModifier.xls", FullPathCSV = @"C:\FoireDuVin2024\ClientsAModifier.csv" };
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
        }

        /// <summary>
        /// Will add a customer to an Excel file, based on an add type
        /// </summary>
        /// <returns>The customers set to update the view</returns>
        /// <param name="customer">customer to add</param>
        /// <param name="addType"></param>
        public HashSet<Customer> WorkUserOnExcel(Customer customer, AddUserTypeEnum addType, Customer customerToEdit = null)
        {
            //Call "CreateFiles" function to be sure saving data
            CreateFiles();
            Workbook workbook = new Workbook();
            string path = "";
            switch (addType)
            {
                case AddUserTypeEnum.NEWONE:
                    workbook.LoadFromFile(_UsersList.FullPathExcel);
                    path = _UsersList.FullPathExcel;
                    _CustomersSet.Add(customer);
                    break;
                case AddUserTypeEnum.TOMBOLA:
                    workbook.LoadFromFile(_TombolaList.FullPathExcel);
                    path = _TombolaList.FullPathExcel;
                    break;
                case AddUserTypeEnum.EDIT:
                    workbook.LoadFromFile(_UsersList.FullPathExcel);
                    path = _UsersList.FullPathExcel;
                    EditUser(workbook, customer, customerToEdit, path);

                    return _CustomersSet;
                default:
                    workbook.LoadFromFile(_UsersList.FullPathExcel);
                    path = _UsersList.FullPathExcel;
                    _CustomersSet.Add(customer);
                    break;
            }
            Worksheet worksheet = null;
            //Get the first one (at the moment, no visible function or arg to get easier)
            foreach (Worksheet current in workbook.Worksheets)
            {
                worksheet = current;
                break;
            }

            if (worksheet == null)
                workbook.Worksheets.Add("Customers");
            // Get the last line in the Excel file to add the customer
            int rowNumber = worksheet.LastDataRow + 1;
            string[] tab = customer.AsTab();
            worksheet.InsertArray(tab, rowNumber, 1, false);
            workbook.SaveToFile(path);
            if(addType == AddUserTypeEnum.NEWONE)
                _CustomersIndex.Add(customer, rowNumber);
            //Release resources
            workbook.Dispose();
            return _CustomersSet;
        }

        /// <summary>
        /// Will write a new customer in the file given
        /// </summary>
        /// <param name="csvFile"></param>
        /// <param name="customer"></param>
        public void WorkUserOnCSV(Customer customer, AddUserTypeEnum addType)
        {
            //Call "CreateFiles" function to be sure saving data
            CreateFiles();
            string csvCustomer = customer.ToCSV();
            switch (addType)
            {
                case AddUserTypeEnum.NEWONE:
                    FileStream csvUsersFile = new FileStream(_UsersList.FullPathCSV, FileMode.Append);
                    csvUsersFile.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length);
                    csvUsersFile.Close();
                    break;
                case AddUserTypeEnum.TOMBOLA:
                    FileStream csvTombolaFile = new FileStream(_TombolaList.FullPathCSV, FileMode.Append);
                    csvTombolaFile.Write(Encoding.UTF8.GetBytes(csvCustomer), 0, customer.ToCSV().Length);
                    csvTombolaFile.Close();
                    break;
                default:
                    break;
            }
        }

        /// <summary>
        /// Function will allow to edit the collection to show to the user.
        /// Moreover, the Excel file imported will be edited
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="customer"></param>
        /// <param name="path"></param>
        private void EditUser(Workbook workbook, Customer customer, Customer customerToEdit, string path)
        {
            Worksheet worksheet = null;
            // Get the first one (at the moment, no visible function or arg to get easier)
            foreach (Worksheet current in workbook.Worksheets)
            {
                worksheet = current;
                break;
            }
            int index = _CustomersIndex.First(kv => kv.Key.Mail.Equals(customerToEdit.Mail) && kv.Key.Name.Equals(customerToEdit.Name) && kv.Key.FirstName.Equals(customerToEdit.FirstName)).Value;
            // Insert does a replace, so don't need to delete
            worksheet.Range["A" + index].Value = customer.Name;
            worksheet.Range["B" + index].Value = customer.FirstName;
            worksheet.Range["C" + index].Value = customer.Address;
            worksheet.Range["D" + index].Value = customer.PostalCode;
            worksheet.Range["E" + index].Value = customer.Locality;
            worksheet.Range["F" + index].Value = customer.Mail;
            //worksheet.InsertArray(customer.AsTab(), keyValueCustomer.Value, 1, false);
            workbook.SaveToFile(path);



            Customer customerStored = _CustomersSet.First(c => c.Mail.Equals(customerToEdit.Mail) && c.FirstName.Equals(customerToEdit.FirstName) && c.Name.Equals(customerToEdit.Name));
            // Delete the user to add him == update
            _CustomersSet.Remove(customerStored);
            _CustomersSet.Add(customer);
        }

        /// <summary>
        /// Import an excel file to get customers and put them in the collection
        /// </summary>
        public HashSet<Customer> ImportUsers()
        {
            // Problem if we import a second time a excel file : 
            // The program said that we can't write because this one is in progress..
            OpenFileDialog file = new OpenFileDialog();
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
            if (File.Exists(directoryCSV))
                File.Delete(directoryCSV);

            // Variable index == customer index in the XLS
            int index = 1;

            FileStream usersFileCSV = new FileStream(directoryCSV, FileMode.Create);
            usersFileCSV.Close();
            _UsersList = new ExcelFile() { FullPathExcel = Path.GetFullPath(filePath), FullPathCSV = directoryCSV };
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
                return table;

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
