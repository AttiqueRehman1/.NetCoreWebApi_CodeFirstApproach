namespace testWebApiCore.Models
{
    public class City
    {
        public int id { get; set; }
        public string name { get; set; }
        public string country { get; set; }

        public City(int id, string name, string country)
        {
            this.id = id;
            this.name = name;
            this.country = country;

        }
    }
}
