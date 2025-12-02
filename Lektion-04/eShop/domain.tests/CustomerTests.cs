namespace domain.tests;

public class CustomerTests(CustomerFixture fixture) : IClassFixture<CustomerFixture>
{
    readonly CustomerFixture fixture = fixture;

    [Fact]
    public void ShouldCreateAnInstanceOfCustomer()
    {
        Assert.IsType<Customer>(fixture.Customer);
    }

    [Fact]
    public void CustomerShouldHaveCorrectInitializedProperties()
    {
        Assert.Equal("", fixture.Customer.FirstName);
        Assert.Equal("", fixture.Customer.LastName);
        Assert.Equal("", fixture.Customer.Email);
        Assert.Equal("", fixture.Customer.Phone);
    }

    [Fact]
    public void SaveShouldReturnTrueWhenSuccessful()
    {
        // Act...
        fixture.Customer.FirstName = "Michael";
        fixture.Customer.LastName = "Gustavsson";
        fixture.Customer.Email = "michael@gmail.com";

        var result = fixture.Customer.Save();
        Assert.True(result);
    }

    [Fact]
    public void SaveShouldThrowArgumentExceptionWhenDataIsMissing()
    {
        // Act...
        fixture.Customer.FirstName = "Michael";
        fixture.Customer.LastName = "Gustavsson";
        // fixture.Customer.Email = "michael@gmail.com";
        ArgumentException ex = Assert.Throws<ArgumentException>(() => fixture.Customer.Save());

        // Assert...
        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
        Assert.Equal("Information saknas", ex.Message);
    }
}
