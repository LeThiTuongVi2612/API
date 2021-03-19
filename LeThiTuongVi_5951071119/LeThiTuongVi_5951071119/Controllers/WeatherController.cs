using LeThiTuongVi_5951071119.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LeThiTuongVi_5951071119.Controllers
{
    public class WeatherController : ApiController
    {
        // GET: api/Weather
        public IEnumerable<WeatherInfo> Get()
        {
            var weatherInfList = new List<WeatherInfo>();
            for(int i =0; i<10; i++)
            {
                var weatherInfo = new WeatherInfo
                {
                    Location = $"Location {i}",
                    Degree = i * 23 / 17,
                    dateTime = DateTime.Now.ToUniversalTime()
                };
                weatherInfList.Add(weatherInfo);

            }
            return weatherInfList;
        }

        // GET: api/Weather/5
        public WeatherInfo Get(int id)
        {
            return new WeatherInfo { 
                Location = $"Location {id}",
                Degree = id*23/17,
                dateTime = DateTime.Now.ToUniversalTime()
            };
        }

       
    }
}
