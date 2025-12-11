using domain.models;

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
        // Arrange...
        var customer = new Customer
        {
            // Act...
            FirstName = "Michael",
            LastName = "Gustavsson"
        };
        // fixture.Customer.FirstName = "Michael";
        // fixture.Customer.LastName = "Gustavsson";
        // fixture.Customer.Email = "michael@gmail.com";
        ArgumentException ex = Assert.Throws<ArgumentException>(()
            => customer.Save());
        // ArgumentException ex = Assert.Throws<ArgumentException>(()
        //     => fixture.Customer.Save());

        // Assert...
        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
        Assert.Equal("Information saknas", ex.Message);
    }

    [Fact]
    public void UpdateShouldReturnTrueWhenSuccessfull()
    {
        // Arrange...
        var customer = new Customer
        {
            // Act...
            LastName = "Olsson",
            Email = "nils@gmail.com"
        };
        // Act...
        // fixture.Customer.LastName = "Olsson";
        // fixture.Customer.Email = "nils@gmail.com";
        // var result = fixture.Customer.Update();
        var result = customer.Update();

        // Assert...
        Assert.True(result);
    }

    [Fact]
    public void UpdateShouldThrowArgumentExceptionWhenUnsuccessful()
    {
        // Act...
        fixture.Customer.LastName = "Olsson";
        fixture.Customer.Email = string.Empty;
        ArgumentException ex = Assert.Throws<ArgumentException>(()
            => fixture.Customer.Update());

        // Assert...
        Assert.NotNull(ex);
        Assert.IsType<ArgumentException>(ex);
        Assert.Equal("Information saknas", ex.Message);
    }
}
