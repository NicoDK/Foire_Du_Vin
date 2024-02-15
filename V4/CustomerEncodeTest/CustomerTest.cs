namespace CustomerEncodeTest
{
    public class Tests
    {

        private List<Customer> _CustomersList = new List<Customer>();

        [SetUp]
        public void Setup()
        {
            _CustomersList.AddRange(new Customer[]
            {
                new Customer(){ FirstName = "Jean", Name = "Dupont", Address = "Rue des combattans, 62", Locality = "Bruxelles", PostalCode = "1000", Mail = "jean.dupont@gmail.com"},
                new Customer(){ FirstName = "Yannick", Name = "Beaudoin", Address = "Rue des boulangers, 20", Locality = "Aywaille", PostalCode = "4920", Mail = "yannick.b@syknet.be"},
                new Customer(){ FirstName = "Yves", Name = "Georges", Address = "Avenue militaire 3", Locality = "Esneux", PostalCode = "4130", Mail = "yves.geogeo@gmail.com"},
                new Customer(){ FirstName = "Jeanne", Name = "Dupont", Address = "Rue des livreurs, 24", Locality = "Bruxelles", PostalCode = "1000", Mail = "j.dupont@skynet.be"},
                new Customer(){ FirstName = "Gregory", Name = "Annosset", Address = "Boulevard Pierret, 69", Locality = "Hamoir", PostalCode = "4080", Mail = ""},
                new Customer(){ FirstName = "Claude", Name = "Morpion", Address = "", Locality = "", PostalCode = "", Mail = "claudy.momorpion@yahoo.fr"},
                new Customer(){ FirstName = "Jan", Name = "Van Kloot", Address = "", Locality = "Ostende", PostalCode = "8400", Mail = "j.vankloot@gmail.com"},
                new Customer(){ FirstName = "Anne", Name = "Pourty", Address = "Rue des lasses, 17", Locality = "Hannut", PostalCode = "4280", Mail = "annepourty@outlook.com"},
            });
        }

        [Test]
        public void Test1()
        {
            var customer = _CustomersList[0];
            var tab = new string[] { "Dupont", "Jean", "Rue des Combattants, 62", "1000", "Bruxelles", "jean.dupont@gmail.com" };
            Assert.Equals(tab, customer.AsTab());
        }
    }
}