using System.ComponentModel.DataAnnotations.Schema;

namespace testWebApiCore.Models
{
    public class Employee
    {


        public int employeeId { get; set; }
        public int CountryId { get; set; }
        public int personId { get; set; }

        public string Email { get; set; }
        public string Designation { get; set; }
        public int Salary { get; set; }
        public string Address { get; set; }

        public Country? Country { get; set; }
        public Person? Person { get; set; }

    }
}
