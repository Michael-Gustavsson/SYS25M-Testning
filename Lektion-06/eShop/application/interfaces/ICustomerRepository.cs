using domain.models;

namespace application.interfaces;

public interface ICustomerRepository
{
    bool AddCustomer(Customer customer);
    IList<Customer> GetAllCustomers();
}
