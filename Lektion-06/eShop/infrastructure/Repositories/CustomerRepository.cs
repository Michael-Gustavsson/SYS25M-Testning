using application.interfaces;
using domain.models;

namespace infrastructure.Repositories;

public class CustomerRepository : ICustomerRepository
{
    public bool AddCustomer(Customer customer)
    {
        throw new NotImplementedException();
    }

    public IList<Customer> GetAllCustomers()
    {
        throw new NotImplementedException();
    }
}
