# .NET Core Batch Update

Using ADO.NET bulk update to create data on MSSQL.

> This example follows AdventureWorks [naming conventions][3]

## Creating the database

For local development, launch a docker instance:

```sh
docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Str0ngP4ssword#2023" --name mssql-powerapps -p 1433:1433 -d mcr.microsoft.com/mssql/server:2022-latest
```

For real performance testing, start a database on Azure.

Make sure you have the Bicep latest release:

```sh
az bicep upgrade
```

Create the resources:

> 💡 Edit security and location parameters according to your needs - this code is only for demo purposes

```sh
# Edit the required values
cp config-template.json config.json

# Run the Bicep template
az deployment group create --resource-group powerapps --template-file main.bicep
```

Switching the DTU capacity during benchmark:

```sh
# Options with DTU are S0(10), S1(20), S2(50), S3(100)...
az sql db update -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective S3 --max-size 250GB

# Go back to Basic to save costs
az sql db update -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective Basic --max-size 2GB
```

> ℹ️ Read ore about capacity options in the [purchasing models][1] documentation.

> 💡 DTU model supports columnstore indexing starting from `S3` and above

## Create the schema

The sample schema compatible with this code is available in the [`schema.sql`](/tsql/schema.sql) file.

Use your fav IDE such as Azure Data Studio to create the objects.

## Run the batch

After creating the schema, enter the console app directory to set it up.

```sh
cd dataload
cp template.env .env
```

Get the database connection string:

```sh
az sql db show-connection-string -s sqlpowerappsbenchmark -n sqldbbenchmark -c ado.net
```

Add the connection string to the `.env` file, replacing the username and password.

Run the application:

```sh
dotnet restore
dotnet run
```

The console app users [bulk insert] to create the registries.

---

When finished, delete the resources:

```sh
az group delete -n powerapps -y
```

[1]: https://learn.microsoft.com/en-us/azure/azure-sql/database/purchasing-models?view=azuresql
[2]: https://stackoverflow.com/a/24877312/3231778
[3]: https://learn.microsoft.com/en-us/previous-versions/sql/sql-server-2008/ms124438(v=sql.100)
