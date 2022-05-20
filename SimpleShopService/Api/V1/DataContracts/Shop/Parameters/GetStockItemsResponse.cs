using System.Runtime.Serialization;

namespace SimpleShopService.Api.V1.DataContracts.Shop.Parameters;

[DataContract]
public class GetStockItemsResponse
{
    public IReadOnlyCollection<StockItem> StockItems { get; set; }
    public PageInfo PageInfo { get; set; }
}