using IEXCloud.Connect.Interfaces;
using IEXCloud.Connect.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace IEXCloud.Connect.Tests
{
    public class IEXCloudClientFixture
    {
        public ServiceProvider ServiceProvider { get; private set; }

        public IEXCloudClientFixture()
        {
            var serviceCollection = new ServiceCollection();

            serviceCollection.AddHttpClient();
            serviceCollection.AddScoped<IIEXCloudClient, IEXCloudClient>();
            serviceCollection.AddScoped(x => Options.Create(new IEXCloudClientConfiguration
            {
                ApiKey = "pk_7595f9e581de4f27af76a0de3070b56b"
            }));

            ServiceProvider = serviceCollection.BuildServiceProvider();
        }
    }
}
