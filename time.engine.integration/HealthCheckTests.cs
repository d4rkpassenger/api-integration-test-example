using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace time.engine.integration
{
    public class HealthCheckTests : IClassFixture<TimeEngineWebApplicationFactory<time.engine.Startup>>
    {
        private readonly TimeEngineWebApplicationFactory<time.engine.Startup> _factory;

        public HealthCheckTests(TimeEngineWebApplicationFactory<time.engine.Startup> factory)
        {
            _factory = factory;
        }

        [Theory]
        [InlineData("/api/healthcheck")]
        public async Task Get_HealthCheck_ReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.ExecuteGetRequest<DateTime>(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotEqual(default(DateTime), response.Data);
        }
    }
}
