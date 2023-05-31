namespace testWebApiCore.Models
{
    public class Employee
    {

        public Employee(string name, string email, string phone, string address)
        {
            Name = name;
            Email = email;
            Phone = phone;
            Address = address;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
    }
}
