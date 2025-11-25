using BankSystem;

namespace BankTests;

public class CustomerTests
{
    [Fact]
    public void ShouldCreateACustomerWithFirstAndLastName()
    {
        // Arrange...
        var customer = new Customer("Nisse", "Nilsson");
        // Act...

        // Assert...
        Assert.Equal("Nisse", customer.FirstName);
        Assert.Equal("Nilsson", customer.LastName);
    }

    [Fact]
    public void ShouldReturnFullname()
    {
        // Arrange...
        var customer = new Customer("Nisse", "Nilsson");

        // Act...
        var fullName = customer.FullName();

        // Assert...
        Assert.Equal("Nisse Nilsson", fullName);
    }

    [Fact]
    public void ShouldReturnFullnameRegardlessOfCasing()
    {
        // Arrange...
        var customer = new Customer("Nisse", "Nilsson");

        // Act...
        var fullName = customer.FullName();

        // Assert...
        Assert.Equal("nisse Nilsson", fullName, ignoreCase: true);
    }

    [Fact]
    public void ShouldReturnFullnameWhereFirstNameStartsWith()
    {
        // Arrange...
        var customer = new Customer("Nisse", "Nilsson");

        // Act...
        var searchCriteria = "niSSe";

        // Assert...
        Assert.StartsWith(searchCriteria, customer.FullName(),
            StringComparison.CurrentCultureIgnoreCase);

        Assert.StartsWith(searchCriteria.ToUpper(),
            customer.FullName().ToUpper());
    }

    [Fact]
    public void ShouldReturnFullnameRegardlessOfSpelling()
    {
        // Arrange...
        var customer = new Customer("Nisse", "Nilsson");

        // Act...
        customer.FirstName = "Nizze";
        customer.LastName = "Nilsson";

        // Assert...
        Assert.Matches("Ni(zz|ss)e", customer.FullName());
    }

    [Fact]
    public void ShouldReturnFullnameWhereContainsFirstNameAndLastName()
    {
        // Arrange...
        var customer = new Customer("Michael", "Gustavsson");

        // Act...

        // Assert...
        Assert.Contains("ael gu", customer.FullName(),
            StringComparison.CurrentCultureIgnoreCase);
    }
}
