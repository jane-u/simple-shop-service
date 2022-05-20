using System.Runtime.Serialization;

namespace SimpleShopService.Api.V1.DataContracts.Shop;

[DataContract]
public class StockItem
{
    public string Sku { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Stock { get; set; }
    public string ImageUrl { get; set; }
}