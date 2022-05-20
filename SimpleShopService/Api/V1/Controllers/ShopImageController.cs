using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace SimpleShopService.Api.V1.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/shop/stock-item-images")]
[ApiVersion("1.0")]
public class ShopImageController : Controller
{
    private readonly IHostEnvironment environment;
    private readonly ILogger<ShopImageController> logger;

    public ShopImageController(
        IHostEnvironment environment,
        ILogger<ShopImageController> logger)
    {
        this.environment = environment;
        this.logger = logger;
    }

    [HttpGet("{imageName}")]
    [ProducesResponseType((int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
    public Task<ActionResult> GetImage([FromRoute] string imageName)
    {
        logger.LogInformation($"GetImage: {imageName}");

        var path = Path.Combine(environment.ContentRootPath, "Images", imageName);

        new FileExtensionContentTypeProvider().TryGetContentType(path, out var contentType);

        if (string.IsNullOrWhiteSpace(contentType))
        {
            return Task.FromResult(NotFound() as ActionResult);
        }

        logger.LogInformation($"GetImage: content type {contentType}");

        var result = new PhysicalFileResult(path, contentType!) as ActionResult;

        return Task.FromResult(result);
    }
}