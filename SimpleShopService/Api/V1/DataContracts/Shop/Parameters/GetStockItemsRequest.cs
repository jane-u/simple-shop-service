using System.Runtime.Serialization;

namespace SimpleShopService.Api.V1.DataContracts.Shop.Parameters;

[DataContract]
public class GetStockItemsRequest
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
}
