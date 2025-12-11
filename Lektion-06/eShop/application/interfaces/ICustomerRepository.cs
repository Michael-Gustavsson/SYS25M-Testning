using domain.models;

namespace application.interfaces;

public interface ICustomerRepository
{
    bool AddCustomer(Customer customer);
    IList<Customer> GetAllCustomers();
    Customer? GetCustomerById(int id);
    IList<Customer>? GetCustomerByLastName(string lastName);
    bool DeleteCustomer(int id);
    bool UpdateCustomerEmail(int id, string email);
}
