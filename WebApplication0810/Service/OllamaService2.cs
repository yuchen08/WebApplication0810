using OllamaSharp;
using System;
using System.Threading.Tasks;

namespace WebApplication0810.Service
{
    public class QuestionAnswerService
    {
        private readonly string _ollamaBaseUrl;
        private readonly string _model;

        public QuestionAnswerService()
        {
            _ollamaBaseUrl = "http://localhost:11434"; // Ollama 服务地址
            _model = "llama3.2:latest"; // 使用的模型
        }

        public async Task<string> GetAnswerAsync(string prompt)
        {
            var ollama = new OllamaApiClient(_ollamaBaseUrl)
            {
                SelectedModel = _model
            };
            var chat = new Chat(ollama);
            try
            {
                var responseStream = chat.SendAsync(prompt);
                string fullResponse = "";

                await foreach (var response in responseStream)
                {
                    fullResponse += response;
                }

                return fullResponse;
            }
            catch (Exception ex)
            {
                // 记录错误日志（可选）
                return $"出错了: {ex.Message}";
            }
        }
    }
}
