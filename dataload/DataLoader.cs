using Microsoft.Data.SqlClient;

class DataLoader
{

  private SqlConnection? connection;

  public void Run()
  {
    string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;
    using (this.connection = new SqlConnection(connectionString))
    {
      connection.Open();

      this.ConnectionTest();
    }
  }

  private void ConnectionTest()
  {
    Console.WriteLine("Testing the connection to the database...");
    String sql = "SELECT 1";

    using (SqlCommand command = new SqlCommand(sql, connection))
    {
      using (SqlDataReader reader = command.ExecuteReader())
      {
        while (reader.Read())
        {
          Console.WriteLine("Connectivity OK: {0}", reader.GetInt32(0));
        }
      }
    }
  }

}
