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
    bool run = Boolean.Parse(Environment.GetEnvironmentVariable("INSERT_ORGANIZATIONS")!);
    if (run == false)
    {
      Console.WriteLine("\nSkipping organizations...");
      return;
    }

    Console.WriteLine("\nCreating Organizations...");
    int batchSize = Int32.Parse(Environment.GetEnvironmentVariable("ORGANIZATIONS_BATCH_SIZE")!);
    int orgsQuty = Int32.Parse(Environment.GetEnvironmentVariable("ORGANIZATIONS")!);
    string prefix = "My Organization ";

    DataTable dataTable = new DataTable("Organizations");
    DataColumn Name = new DataColumn("name");
    dataTable.Columns.Add(Name);

    for (int i = 0; i < orgsQuty; i++)
    {
      string n = i.ToString().PadLeft(3, '0');
      dataTable.Rows.Add(prefix + n);
    }

    SqlDataAdapter adapter = new SqlDataAdapter();

    adapter.InsertCommand = new SqlCommand("INSERT INTO Organizations (name) VALUES (@Name);", connection);
    adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "name");
    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

    adapter.UpdateBatchSize = batchSize;

    int updated = adapter.Update(dataTable);
    Console.WriteLine("Organizations created: {0}", updated);
  }

}
