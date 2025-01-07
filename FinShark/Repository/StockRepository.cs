using FinShark.Data;
using FinShark.DTOs.RequestDTO;
using FinShark.Helpers;
using FinShark.Interfaces;
using FinShark.Models;
using Microsoft.EntityFrameworkCore;

namespace FinShark.Repository;

public class StockRepository : IStockRepository
{
    private readonly AppDbContext _context;
    
    public StockRepository(AppDbContext context)
    {
        _context = context;
    }
    
    public async Task<List<Stock>> GetAllStocks(QueryObject query)
    {
        var stock = _context.Stocks.Include(c => c.Comments).AsQueryable();
        if (!string.IsNullOrWhiteSpace(query.CompanyName))
        {
            stock = stock.Where(x => x.CompanyName.Contains(query.CompanyName));
        }
        if (!string.IsNullOrWhiteSpace(query.Symbol))
        {
            stock = stock.Where(x => x.Symbol.Contains(query.Symbol));
        }

        return await stock.ToListAsync();
    }

    public async Task<Stock?> GetById(int id)
    {
        return await _context.Stocks.Include(c => c.Comments).FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<Stock> CreateAsync(Stock stockModel)
    {
        await _context.Stocks.AddAsync(stockModel);
        await _context.SaveChangesAsync();
        
        return stockModel;
    }

    public async Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto)
    {
        var exist = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (exist == null)
            return null;
        exist.Symbol = updateDto.Symbol;
        exist.CompanyName = updateDto.CompanyName;
        exist.Purchase = updateDto.Purchase;
        exist.LastDividend = updateDto.LastDividend;
        exist.Industry = updateDto.Industry;
        exist.MarketCap = updateDto.MarketCap;
        await _context.SaveChangesAsync();
        return exist;
        
    }

    public async Task<Stock?> DeleteAsync(int id)
    {
        var stockModel = await _context.Stocks.FirstOrDefaultAsync(x => x.Id == id);
        if (stockModel == null)
            return null;
        _context.Stocks.Remove(stockModel);
        await _context.SaveChangesAsync();
        return stockModel;
    }

    public async Task<bool> ExistAsync(int id)
    {
        return await _context.Stocks.AnyAsync(x => x.Id == id);
    }
}