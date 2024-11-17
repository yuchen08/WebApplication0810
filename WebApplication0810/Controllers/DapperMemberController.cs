using Microsoft.AspNetCore.Mvc;
using WebApplication0810.Models.DapperModels;
using WebApplication0810.Service.DapperService;

namespace WebApplication0810.Controllers
{
    

    [Route("api/[controller]")]
    [ApiController]
    public class DapperMembersController : ControllerBase
    {
        private readonly DapperMemberService _memberService;

        // Constructor with dependency injection
        public DapperMembersController(DapperMemberService memberService)
        {
            _memberService = memberService;
        }

        // GET: api/members
        [HttpGet]
        public ActionResult<IEnumerable<DapperMember>> GetAllMembers()
        {
            var members = _memberService.GetAllMembers();
            return Ok(members);
        }

        // GET: api/members/{id}
        [HttpGet("{id}")]
        public ActionResult<DapperMember> GetMemberById(int id)
        {
            var member = _memberService.GetMemberById(id);

            if (member == null)
            {
                return NotFound();
            }

            return Ok(member);
        }

        // POST: api/members
        [HttpPost]
        public ActionResult AddMember([FromBody] DapperMember member)
        {
            _memberService.AddMember(member);
            return CreatedAtAction(nameof(GetMemberById), new { id = member.MemberID }, member);
        }

        // PUT: api/members/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateMember(int id, [FromBody] DapperMember member)
        {
            if (id != member.MemberID)
            {
                return BadRequest();
            }

            var existingMember = _memberService.GetMemberById(id);
            if (existingMember == null)
            {
                return NotFound();
            }

            _memberService.UpdateMember(member);
            return NoContent();
        }

        // DELETE: api/members/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMember(int id)
        {
            var member = _memberService.GetMemberById(id);
            if (member == null)
            {
                return NotFound();
            }

            _memberService.DeleteMember(id);
            return NoContent();
        }
    }

}
