using System.Text.Json;
using application.interfaces;
using domain.models;

namespace infrastructure.Repositories;

public class ProductRepository(IFileStorage fileStorage) : IProductRepository
{
    private readonly JsonSerializerOptions _options = new()
    {
        PropertyNameCaseInsensitive = true,
        WriteIndented = true
    };

    public bool AddProducts(IList<Product> products) => SaveProducts([.. products]);

    public IList<Product> GetAllProducts() => LoadProducts();

    private List<Product> LoadProducts()
    {
        try
        {
            var json = fileStorage.Read();

            if (string.IsNullOrWhiteSpace(json))
            {
                return [];
            }

            return JsonSerializer.Deserialize<List<Product>>(json, _options) ?? [];
        }
        catch { return []; }
    }

    private bool SaveProducts(List<Product> products)
    {
        try
        {
            var json = JsonSerializer.Serialize(products, _options);
            fileStorage.Write(json);
            return true;
        }
        catch
        {
            return false;
        }
    }
}
