using domain.models;
using infrastructure.Repositories;
using infrastructure.Serialization;

namespace domain.tests.IntegrationTests;

public class ProductRepositoryTests
{
    private static string CreateTempFile()
    {
        var filePath = Path.GetTempFileName();
        File.WriteAllText(filePath, "[]");
        return filePath;
    }

    private static ProductRepository CreateRepository(string file)
    {
        var fileStorage = new JsonStorage(file);
        return new ProductRepository(fileStorage);
    }

    [Fact]
    public void AddProduct_ShouldPersistProducts_ToFile()
    {
        // Arrange...
        var file = CreateTempFile();
        var repo = CreateRepository(file);
        var products = new List<Product>
        {
            new("AA0001","Spikpistol",4995),
            new("AA0002","Skruvdragare",2495)
        };

        // Act...
        var result = repo.AddProducts(products);

        // Assert...
        // Gick det bra att spara?
        Assert.True(result);
        // Kontrollera så att rätt data har skrivits ner...
        var json = File.ReadAllText(file);
        Assert.Contains("\"AA0001\"", json);
        Assert.Contains("\"AA0002\"", json);
    }

    [Fact]
    public void GetAllProductsShouldReturnAllProductFromPersistence()
    {
        // Arrange...
        var file = CreateTempFile();
        var repo = CreateRepository(file);
        var products = new List<Product>
        {
            new("AA0001","Spikpistol",4995),
            new("AA0002","Skruvdragare",2495)
        };

        var result = repo.AddProducts(products);

        // Act...
        var retrievedProducts = repo.GetAllProducts();

        // Asserts...
        Assert.NotNull(retrievedProducts);
        Assert.Equal(2, retrievedProducts.Count);

        var productOne = retrievedProducts.First(c => c.ItemNumber == "AA0001");
        var productTwo = retrievedProducts.First(c => c.ItemNumber == "AA0002");

        Assert.Equal("Spikpistol", productOne.Name);
        Assert.Equal("Skruvdragare", productTwo.Name);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnEmptylist_When_FileIsEmpty()
    {
        // Arrange...
        var file = CreateTempFile();
        File.WriteAllText(file, "");

        var repo = CreateRepository(file);

        // Act...
        var retrievedProducts = repo.GetAllProducts();

        // Asserts...
        Assert.NotNull(retrievedProducts);
        Assert.Empty(retrievedProducts);
    }

    [Fact]
    public void GetAllProducts_ShouldReturnEmptylist_When_ContainsNoJson()
    {
        // Arrange...
        var file = CreateTempFile();
        File.WriteAllText(file, "<nisse>");

        var repo = CreateRepository(file);

        // Act...
        var retrievedProducts = repo.GetAllProducts();

        // Asserts...
        Assert.NotNull(retrievedProducts);
        Assert.Empty(retrievedProducts);
    }
}
