using Microsoft.AspNetCore.Mvc;
using WebApplication0810.Service;  // 引入你的服务命名空间
using System.Threading.Tasks;

namespace WebApplication0810.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionAnswerController : ControllerBase
    {
        private readonly QuestionAnswerService _questionAnswerService;

        // 注入 QuestionAnswerService 服务
        public QuestionAnswerController(QuestionAnswerService questionAnswerService)
        {
            _questionAnswerService = questionAnswerService;
        }

        // 定义一个 POST 接口，接受问题并返回回答
        [HttpPost("ask")]
        public async Task<IActionResult> AskQuestion([FromBody] string prompt)
        {
            if (string.IsNullOrEmpty(prompt))
            {
                return BadRequest("问题不能为空");
            }

            try
            {
                // 调用 QuestionAnswerService 获取回答
                var answer = await _questionAnswerService.GetAnswerAsync(prompt);

                // 返回结果
                return Ok(new { answer });
            }
            catch (Exception ex)
            {
                // 出现异常时返回错误信息
                return StatusCode(500, new { message = "服务器错误", error = ex.Message });
            }
        }
    }
}
