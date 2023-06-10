# az-sql-powerapps

Using SQL database connector with Power Apps.

Create a SQL database on Azure:

> 💡 Edit security and location parameters according to your needs, this code is only for demo purposes

```sh
az group create -n powerapps -l brazilsouth

az sql server create -l brazilsouth -g powerapps -n sqlpowerappsbenchmark -u powerapps -p "<STRONGPASSWORD>"
az sql server firewall-rule create -g powerapps --server sqlpowerappsbenchmark -n AllowYourIp --start-ip-address "0.0.0.0" --end-ip-address "255.255.255.255"
az sql db create -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective S0 --bsr Local
```

To generate the data loader connection string:

```sh
az sql db show-connection-string -c ado.net
```

We're using DTU capacity, to change capacity during benchmark:

```sh
# Options with DTU are S0(10), S1(20), S2(50), S3(100) and so on
az sql db update -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective S5
```

> ℹ️ Read ore about capacity options in the [purchasing models][1] documentation.
> 💡 DTU model supports columnstore indexing starting from `S3` and above


https://stackoverflow.com/a/24877312/3231778


[1]: https://learn.microsoft.com/en-us/azure/azure-sql/database/purchasing-models?view=azuresql
