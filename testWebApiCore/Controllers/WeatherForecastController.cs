using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections;
using testWebApiCore.Models;

namespace testWebApiCore.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class WeatherForecastController : ControllerBase
    {
        static List<String> cityName = new List<string> { "Lahore", "ISB", "Kashmir", "KAarchi", "Multan ", "AbbotAbaad" };
        ArrayList addWeatherForcast = new ArrayList();
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        static List<cityCountry> cities = new List<cityCountry>
{
    new cityCountry { cityName = "Lahore", countryName = "Pakistan" },
    new cityCountry { cityName = "PIshawar", countryName = "Pakistan" },
    new cityCountry { cityName = "Kabul", countryName = "Afghanistan" },
          new cityCountry { cityName = "Quetta", countryName = "Pakistan" },
    new cityCountry { cityName = "London", countryName = "UK" },
    new cityCountry { cityName = "Dehli", countryName = "India" },
    new cityCountry { cityName = "TEhran", countryName = "Iran" },

};



        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();

        }


        [HttpGet]
        [Route("Test")]
        public IActionResult Test()
        {
            return Ok("Success");
        }

        [HttpGet]
        [Route("GetCityName")]
        public IActionResult CityName()
        {

            if (cityName != null)
            {

                return Ok(cityName);
            }
            return BadRequest("Bad request");
        }
        [HttpGet]
        [Route("GetCityById/{id}")]
        public IActionResult GetCityById(int id)
        {
            try
            {
                if (cityName != null)
                {
                    return Ok(cityName[id]);
                }
                return BadRequest("Bad request");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet]
        [Route("AddCity/{name}")]
        public IActionResult AddCity(string name)
        {
            try
            {

                if (name != null)
                {
                    cityName.Add(name);
                    return Ok($"city Added {cityName[cityName.Count - 1]} Successfulyy");
                }
                return BadRequest("Bad request");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        [Route("updateCity/{updateCityName}/{id}")]
        public IActionResult updateCity(string updateCityName, int id)
        {
            try
            {

                if (updateCityName != null && id >= 0 && id < cityName.Count)
                {
                    if (cityName.Contains(updateCityName))
                    {
                        return BadRequest("City name already exists in the list");
                    }

                    string oldName = cityName[id];
                    cityName[id] = updateCityName;

                    return Ok($"city updated {cityName[id]} Successfully where the oldName was {oldName}");
                }
                return BadRequest("Invalid name provided");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("deleteCity/{name}")]
        public IActionResult deleteCity(string name)
        {
            try
            {
                if (cityName != null && name != null)
                {
                    foreach (string na in cityName)
                    {
                        if (na.Equals(name))
                        {
                            cityName.Remove(name);
                            return Ok($"city deleted {name} Successfulyy ");
                        }
                    }
                    return Ok("City NAme not found");
                }
                return BadRequest("Bad request");
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("City/Search")]
        public IActionResult SearchCity(string keyword)
        {

            if (string.IsNullOrWhiteSpace(keyword))
            {
                return BadRequest("Invalid search keyword.");
            }

            List<string> matchingCities = cityName
                .Where(city => city.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            if (matchingCities.Count > 0)
            {
                return Ok(matchingCities);
            }

            return NotFound("No matching cities found.");
        }
        [HttpGet]
        [Route("City/getAllCityWithCountry")]
        public IActionResult getAllCityWithCountry()
        {
            if (cities != null)
            {
                return Ok(cities);
            }
            return BadRequest("City Data not avilable");
        }


        [HttpGet]
        [Route("City/getCityCountry")]
        public IActionResult getCountryNAme(string name)
        {

            {
                var city = cities.FirstOrDefault(c => c.cityName.Equals(name, StringComparison.OrdinalIgnoreCase));
                var country = cities.FirstOrDefault(c => c.countryName.Equals(name, StringComparison.OrdinalIgnoreCase));
                if (city != null)
                {
                    return Ok(city.countryName);
                }
                if (country != null)
                {
                    return Ok(country.cityName);
                }
                return BadRequest("City data not available");
            }

        }
        [HttpPost]
        [Route("City/addCity")]

        public IActionResult AddCity(string cityName, string countryName, string countryCode)
        {
            if (string.IsNullOrEmpty(cityName) || string.IsNullOrEmpty(countryName))
            {
                return BadRequest("Invalid parameters provided");
            }

            // Check if the city already exists in the list
            var existingCity = cities.FirstOrDefault(c => c.cityName.Equals(cityName, StringComparison.OrdinalIgnoreCase));
            if (existingCity != null)
            {
                // Check if the existing city has a null country code
                if (existingCity.countryCode == null)
                {
                    existingCity.countryCode = countryCode;
                    return Ok("Country code added successfully");
                }

                return BadRequest("City already exists in the list");
            }

            cities.Add(new cityCountry { cityName = cityName, countryName = countryName, countryCode = countryCode });

            return Ok("City added successfully");
        }
        [HttpGet]
        [Route("City/getCountryNamesStartingWithP")]
        public IActionResult GetCountryOrCityNamesStartingWith(char ch)
        {
            List<string> matchingNames = new List<string>();


            var matchingCountryNames = cities.Where
                (c => c.countryName.StartsWith(ch.ToString(), StringComparison.OrdinalIgnoreCase))
                .Select(c => c.countryName).Distinct();

            matchingNames.AddRange(matchingCountryNames);


            var matchingCityNames = cities.Where(c => c.cityName.StartsWith(ch.ToString(), StringComparison.OrdinalIgnoreCase))
                .Select(c => c.cityName).Distinct();

            matchingNames.AddRange(matchingCityNames);

            if (matchingNames.Count > 0)
            {
                return Ok(matchingNames);
            }

            return NotFound($"No country or city names starting with '{ch}' found.");
        }


    }
}

class cityCountry
{
    public string countryName { get; set; }
    public string cityName { get; set; }

    public string countryCode { get; set; }
}



