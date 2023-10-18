using TaskManager.BLL.Interfaces;
using System.Text;
using System.Net.Http.Headers;
using TaskManager.BLL.Models;
using Polly;
using System.Net;

namespace TaskManager.BLL.Services
{
    public class OpenAIService : IOpenAIService
    {
        private HttpClient _httpClient;

        private readonly ITaskManagerSettings _settings;

        public OpenAIService(ITaskManagerSettings settings)
        {
            _httpClient = new HttpClient();
            _settings = settings;
        }

        public async Task<string> GenerateResponse(string prompt)
        {
        var retryPolicy = Policy
            .Handle<Exception>()
            .OrResult<HttpResponseMessage>(r => !r.IsSuccessStatusCode)
            .WaitAndRetryAsync(3, retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)), (exception, timeSpan, retryCount, context) =>
            {
                if (retryCount == 3)
                {
                    Console.WriteLine("Logging after 3 failed attempts...");
                }
            });

            try
            {
                _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _settings.OpenAIKey);

                var requestBody = new
                {
                    model = _settings.ChatGBTEngine,
                    messages = new[]
                        {
                        new
                        {
                            role = "system",
                            content = $"{prompt}"
                        }
                    }
                };

                var jsonRequest = Newtonsoft.Json.JsonConvert.SerializeObject(requestBody);
                var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(_settings.OpenAIUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    var jsonResponse = await response.Content.ReadAsStringAsync();
                    ChatGBTResponse chatGBTResponse = Newtonsoft.Json.JsonConvert.DeserializeObject<ChatGBTResponse>(jsonResponse);
                    var result = chatGBTResponse.choices[0].message.content;

                    return result;
                }
                else
                {
                    var errorText = $"Error fetching data. Status code: {response.StatusCode}";
                    throw new HttpRequestException(errorText);
                }
            }
            catch (Exception error)
            {
                var errorText = $"Error fetching data: {error.Message}";
                return errorText;
            }
        }
    }
}
