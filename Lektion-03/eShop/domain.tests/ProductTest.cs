using FluentAssertions;

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
    public void ShouldHavePropertiesMatchingConstructorArguments()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);

        // Act...

        // Assert...
        Assert.Equal("AA-12345", product.ItemNumber);
        Assert.Equal("Spikpistol", product.Name);
        Assert.Equal(4995, product.Price);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateNameIsNull()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
        // Act...
        ArgumentException ex = Assert.Throws<ArgumentException>(() => product.Update(itemNumber: "AA-12345", name: null, price: 4995));

        // Assert...
        Assert.Equal("Namn saknas", ex.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateNameIsEmpty()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
        // Act...
        Action action = () => product.Update(itemNumber: "AA-12345", name: "", price: 4995);
        // Assert...
        Assert.Throws<ArgumentException>(action);
    }

    [Theory]
    [InlineData("S")]
    [InlineData("Sp")]
    [InlineData("Spi")]
    [InlineData("Spik")]
    public void ShouldThrowArgumentExceptionWhenUpdateNameHasInvalidCharacters(string name)
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
        // Act...

        // Assert...
        Action action = () => product.Update(itemNumber: "AA-12345", name: name, price: 4995);
        // Assert.Throws<ArgumentException>(() => product.Update(itemNumber: "AA-12345", name: "Spik", price: 4995));
        action.Should().Throw<ArgumentException>().WithMessage("Namn måste vara minst 5 tecken");
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateItemNumberIsNull()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
        // Act...

        // Assert...
        Assert.Throws<ArgumentException>(() => product.Update(itemNumber: null, name: "Spikpistol", price: 4995));
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateItemNumberIsEmpty()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
        // Act...

        // Assert...
        Assert.Throws<ArgumentException>(() => product.Update(itemNumber: "", name: "Spikpistol", price: 4995));
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateItemNumberHasInvalidCharacters()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
        // Act...

        // Assert...
        Assert.Throws<ArgumentException>(() => product.Update(itemNumber: "AA-123", name: "Spikpistol", price: 4995));
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateHasNegativePrice()
    {
        // Arrange...
        var product = new Product(itemNumber: "AA-12345", name: "Spikpistol", price: 4995);
        // Act...

        // Assert...
        Assert.Throws<ArgumentException>(() => product.Update(itemNumber: "AA-12345", name: "Spikpistol", price: -1));
    }

}
