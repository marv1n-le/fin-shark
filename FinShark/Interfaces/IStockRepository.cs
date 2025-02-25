using FinShark.DTOs.RequestDTO;
using FinShark.Helpers;
using FinShark.Models;

namespace FinShark.Interfaces;

public interface IStockRepository
{
    Task<List<Stock>> GetAllStocks(QueryObject query);
    Task<Stock?> GetById(int id); //FisrtOrDefault can be null
    Task<Stock> CreateAsync(Stock stockModel);
    Task<Stock?> UpdateAsync(int id, UpdateStockRequestDto updateDto);
    Task<Stock?> DeleteAsync(int id);
    Task<bool> ExistAsync(int id);
}