using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using RestSharp;

namespace time.engine.integration
{
    public class TimeEngineWebApplicationFactory<TStartup> : WebApplicationFactory<TStartup> where TStartup : class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            base.ConfigureWebHost(builder);
        }

        public IRestClient CreateRestClient(string baseUrl = "http://localhost/")
        {
            // TODO magic
            return new RestClient(baseUrl);
        }
    }
}
