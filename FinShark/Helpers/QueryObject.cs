namespace FinShark.Helpers;

public class QueryObject
{
    public string? Symbol { get; set; } = null;
    public string? CompanyName { get; set; } = null;
    public string? SortBy { get; set; } = null;
    public bool IsSortAscending { get; set; } = false;
    
}