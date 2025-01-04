using FinShark.DTOs.RequestDTO;
using FinShark.Models;

namespace FinShark.Mappers;

public static class StockMapper
{
    public static StockDTO ToStockDto(this Stock stockMapperModel)
    {
        return new StockDTO
        {
            Id = stockMapperModel.Id,
            Symbol = stockMapperModel.Symbol,
            CompanyName = stockMapperModel.CompanyName,
            Purchase = stockMapperModel.Purchase,
            LastDividend = stockMapperModel.LastDividend,
            Industry = stockMapperModel.Industry,
            MarketCap = stockMapperModel.MarketCap
        };
    }

    public static Stock CreateDTO(this CreateStockRequestDto createStockRequestDto)
    {
        return new Stock
        {
            Symbol = createStockRequestDto.Symbol,
            CompanyName = createStockRequestDto.CompanyName,
            Purchase = createStockRequestDto.Purchase,
            LastDividend = createStockRequestDto.LastDividend,
            Industry = createStockRequestDto.Industry,
            MarketCap = createStockRequestDto.MarketCap
        };
    }

}