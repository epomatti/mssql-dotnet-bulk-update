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
    int orgsQty = Int32.Parse(Environment.GetEnvironmentVariable("ORGANIZATIONS_QUANTITY")!);
    string prefix = "My Organization ";

    DataTable dataTable = new DataTable("Organizations");
    DataColumn Name = new DataColumn("Name");
    dataTable.Columns.Add(Name);

    for (int i = 0; i < orgsQty; i++)
    {
      string n = i.ToString().PadLeft(3, '0');
      dataTable.Rows.Add(prefix + n);
    }

    SqlDataAdapter adapter = new SqlDataAdapter();

    adapter.InsertCommand = new SqlCommand("INSERT INTO Organizations (Name) VALUES (@Name);", connection);
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

    DataTable dataTable = new DataTable("Messages");
    DataColumn Priority = new DataColumn("priority");
    DataColumn CreationDate = new DataColumn("creation_date");
    // DataColumn CreationDate = new DataColumn("creation_date");

    DataColumn Text01 = new DataColumn("text01");
    DataColumn Text02 = new DataColumn("text02");
    DataColumn Text03 = new DataColumn("text03");
    DataColumn Text04 = new DataColumn("text04");
    DataColumn Text05 = new DataColumn("text05");
    DataColumn Text06 = new DataColumn("text06");
    DataColumn Text07 = new DataColumn("text07");
    DataColumn Text08 = new DataColumn("text08");
    DataColumn Text09 = new DataColumn("text09");
    DataColumn Text10 = new DataColumn("text10");
    DataColumn Text11 = new DataColumn("text11");
    DataColumn Text12 = new DataColumn("text12");
    DataColumn Text13 = new DataColumn("text13");
    DataColumn Text14 = new DataColumn("text14");
    DataColumn Text15 = new DataColumn("text15");
    DataColumn Text16 = new DataColumn("text16");
    DataColumn Text17 = new DataColumn("text17");
    DataColumn Text18 = new DataColumn("text18");
    DataColumn Text19 = new DataColumn("text19");
    DataColumn Text20 = new DataColumn("text20");

    DataColumn FKOrganization = new DataColumn("fk_organization");

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

    dataTable.Columns.Add(Text20);

    for (int i = 0; i < msgsQty; i++)
    {
      dataTable.Rows.Add(1); // Priority
      dataTable.Rows.Add(new DateTime()); // Created At

      dataTable.Rows.Add("text02");
      dataTable.Rows.Add("text01");
      dataTable.Rows.Add("text03");
      dataTable.Rows.Add("text04");
      dataTable.Rows.Add("text05");
      dataTable.Rows.Add("text06");
      dataTable.Rows.Add("text07");
      dataTable.Rows.Add("text08");
      dataTable.Rows.Add("text09");
      dataTable.Rows.Add("text10");
      dataTable.Rows.Add("text11");
      dataTable.Rows.Add("text12");
      dataTable.Rows.Add("text13");
      dataTable.Rows.Add("text14");
      dataTable.Rows.Add("text15");
      dataTable.Rows.Add("text16");
      dataTable.Rows.Add("text17");
      dataTable.Rows.Add("text18");
      dataTable.Rows.Add("text19");
      dataTable.Rows.Add("text20");

      dataTable.Rows.Add(orgFK);
    }

    SqlDataAdapter adapter = new SqlDataAdapter();

    adapter.InsertCommand = new SqlCommand("INSERT INTO Messages (priority, creation_date) VALUES (@priority, @creationDate);", connection);
    adapter.InsertCommand.Parameters.Add("@priority", SqlDbType.NVarChar, 50, "priority");
    adapter.InsertCommand.Parameters.Add("@creationDate", SqlDbType.NVarChar, 50, "creation_date");
    adapter.InsertCommand.Parameters.Add("@creationDate", SqlDbType.NVarChar, 50, "creation_date");
    adapter.InsertCommand.UpdatedRowSource = UpdateRowSource.None;

  }

}
