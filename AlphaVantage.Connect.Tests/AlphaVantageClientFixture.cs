using AlphaVantage.Connect.Interfaces;
using AlphaVantage.Connect.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaVantage.Connect.Tests
{
    public class AlphaVantageClientFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public AlphaVantageClientFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient();
            serviceCollection.AddScoped<IAlphaVantageClient, AlphaVantageClient>();
            serviceCollection.AddScoped(x => Options.Create(new AlphaVantageClientConfiguration
            {
                ApiKey = "5D7GKXRW2H524MTV"
            }));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
