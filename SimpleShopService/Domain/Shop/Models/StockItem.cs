namespace SimpleShopService.Domain.Shop.Models;

public class StockItem
{
    public string Sku { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public string ImageFileName { get; set; }
}
