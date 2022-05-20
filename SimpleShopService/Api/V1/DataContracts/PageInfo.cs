using System.Runtime.Serialization;

namespace SimpleShopService.Api.V1.DataContracts;

[DataContract]
public class PageInfo
{
    [DataMember]
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItemCount { get; set; }
}