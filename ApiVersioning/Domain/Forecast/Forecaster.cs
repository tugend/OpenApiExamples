using System;
using System.Collections.Generic;
using System.Linq;
using ApiVersioning.Domain.Forecast.ForecasterModels;

namespace ApiVersioning.Domain.Forecast
{
    public class Forecaster
    {
        private static readonly Random Rng = new();
        
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
                    temperatureC: Rng.Next(-20, 55),
                    summary: Summaries[Rng.Next(Summaries.Length)]));

        public IEnumerable<WeatherForecast> Get(DateTime @from, DateTime to)
        {
            return Get();
        }
    }
}