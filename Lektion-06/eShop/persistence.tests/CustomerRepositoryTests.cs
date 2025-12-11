using domain.models;
using infrastructure.Repositories;

namespace persistence.tests;

public class CustomerRepositoryTests
{
    private static CustomerRepository CreateRepository()
    {
        // var context = new DataContext();
        DataContext context = new();
        return new CustomerRepository(context, "server=127.0.0.1;uid=root;pwd=EWMnZS22!;database=eShopTest");
    }

    [Fact]
    public void GetAllCustomersShouldReturnAllCustomersFromDb()
    {
        // Arrange...
        CustomerRepository repo = CreateRepository();

        // Act...
        IList<Customer> result = repo.GetAllCustomers();

        // Assert...
        Assert.NotNull(result);
    }

    [Fact]
    public void AddCustomerShouldPersistCustomerToDb()
    {
        // Arrange...
        CustomerRepository repo = CreateRepository();
        // Skapa en ny kund...
        Customer customer = new()
        {
            FirstName = "Michael",
            LastName = "Gustavsson",
            Email = "mg@gmail.com"
        };

        // Act...
        bool result = repo.AddCustomer(customer);

        // Assert...
        Assert.True(result);
    }

    [Fact]
    public void FindCustomerByIdShouldReturnCustomerFromDb()
    {
        // Arrange...
        CustomerRepository repo = CreateRepository();

        // Act...
        Customer? result = repo.GetCustomerById(1);
        // Assert...
        Assert.NotNull(result);
    }

    [Fact]
    public void FindCustomerByLastShouldReturnCustomersFromDb()
    {
        // Arrange...
        CustomerRepository repo = CreateRepository();

        // Act...
        IList<Customer>? result = repo.GetCustomerByLastName("Gustavsson");

        // Assert...
        Assert.NotNull(result);
    }

    [Fact]
    public void UpdateCustomerEmailShouldUpdateCustomerToDb()
    {
        // Arrange...
        CustomerRepository repo = CreateRepository();

        // Act...
        bool result = repo.UpdateCustomerEmail(1, "michael@gmail.com");
        // Assert...
        Assert.True(result);
    }

    [Fact]
    public void DeleteCustomerShouldRemoveFromDb()
    {
        // Arrange...
        CustomerRepository repo = CreateRepository();

        // Act...
        bool result = repo.DeleteCustomer(1);

        // Assert...
        Assert.True(result);
    }
}
