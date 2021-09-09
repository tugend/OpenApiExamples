using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace SimpleVersioning.Controllers
{
    public class Forecaster
    {
        private static readonly Random rng = new();
        
        private static readonly string[] Summaries = {
            "Freezing", 
            "Bracing", 
            "Chilly", 
            "Cool", 
            "Mild", 
            "Warm", 
            "Balmy", 
            "Hot", 
            "Sweltering", 
            "Scorching"
        };

        public IEnumerable<WeatherForecast> Get() =>
            Enumerable
                .Range(1, 5)
                .Select(index => new WeatherForecast(
                    date: DateTime.Now.AddDays(index),
                    temperatureC: rng.Next(-20, 55),
                    summary: Summaries[rng.Next(Summaries.Length)]));
    }
}