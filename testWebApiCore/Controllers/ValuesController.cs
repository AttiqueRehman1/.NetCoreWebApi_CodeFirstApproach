using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Data.SqlClient;
using testWebApiCore.Models;

namespace testWebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        public ValuesController()
        {
            // Initialize the random number generator
            random = new Random();
        }

        string connectionString = "Server=DESKTOP-1V7B2VI;Database=mydatabase;Integrated Security=True;";
        private readonly Random random;


        [HttpGet]
        [Route("GetRandomNumber")]
        public IActionResult GetRandomNumber()
        {
            int randomNumber = random.Next();
            return Ok(randomNumber);
        }

        [HttpGet]
        [Route("createTable")]
        public IActionResult createTable()
        {
            try
            {

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string query = "CREATE TABLE Employe (Id INT, Name VARCHAR(50))";
                    using (SqlCommand command = new SqlCommand(query, con))
                    {
                        command.ExecuteNonQuery();
                        return Ok("Table create success");
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }


        }


        [HttpPost]
        [Route("addDataIntoDB")]
        public IActionResult AddDataIntoDB(string firstName, string lastName, string email, string phone)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "INSERT INTO Customer (FirstName, LastName, Email, phoneNumber) VALUES (@FirstName, @LastName, @Email, @phoneNumber)";

                try
                {
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);
                        command.Parameters.AddWithValue("@Email", email);
                        command.Parameters.AddWithValue("@phoneNumber", phone);
                        command.ExecuteNonQuery();

                    }
                    return Ok("Add Data Successfully...");
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return BadRequest("bad req");
        }

        [HttpGet]
        [Route("retriveALlDataFromCusttomer")]
        public IActionResult RetriveALlDataFromCusttomer()
        {
            List<CustomerModel> customers = new List<CustomerModel>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Customer";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                CustomerModel customer = new CustomerModel
                                {
                                    Id = (int)reader["id"],
                                    FirstName = (string)reader["FirstName"],
                                    LastName = (string)reader["LastName"],
                                    Email = (string)reader["Email"],
                                    Phone = (string)reader["phoneNumber"]

                                };

                                customers.Add(customer);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception or log the error message
                        Console.WriteLine($"An error occurred while executing the SQL command: {ex.Message}");
                    }
                }
            }
            var a = customers.Where(c => c.Phone.StartsWith("123")).First();
            var b = customers.Last();
            var lastFiveCustomers = customers.Skip(Math.Max(0, customers.Count - 5)).Take(5).ToList();

            var customersInRange = customers.Where(c => c.Id >= 30 && c.Id <= 40).Select(c => new CustomerModel
            {
                Id = c.Id,
                FirstName = c.FirstName,
                LastName = c.LastName.Trim(),
                Email = c.Email.Trim(),
                Phone = c.Phone
            }).ToList();





            string frmt = string.Join(Environment.NewLine, lastFiveCustomers.Select(c => $"Id: {c.Id} | Name: {c.FirstName,-20} | Phone: {c.Phone}").Distinct());
            string frmt2 = string.Join(Environment.NewLine, $" Id :{b.Id} | Name : {b.FirstName,-20} | Phone : {b.Phone}  ");

            string formattedOutput = string.Join(Environment.NewLine, customers.Select(c => $"ID: {c.Id,-10} | Name: {c.FirstName,-10} {c.LastName,-10} | Email: {c.Email,-20} | Phone: {c.Phone,-15}"));
            return Ok(customersInRange);
        }

        [HttpGet]
        [Route("getMax")]
        public IActionResult getMax()
        {
            List<int> list = new List<int> { 1, 2, 3, 4, 5, 19, 29, 18, 20 };
            int max = 0;
            for (int i = 0; i < list.Count; i++)
            {
                if (max < list[i])
                {
                    max = list[i];
                }

            }
            return Ok(max);
        }
        [HttpGet]
        [Route("login")]
        public IActionResult Login(string name)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Employee WHERE Name = @Name";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);

                    try
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string id = reader["ID"].ToString();
                                string employeeName = reader["Name"].ToString();
                                string department = reader["Department"].ToString();

                                if (employeeName == "nadia")
                                {
                                    return Ok("Valid user");
                                }
                                else
                                {
                                    return BadRequest("Invalid user");
                                }
                            }
                            else
                            {
                                return BadRequest("User not found");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Handle the exception or log the error message
                        Console.WriteLine($"An error occurred while executing the SQL command: {ex.Message}");
                        return BadRequest("Something went wrong");
                    }
                }
            }
        }



    }



}


