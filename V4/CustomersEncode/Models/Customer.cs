using System;

namespace CustomersEncode.Models
{
    public class Customer
    {

        public string Name { get; set; }
        public string FirstName { get; set; }
        public string Mail { get; set; }
        public string Address { get; set; }
        public string Locality { get; set; }
        public string PostalCode { get; set; }


        public string ToCSV()
        {
            return string.Format("\n{0};{1};{2};{3};{4};{5} ", Name, FirstName, Address, PostalCode, Locality, Mail);
        }

        public string[] AsTab()
        {
            return new string[] { Name, FirstName, Address, PostalCode, Locality, Mail };
        }
    }
}
