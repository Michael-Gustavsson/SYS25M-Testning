using MySqlConnector;
using persistence.interfaces;

namespace persistence;

public class DataContext : IDataContext
{
    public MySqlConnection Connect(string connectionString)
    {
        return new MySqlConnection(connectionString);
    }

    public MySqlCommand CreateQuery(MySqlConnection connection)
    {
        return connection.CreateCommand();
    }
}
