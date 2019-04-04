using Newtonsoft.Json;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;

namespace time.engine.integration
{
    public static class HttpClientHelpers
    {
        public static async Task<ApiResponse<T>> ExecuteGetRequest<T>(this HttpClient client, string url)
        {
            var response = await client.GetAsync(url);

            return await ReadResponse<T>(response);

        }

        public static async Task<ApiResponse<TOut>> ExecutePostRequest<TOut, TIn>(this HttpClient client, string url, TIn contentBody)
        {
            var response = await client.PostAsJsonAsync(url, contentBody);
            var result = await ReadResponse<TOut>(response);
            return result;
        }

        private static async Task<ApiResponse<T>> ReadResponse<T>(HttpResponseMessage response)
        {
            T data;
            var responseBody = await response.Content.ReadAsStringAsync();
            if (IsSuccess(response.StatusCode))
            {
                data = JsonConvert.DeserializeObject<T>(responseBody);
                return new ApiResponse<T> { StatusCode = response.StatusCode, Data = data };
            }

            return new ApiResponse<T> { StatusCode = response.StatusCode, ErrorMessage = responseBody };
        }

        private static bool IsSuccess(HttpStatusCode statusCode)
        {
            return HttpStatusCode.OK <= statusCode && statusCode < HttpStatusCode.MultipleChoices;
        }
    }
}
