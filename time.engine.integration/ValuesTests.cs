using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using time.engine.contracts.Models.Response;
using Xunit;

namespace time.engine.integration
{
    public class ValuesTests : IClassFixture<TimeEngineWebApplicationFactory<time.engine.Startup>>
    {
        private readonly TimeEngineWebApplicationFactory<time.engine.Startup> _factory;

        public ValuesTests(TimeEngineWebApplicationFactory<time.engine.Startup> factory)
        {
            _factory = factory;
        }


        [Theory]
        [InlineData("/api/v1/values")]
        public async Task Get_ValuesReturnNotEmptyList(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var expectedItemCount = 2;

            // Act
            var response = await client.ExecuteGetRequest<List<string>>(url);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.Equal(expectedItemCount, response.Data.Count);
        }

        [Theory]
        [InlineData("/api/v1/values")]
        public async Task Post_ValuesReturnSuccess(string url)
        {
            // Arrange
            var client = _factory.CreateClient();
            var body = "test";

            // Act
            var response = await client.ExecutePostRequest<ValuesPostResponse, string>(url, body);

            // Assert
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Data);
        }

        [Theory]
        [InlineData("/api/v1/values", "")]
        [InlineData("/api/v1/values", null)]
        public async Task Post_ValuesReturnBadRequest_On_EmptyRequestBody(string url, string requestBody)
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.ExecutePostRequest<string, string>(url, requestBody);

            // Assert
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
