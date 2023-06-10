# az-sql-powerapps

Using SQL database connector with Power Apps.

Create a SQL database on Azure:

> 💡 Edit security and location parameters according to your needs, this code is only for demo purposes

```sh
az group create -n powerapps -l brazilsouth

az sql server create -l brazilsouth -g powerapps -n sqlpowerappsbenchmark -u powerapps -p "<USE STRONG PASSWORD>"
az sql server firewall-rule create -g powerapps --server sqlpowerappsbenchmark -n AllowYourIp --start-ip-address "0.0.0.0" --end-ip-address "255.255.255.255"
az sql db create -g powerapps -s sqlpowerappsbenchmark -n sqldbbenchmark --service-objective S0 --bsr Local
```



