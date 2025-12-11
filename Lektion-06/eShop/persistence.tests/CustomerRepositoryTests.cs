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
            LastName = "Gustavsson"
        };

        // Act...
        bool result = repo.AddCustomer(customer);

        // Assert...
        Assert.True(result);
    }
}
