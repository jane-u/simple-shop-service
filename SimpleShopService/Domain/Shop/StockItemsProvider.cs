using System.Collections.Immutable;
using SimpleShopService.Domain.Shop.Models;

namespace SimpleShopService.Domain.Shop;

public interface IStockItemsProvider
{
    Task<(IReadOnlyCollection<StockItem> stockItems, int totalItemCount)> GetStockItems(int pageNumber, int pageSize);
}

internal class StockItemsProvider : IStockItemsProvider
{
    public Task<(IReadOnlyCollection<StockItem> stockItems, int totalItemCount)> GetStockItems(int pageNumber, int pageSize)
    {
        if (pageNumber < 1 || pageSize < 1)
        {
            throw new ArgumentException($"Page number {pageNumber} or page size {pageSize} are incorrect (smaller than 1).");
        }

        var items = Items
            .Skip(pageSize * (pageNumber-1))
            .Take(pageSize)
            .ToImmutableList()
            as IReadOnlyCollection<StockItem>;

        return Task.FromResult((items, Items.Length));
    }

    private static readonly StockItem[] Items = {
        CreateStockItem("SKU_2289972", "Black sunglasses", "Nice modern black sunglasses", 5, "nice-modern-black-sunglasses.jpg"),
        CreateStockItem("SKU_5671780", "Brown sunglasses", "Brown vintage sunglasses", 3, "brown-vintage-sunglasses.jpg"),
        CreateStockItem("SKU_6505738", "Long seed-bead necklace", "Long seed-bead necklace with some embellishments", 4, "long-seed-bead-necklace-emb.jpg"),
        CreateStockItem("SKU_4971072", "White leather bag", "Small white leather bag", 0, "small-white-leather-bag.jpg"),
        CreateStockItem("SKU_1891420", "Big travel bag", "Big travel bag with wheels", 6, "big-travel-bag-with-wheels.jpg"),
        CreateStockItem("SKU_9077209", "Travel tag", "Travel tag for bags", 11, "travel-tag-for-bags.jpg"),
        CreateStockItem("SKU_4599796", "Document holder", "Document holder for travel", 98, "document-holder-for-travel.jpg"),
        CreateStockItem("SKU_3153695", "Gift bag set", "An assortment of 3 gift bags of sizes from 5 to 15 cm.", 54, "gift-bag-set-3-5-15.jpg"),
        CreateStockItem("SKU_3748623", "Sunglasses case", "Sunglasses case.", 4, "sunglasses-case.jpg"),
        CreateStockItem("SKU_2762598", "Travel sew kit", "Small travel sew kit", 8, "small-travel-sew-kit.jpg")
    };

    private static StockItem CreateStockItem(string sku, string title, string description, int stock, string imageFileName)
    {
        return new()
        {
            Sku = sku,
            Title = title,
            Description = description,
            Stock = stock,
            ImageFileName = imageFileName
        };
    }
}
