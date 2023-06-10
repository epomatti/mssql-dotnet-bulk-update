using Microsoft.Data.SqlClient;

DotNetEnv.Env.Load();

string connectionString = Environment.GetEnvironmentVariable("CONNECTION_STRING")!;

try
{

  using (SqlConnection connection = new SqlConnection(connectionString))
  {
    Console.WriteLine("Connecting to the SQL database...");
    connection.Open();

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
catch (SqlException e)
{
  Console.WriteLine(e.ToString());
}
// Console.WriteLine("\nDone. Press enter.");
// Console.ReadLine();
