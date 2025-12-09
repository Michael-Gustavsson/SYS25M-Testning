using domain.models;
namespace application.interfaces;

public interface IProductRepository
{
    bool AddProducts(IList<Product> products);
    IList<Product>? GetAllProducts();
}
