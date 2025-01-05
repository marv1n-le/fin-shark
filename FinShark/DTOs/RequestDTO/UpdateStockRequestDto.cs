namespace FinShark.DTOs.RequestDTO;

public class UpdateStockRequestDto
{
    public string Symbol { get; set; }
    public string CompanyName { get; set; } = string.Empty;
    public decimal Purchase { get; set; }
    public decimal LastDividend { get; set; }
    public string Industry { get; set; }
    public long MarketCap { get; set; }
}