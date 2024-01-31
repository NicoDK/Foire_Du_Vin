namespace CustomersEncode.Models
{
    public class Customer
    {

        public string name { get; set; }
        public string firstName { get; set; }
        public string mail { get; set; }
        public string address { get; set; }
        public string locality { get; set; }
        public string postalCode { get; set; }


        public string ToCSV()
        {
            return string.Format("\n{0};{1};{2};{3};{4};{5} ", name, firstName, address, postalCode, locality, mail);
        }
    }
}
