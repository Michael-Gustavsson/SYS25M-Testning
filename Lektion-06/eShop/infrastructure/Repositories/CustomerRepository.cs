using application.interfaces;
using domain.models;
using MySqlConnector;
using persistence.interfaces;

namespace infrastructure.Repositories;

public class CustomerRepository(IDataContext context, string connectionString) : ICustomerRepository
{
    public bool AddCustomer(Customer customer)
    {
        MySqlConnection connection = context.Connect(connectionString);
        connection.Open();

        MySqlCommand command = context.CreateQuery(connection);
        command.CommandText = @"INSERT INTO Customers(FirstName, LastName) VALUE(@firstName, @lastName)";

        command.Parameters.AddWithValue("@firstName", customer.FirstName);
        command.Parameters.AddWithValue("@lastName", customer.LastName);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0) return true;

        return false;
    }

    public IList<Customer> GetAllCustomers()
    {
        // var customers = new List<Customer>();
        List<Customer> customers = [];

        // Skapa en anslutning till MySql...
        // var connection = context.Connect(connectionString);
        MySqlConnection connection = context.Connect(connectionString);
        connection.Open();

        // Skapa ett fråge objekt...
        // var query = context.CreateQuery(connection);
        MySqlCommand query = context.CreateQuery(connection);
        query.CommandText = "SELECT FirstName, LastName FROM Customers;";

        // Köra frågan få tillbaka en reader...
        // var result = query.ExecuteReader();
        MySqlDataReader result = query.ExecuteReader();

        while (result.Read())
        {
            Customer customer = new()
            {
                FirstName = result.GetString(0),
                LastName = result.GetString(1)
            };

            customers.Add(customer);
        }

        result.Close();
        result.Dispose();
        query.Dispose();
        connection.Close();
        connection.Dispose();

        return customers;
    }
}
