namespace domain.tests;

public class ProductFixture : IDisposable
{
    public Product Product { get; set; }

    public ProductFixture()
    {
        Product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
