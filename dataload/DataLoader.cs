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
      this.CreateMessages();
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
    int orgsQty = Int32.Parse(Environment.GetEnvironmentVariable("ORGANIZATIONS_QUANTITY")!);
    string prefix = "My Organization ";

    DataTable dataTable = new DataTable("Organization");
    DataColumn Name = new DataColumn("Name");
    dataTable.Columns.Add(Name);

    for (int i = 0; i < orgsQty; i++)
    {
      string n = i.ToString().PadLeft(3, '0');
      object?[] values = {
        prefix + n
      };
      dataTable.Rows.Add(values);
    }

    SqlDataAdapter adapter = new SqlDataAdapter();

    adapter.InsertCommand = new SqlCommand("INSERT INTO Organization (Name) VALUES (@Name);", connection);
    adapter.InsertCommand.Parameters.Add("@Name", SqlDbType.NVarChar, 50, "Name");
    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

    adapter.UpdateBatchSize = batchSize;

    int updated = adapter.Update(dataTable);
    Console.WriteLine("Organizations created: {0}", updated);
  }

  private void CreateMessages()
  {
    bool run = Boolean.Parse(Environment.GetEnvironmentVariable("INSERT_MESSAGES")!);
    if (run == false)
    {
      Console.WriteLine("\nSkipping messages...");
      return;
    }

    Console.WriteLine("\nCreating Messages...");
    int batchSize = Int32.Parse(Environment.GetEnvironmentVariable("MESSAGES_BATCH_SIZE")!);
    int msgsQty = Int32.Parse(Environment.GetEnvironmentVariable("MESSAGES_QUANTITY")!);
    int orgFK = Int32.Parse(Environment.GetEnvironmentVariable("MESSAGES_ORGANIZATION_FK")!);

    DataTable dataTable = new DataTable("Message");

    DataColumn Priority = new DataColumn("Priority");
    DataColumn CreatedAt = new DataColumn("CreatedAt");
    dataTable.Columns.Add(Priority);
    dataTable.Columns.Add(CreatedAt);

    DataColumn Text01 = new DataColumn("Text01");
    DataColumn Text02 = new DataColumn("Text02");
    DataColumn Text03 = new DataColumn("Text03");
    DataColumn Text04 = new DataColumn("Text04");
    DataColumn Text05 = new DataColumn("Text05");
    DataColumn Text06 = new DataColumn("Text06");
    DataColumn Text07 = new DataColumn("Text07");
    DataColumn Text08 = new DataColumn("Text08");
    DataColumn Text09 = new DataColumn("Text09");
    DataColumn Text10 = new DataColumn("Text10");
    DataColumn Text11 = new DataColumn("Text11");
    DataColumn Text12 = new DataColumn("Text12");
    DataColumn Text13 = new DataColumn("Text13");
    DataColumn Text14 = new DataColumn("Text14");
    DataColumn Text15 = new DataColumn("Text15");
    DataColumn Text16 = new DataColumn("Text16");
    DataColumn Text17 = new DataColumn("Text17");
    DataColumn Text18 = new DataColumn("Text18");
    DataColumn Text19 = new DataColumn("Text19");
    DataColumn Text20 = new DataColumn("Text20");

    // DataColumn FKOrganization = new DataColumn("fk_organization");

    dataTable.Columns.Add(Text01);
    dataTable.Columns.Add(Text02);
    dataTable.Columns.Add(Text03);
    dataTable.Columns.Add(Text04);
    dataTable.Columns.Add(Text05);
    dataTable.Columns.Add(Text06);
    dataTable.Columns.Add(Text07);
    dataTable.Columns.Add(Text08);
    dataTable.Columns.Add(Text09);
    dataTable.Columns.Add(Text10);
    dataTable.Columns.Add(Text11);
    dataTable.Columns.Add(Text12);
    dataTable.Columns.Add(Text13);
    dataTable.Columns.Add(Text14);
    dataTable.Columns.Add(Text15);
    dataTable.Columns.Add(Text16);
    dataTable.Columns.Add(Text17);
    dataTable.Columns.Add(Text18);
    dataTable.Columns.Add(Text19);
    dataTable.Columns.Add(Text20);

    for (int i = 0; i < msgsQty; i++)
    {
      object?[] values = {
        1,
        DateTime.Now,
        "Text01",
        "Text02",
        "Text03",
        "Text04",
        "Text05",
        "Text06",
        "Text07",
        "Text08",
        "Text09",
        "Text10",
        "Text11",
        "Text12",
        "Text13",
        "Text14",
        "Text15",
        "Text16",
        "Text17",
        "Text18",
        "Text19",
        "Text20",
      };
      dataTable.Rows.Add(values);

      // dataTable.Rows.Add(orgFK);
    }

    SqlDataAdapter adapter = new SqlDataAdapter();

    var cmd = @"
    INSERT INTO Message
    (Priority, CreatedAt, Text01, Text02, Text03, Text04, Text05, Text06, Text07, Text08, Text09, Text10, Text11, Text12, Text13, Text14, Text15, Text16, Text17, Text18, Text19, Text20)
    VALUES
    (@Priority, @CreatedAt, @Text01, @Text02, @Text03, @Text04, @Text05, @Text06, @Text07, @Text08, @Text09, @Text10, @Text11, @Text12, @Text13, @Text14, @Text15, @Text16, @Text17, @Text18, @Text19, @Text20);
    ";

    adapter.InsertCommand = new SqlCommand(cmd, connection);

    adapter.InsertCommand.Parameters.Add("@Priority", SqlDbType.Int, 0, "Priority");
    adapter.InsertCommand.Parameters.Add("@CreatedAt", SqlDbType.DateTime2, 0, "CreatedAt");
    adapter.InsertCommand.Parameters.Add("@Text01", SqlDbType.NVarChar, 50, "Text01");
    adapter.InsertCommand.Parameters.Add("@Text02", SqlDbType.NVarChar, 50, "Text02");
    adapter.InsertCommand.Parameters.Add("@Text03", SqlDbType.NVarChar, 50, "Text03");
    adapter.InsertCommand.Parameters.Add("@Text04", SqlDbType.NVarChar, 50, "Text04");
    adapter.InsertCommand.Parameters.Add("@Text05", SqlDbType.NVarChar, 50, "Text05");
    adapter.InsertCommand.Parameters.Add("@Text06", SqlDbType.NVarChar, 50, "Text06");
    adapter.InsertCommand.Parameters.Add("@Text07", SqlDbType.NVarChar, 50, "Text07");
    adapter.InsertCommand.Parameters.Add("@Text08", SqlDbType.NVarChar, 50, "Text08");
    adapter.InsertCommand.Parameters.Add("@Text09", SqlDbType.NVarChar, 50, "Text09");
    adapter.InsertCommand.Parameters.Add("@Text10", SqlDbType.NVarChar, 50, "Text10");
    adapter.InsertCommand.Parameters.Add("@Text11", SqlDbType.NVarChar, 50, "Text11");
    adapter.InsertCommand.Parameters.Add("@Text12", SqlDbType.NVarChar, 50, "Text12");
    adapter.InsertCommand.Parameters.Add("@Text13", SqlDbType.NVarChar, 50, "Text13");
    adapter.InsertCommand.Parameters.Add("@Text14", SqlDbType.NVarChar, 50, "Text14");
    adapter.InsertCommand.Parameters.Add("@Text15", SqlDbType.NVarChar, 50, "Text15");
    adapter.InsertCommand.Parameters.Add("@Text16", SqlDbType.NVarChar, 50, "Text16");
    adapter.InsertCommand.Parameters.Add("@Text17", SqlDbType.NVarChar, 50, "Text17");
    adapter.InsertCommand.Parameters.Add("@Text18", SqlDbType.NVarChar, 50, "Text18");
    adapter.InsertCommand.Parameters.Add("@Text19", SqlDbType.NVarChar, 50, "Text19");
    adapter.InsertCommand.Parameters.Add("@Text20", SqlDbType.NVarChar, 50, "Text20");

    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;
    adapter.UpdateBatchSize = batchSize;

    int updated = adapter.Update(dataTable);
    Console.WriteLine("Messages created: {0}", updated);

  }

}
