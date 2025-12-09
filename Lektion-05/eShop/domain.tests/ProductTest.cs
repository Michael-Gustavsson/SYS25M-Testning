using domain.models;
using domain.tests.fixtures;
using FluentAssertions;

namespace domain.tests;

public class ProductTests(ProductFixture fixture) : IClassFixture<ProductFixture>
{
    readonly ProductFixture fixture = fixture;

    [Fact]
    public void ShouldCreateProductInstanceWithCorrectInitializing()
    {
        // Arrange...
        // Act...
        // Assert...
        Assert.IsType<Product>(fixture.Product);
    }

    [Fact]
    public void ShouldHavePropertiesMatchingConstructorArguments()
    {
        // Arrange...
        // Act...
        // Assert...
        Assert.Equal("AA-12345", fixture.Product.ItemNumber);
        Assert.Equal("Spikpistol", fixture.Product.Name);
        Assert.Equal(4995, fixture.Product.Price);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateNameIsNull()
    {
        // Arrange...
        // Act...
        ArgumentException ex = Assert.Throws<ArgumentException>(() => fixture.Product.Update(itemNumber: "AA-12345", name: null, price: 4995));

        // Assert...
        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
        Assert.Equal("Namn saknas (Parameter 'name')", ex.Message);
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateNameIsEmpty()
    {
        // Arrange...       
        // Act...
        Action action = () => fixture.Product.Update(itemNumber: "AA-12345", name: "", price: 4995);
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
        // Act...
        // Assert...
        Action action = () => fixture.Product.Update(itemNumber: "AA-12345", name: name, price: 4995);
        action.Should().Throw<ArgumentException>().WithMessage("Namn måste vara minst 5 tecken");
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateItemNumberIsNull()
    {
        // Arrange...        
        // Act...
        // Assert...
        Assert.Throws<ArgumentException>(() => fixture.Product.Update(itemNumber: null, name: "Spikpistol", price: 4995));
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateItemNumberIsEmpty()
    {
        // Arrange...        
        // Act...
        // Assert...
        Assert.Throws<ArgumentException>(() => fixture.Product.Update(itemNumber: "", name: "Spikpistol", price: 4995));
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateItemNumberHasInvalidCharacters()
    {
        // Arrange...        
        // Act...
        // Assert...
        Assert.Throws<ArgumentException>(() => fixture.Product.Update(itemNumber: "AA-123", name: "Spikpistol", price: 4995));
    }

    [Fact]
    public void ShouldThrowArgumentExceptionWhenUpdateHasNegativePrice()
    {
        // Arrange...
        // Act...
        // Assert...
        Assert.Throws<ArgumentException>(() => fixture.Product.Update(itemNumber: "AA-12345", name: "Spikpistol", price: -1));
    }

    [Fact]
    public void Save_ShouldReturnTrue_When_Successful() => fixture.Product.Save().Should().BeTrue();

    // public void Save_ShouldReturnTrue_When_Successful()
    // {
    //     // Act...
    //     var result = fixture.Product.Save();

    //     // Assert...
    //     Assert.True(result);
    //     // Assert.Throws<ArgumentException>(() => fixture.Product.Save());
    // }
}
