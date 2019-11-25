# Setting up additional Cloud Services

## Time Series Insights

* Create new consumer group in IoT Hub
* Create new route that only takes messages from the publisher module
* Create TSI instance
  * Timestamp `Value.SourceTimestamp`

## Azure Data Explorer

* Create Azure Data Explorer service with defaults
* Create database with defaults
* Connect to database with Kusto Explorer
  * Create Connection
  * Add connection string
  * Replace catalog in CS with database name
* Run queries below to generate the table
* Create consumer group in IoT Hub
* Create Data Connection
  * IoT Hub
  * Event system prop: device-id
  * Target Table
    * Table: RawData
    * Data format: Json
    * Column mapping: RawDataMapping

```sql
.create table RawData (DeviceId:string, RawJson:dynamic)
.create table RawData ingestion json mapping 'RawDataMapping' '[{"column":"DeviceId","path":"$.iothub-connection-device-id","datatype":"string"},{"column":"RawJson","path":"$","datatype":"dynamic"}]'
.alter table RawData policy ingestionbatching @'{"MaximumBatchingTimeSpan":"00:00:10", "MaximumNumberOfItems": 10, "MaximumRawDataSizeMB": 1}'
```
