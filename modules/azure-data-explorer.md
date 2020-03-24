# Analysing data with Azure Data Explorer

> The main guide can be found [here](https://docs.microsoft.com/en-us/azure/data-explorer/ingest-data-iot-hub).

## Setting up services

* Create a new Azure Data Explorer instance

  * Compute specification: `Dev(No SLA)`
  * No Availability Zones
  * Streaming ingestion: `On`
  * System Assigned Identity: `Off`
* Once the service has deployed, [create a database](https://docs.microsoft.com/en-us/azure/data-explorer/create-cluster-database-portal#create-a-database)

