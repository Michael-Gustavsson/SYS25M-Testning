namespace domain.tests;

public class ProductTests
{
    [Fact]
    public void ShouldCreateProductInstanceWithCorrectInitializing()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);

        // Act...

        // Assert...
        Assert.IsType<Product>(product);
    }

    [Fact]
    public void ShouldHaveProperties()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);

        // Act...

        // Assert...
        Assert.Equal("AA-12345", product.ItemNumber);
        Assert.Equal("Spikpistol", product.Name);
        Assert.Equal(4995, product.Price);
    }
}
