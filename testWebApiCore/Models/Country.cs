namespace testWebApiCore.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; }
        public string CountryName { get; set; }
        public ICollection<Employee>? Employees { get; set; }


    }
}
