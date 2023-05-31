namespace testWebApiCore.Models
{
    public class Person
    {

        public Person(string name, int age, int phone)
        {
            Name = name;
            Age = age;
            Phone = phone;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public int Phone { get; set; }


    }
}
