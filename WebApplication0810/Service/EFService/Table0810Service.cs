using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebApplication0810.Models.EFModels;

namespace WebApplication0810.Services;

public class Table0810Service
{
    private readonly _0810Context _context;

    public Table0810Service(_0810Context context)
    {
        _context = context;
    }

    // 取得所有資料
    public async Task<IEnumerable<Table0810>> GetAllAsync()
    {
        return await _context.Table0810s.ToListAsync();
    }

    // 根據 ID 取得單一資料
    public async Task<Table0810> GetByIdAsync(int id)
    {
        return await _context.Table0810s.FindAsync(id);
    }

    // 新增資料
    public async Task<Table0810> AddAsync(Table0810 entity)
    {
        _context.Table0810s.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    // 更新資料
    public async Task UpdateAsync(Table0810 entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    // 刪除資料
    public async Task DeleteAsync(int id)
    {
        var entity = await _context.Table0810s.FindAsync(id);
        if (entity != null)
        {
            _context.Table0810s.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}