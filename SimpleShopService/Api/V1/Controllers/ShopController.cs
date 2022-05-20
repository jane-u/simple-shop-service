using System.Net;
using Microsoft.AspNetCore.Mvc;
using SimpleShopService.Api.V1.DataContracts;
using SimpleShopService.Api.V1.DataContracts.Shop.Parameters;
using SimpleShopService.Domain.Shop;

namespace SimpleShopService.Api.V1.Controllers;

[ApiController]
[Route("api/{version:apiVersion}/shop/stock-items")]
[ApiVersion("1.0")]
public class ShopController : ControllerBase
{
    private readonly IStockItemsProvider stockItemsProvider;
    private readonly ILogger<ShopController> logger;

    public ShopController(
        IStockItemsProvider stockItemsProvider,
        ILogger<ShopController> logger)
    {
        this.stockItemsProvider = stockItemsProvider;
        this.logger = logger;
    }

    [HttpGet]
    [ProducesResponseType(typeof(GetStockItemsResponse), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public async Task<ActionResult<GetStockItemsResponse>> GetStockItems([FromQuery] GetStockItemsRequest request)
    {
        var pageNumber = request.PageNumber;
        var pageSize = request.PageSize;

        logger.LogInformation($"GetStockItems: page number {pageNumber}, page size {pageSize}");

        var (stockItems, totalItemCount) = await stockItemsProvider.GetStockItems(pageNumber, pageSize);

        logger.LogInformation($"GetStockItems: {stockItems.Count} stock items has been found for a page. Total: {totalItemCount}");

        var response = new GetStockItemsResponse
        {
            StockItems = stockItems,
            PageInfo = new PageInfo
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalItemCount = totalItemCount
            }
        };

        return Ok(response);
    }
}
