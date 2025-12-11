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
        command.CommandText = @"INSERT INTO Customers(FirstName, LastName, Email) VALUE(@firstName, @lastName, @email)";

        command.Parameters.AddWithValue("@firstName", customer.FirstName);
        command.Parameters.AddWithValue("@lastName", customer.LastName);
        command.Parameters.AddWithValue("@email", customer.Email);

        int rowsAffected = command.ExecuteNonQuery();

        if (rowsAffected > 0) return true;

        command.Dispose();
        connection.Close();
        connection.Dispose();

        return false;
    }

    public bool DeleteCustomer(int id)
    {
        MySqlConnection connection = context.Connect(connectionString);
        connection.Open();

        MySqlCommand command = context.CreateQuery(connection);
        command.CommandText = @"DELETE FROM Customers WHERE id = @id";

        command.Parameters.AddWithValue("@id", id);

        int rowsAffected = command.ExecuteNonQuery();

        command.Dispose();
        connection.Close();
        connection.Dispose();

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

    public Customer? GetCustomerById(int id)
    {
        MySqlConnection connection = context.Connect(connectionString);
        connection.Open();

        MySqlCommand query = context.CreateQuery(connection);
        query.CommandText = @"SELECT FirstName, LastName FROM Customers WHERE id = @id";

        query.Parameters.AddWithValue("@id", id);

        MySqlDataReader reader = query.ExecuteReader();

        if (!reader.HasRows) return null;

        Customer customer = new();

        while (reader.Read())
        {
            customer.FirstName = reader.GetString(0);
            customer.LastName = reader.GetString(1);
        }

        reader.Close();
        reader.Dispose();
        query.Dispose();
        connection.Close();
        connection.Dispose();

        return customer;
    }

    public IList<Customer>? GetCustomerByLastName(string lastName)
    {
        MySqlConnection connection = context.Connect(connectionString);
        connection.Open();

        MySqlCommand query = context.CreateQuery(connection);
        query.CommandText = @"SELECT FirstName, LastName FROM Customers WHERE LastName = @lastName";

        query.Parameters.AddWithValue("@lastName", lastName);

        MySqlDataReader reader = query.ExecuteReader();

        if (!reader.HasRows) return null;

        List<Customer> customers = [];

        while (reader.Read())
        {
            Customer customer = new()
            {
                FirstName = reader.GetString(0),
                LastName = reader.GetString(1)
            };

            customers.Add(customer);
        }

        reader.Close();
        reader.Dispose();
        query.Dispose();
        connection.Close();
        connection.Dispose();

        return customers;
    }

    public bool UpdateCustomerEmail(int id, string email)
    {
        MySqlConnection connection = context.Connect(connectionString);
        connection.Open();

        MySqlCommand command = context.CreateQuery(connection);
        command.CommandText = @"UPDATE Customers SET Email = @email WHERE id = @id";

        command.Parameters.AddWithValue("@email", email);
        command.Parameters.AddWithValue("@id", id);

        int rowsAffected = command.ExecuteNonQuery();

        command.Dispose();
        connection.Close();
        connection.Dispose();

        if (rowsAffected > 0) return true;

        return false;
    }
}
