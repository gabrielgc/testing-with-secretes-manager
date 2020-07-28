using System;
using System.Text.Json;
using Api.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NFluent;

namespace Api.IntegrationTest
{
    [TestClass]
    public class WeatherForecastControllerShould
    {
        private readonly AppSettings _settings;
        public WeatherForecastControllerShould()
        {
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<WeatherForecastControllerShould>()
                .AddEnvironmentVariables();


            var configuration = builder.Build();
            _settings = configuration.Get<AppSettings>();
            Console.WriteLine(JsonSerializer.Serialize(_settings));
        }

        [TestMethod]
        public void GetForecastsWhenApiKeyIsProvided()
        {
            var controller = new WeatherForecastController(_settings);
            var forecasts = controller.Get();
            Check.That(forecasts).As("Should return 5 forecasts").CountIs(5);
        }
    }
}
