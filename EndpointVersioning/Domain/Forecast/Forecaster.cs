using System;
using System.Collections.Generic;
using System.Linq;
using EndpointVersioning.Domain.Forecast.ForecasterModels;

namespace EndpointVersioning.Domain.Forecast
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

        public IEnumerable<WeatherForecast> Get(DateTime @from, DateTime to)
        {
            return Get();
        }
    }
}