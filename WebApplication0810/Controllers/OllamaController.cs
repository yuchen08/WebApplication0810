using Microsoft.AspNetCore.Mvc;
using WebApplication0810.Service;

namespace WebApplication0810.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OllamaController : ControllerBase
    {
        [HttpGet("{question}")]
        public async Task<ActionResult<string>> GetById(string question)
        {
            QuestionAnswerService OllamaService = new QuestionAnswerService();
            return Ok(await OllamaService.GetAnswerAsync(question));
        }
    }
}
