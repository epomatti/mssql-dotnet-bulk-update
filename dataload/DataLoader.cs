using System.Data;
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
      this.CreateOrganizations();
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

  private void CreateOrganizations()
  {
    Console.WriteLine("\nCreating Organizations...");
    int orgsQuty = Int32.Parse(Environment.GetEnvironmentVariable("ORGANIZATIONS")!);
    string prefix = "ORG_";

    // Create a SqlDataAdapter.  
    SqlDataAdapter adapter = new SqlDataAdapter();

    // Set the INSERT command and parameter.  
    adapter.InsertCommand = new SqlCommand("INSERT INTO Organization (Name) VALUES (@Name);", connection);
    adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, prefix);
    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

    // Set the batch size.  
    adapter.UpdateBatchSize = 100;

    // Execute the update.  
    DataTable dataTable = new DataTable("Organization");
    int updated = adapter.Update(dataTable);
    Console.WriteLine("Organizations created: {0}", updated);
  }

}
