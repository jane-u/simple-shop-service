using System.Runtime.Serialization;

namespace SimpleShopService.Api.V1.DataContracts.Shop;

[DataContract]
public class StockItem
{
    [DataMember]
    public string Sku { get; set; }

    [DataMember]
    public string Title { get; set; }

    [DataMember]
    public string Description { get; set; }

    [DataMember]
    public int Stock { get; set; }

    [DataMember]
    public string ImageUrl { get; set; }
}