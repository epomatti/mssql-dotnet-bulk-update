# az-sql-powerapps

Using SQL database connector with Power Apps.

Create a SQL database on Azure:

> 💡 Edit security and location parameters according to your needs, this code is only for demo purposes

```sh
az group create -n powerapps -l brazilsouth

az sql server create -l brazilsouth -g powerapps -n sqlpowerappsbenchmark -u powerapps -p "<STRONGPASSWORD>"
az sql server firewall-rule create -g powerapps --server sqlpowerappsbenchmark -n AllowYourIp --start-ip-address "0.0.0.0" --end-ip-address "255.255.255.255"
az sql db create -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective Basic --max-size 2GB --bsr Local
```

We're using DTU capacity, to change capacity during benchmark:

```sh
# Options with DTU are S0(10), S1(20), S2(50), S3(100)...
az sql db update -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective S3 --max-size 250GB

# Go back to Basic to save costs
az sql db update -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective Basic --max-size 2GB
```

> ℹ️ Read ore about capacity options in the [purchasing models][1] documentation.
> 💡 DTU model supports columnstore indexing starting from `S3` and above

To load the data into the SQL database, first connect using Azure Data Studio or another client and run the [`schema.sql`](/schema.sql).

After creating the schema, enter and set up the data loading console app:

```sh
cd dataload
cp template.env .env
```

Get the database connection string:

```sh
az sql db show-connection-string -s sqlpowerappsbenchmark -n sqldbbenchmark -c ado.net
```

Add the connection string to the `.env` file, replacing the username and password.

Now run the application:

```sh
dotnet restore
dotnet run
```

The console app users [bulk insert] to create the registries.

---

Don't forget to clean up the resources:

```sh
az sql server delete -g powerapps -n sqlpowerappsbenchmark -y
```

[1]: https://learn.microsoft.com/en-us/azure/azure-sql/database/purchasing-models?view=azuresql
[2]: https://stackoverflow.com/a/24877312/3231778
