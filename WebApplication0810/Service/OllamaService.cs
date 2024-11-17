using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace WebApplication0810.Service
{
    public class OllamaService
    {
        private readonly HttpClient _httpClient;
        private readonly string _baseUrl;

        public OllamaService()
        {
            _httpClient = new HttpClient();
            _baseUrl = "http://localhost:11434"; // 設定預設的 Ollama API URL
        }

        public async Task<string> AskQuestionAsync(string question)
        {
            try
            {
                // 構建請求內容
                var requestBody = new { prompt = question };

                // 發送 POST 請求
                var response = await _httpClient.PostAsJsonAsync($"{_baseUrl}/generate", requestBody);

                if (response.IsSuccessStatusCode)
                {
                    // 解析 JSON 回應
                    var responseData = await response.Content.ReadFromJsonAsync<ResponseData>();
                    return responseData?.Answer ?? "未能獲得有效回應";
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private class ResponseData
        {
            public string Answer { get; set; }
        }
    }
}
