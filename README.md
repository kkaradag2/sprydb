# Sprydb
Sprydb is an open-source database migration tool. It strongly favors simplicity and convention over configuration.

## Get Started

The simple configuration must be completed before you can start using SpryDB. The SpryDB configuration data is saved 
in the **config.json** file in the installation directory.

The simple configuration must be completed before you can start using SpryDB. It keeps the SpryDB configuration data 
in the config.json file in the directory where it was installed.

The configuration of SpryDB needs to be done once in order to be able to run. The sprydb config command is sufficient for this. Config keyworlds contains the following options.

--server: This option is used to specify the path of the database server being worked on. The default value is MSSQL.

All available options
* MSSQL
* ORACLE
* MYSQL

EXAMPLE of USEGE
This example show you how to configure server type as ORACLE.

```
Sprydb config -s ORACLE
```

This example show you how to configure server type as MSSQL. The --server option can be used instead of -s. 

```
Sprydb config --server ORACLE
```
