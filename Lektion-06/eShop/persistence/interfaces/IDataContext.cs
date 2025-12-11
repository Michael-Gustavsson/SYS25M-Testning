using MySqlConnector;

namespace persistence.interfaces;

public interface IDataContext
{
    MySqlConnection Connect(string connectionString);
    MySqlCommand CreateQuery(MySqlConnection connection);
}
