using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication0810.Models.EFModels;
using WebApplication0810.Services;

namespace WebApplication0810.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class Table0810Controller : ControllerBase
    {
        private readonly Table0810Service _service;

        public Table0810Controller(Table0810Service service)
        {
            _service = service;
        }

        // 取得所有資料
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Table0810>>> GetAll()
        {
            var items = await _service.GetAllAsync();
            return Ok(items);
        }

        // 根據 ID 取得單一資料
        [HttpGet("{id}")]
        public async Task<ActionResult<Table0810>> GetById(int id)
        {
            var item = await _service.GetByIdAsync(id);
            if (item == null)
            {
                return NotFound();
            }
            return Ok(item);
        }

        // 新增資料
        [HttpPost]
        public async Task<ActionResult<Table0810>> Create(Table0810 entity)
        {
            var createdEntity = await _service.AddAsync(entity);
            return CreatedAtAction(nameof(GetById), new { id = createdEntity.Id }, createdEntity);
        }

        // 更新資料
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Table0810 entity)
        {
            if (id != entity.Id)
            {
                return BadRequest();
            }

            await _service.UpdateAsync(entity);
            return NoContent();
        }

        // 刪除資料
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _service.GetByIdAsync(id);
            if (entity == null)
            {
                return NotFound();
            }

            await _service.DeleteAsync(id);
            return NoContent();
        }
    }
}
