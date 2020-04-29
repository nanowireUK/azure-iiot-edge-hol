# Process data in ADX

## Intro

This guide will connect published OPC UA data with a deployed Azure Date Explorer service.

## Prerequisites

* [Moxa Gateway Setup](./moxa-gateway-setup.md)
* Gateway internet access
* Gateway SSH connection
* OPC UA Node already publishing

## OPC Data

Depending on your OPC Data, some steps of the tutorial may need to be adjusted. We will use the following published node as reference:

```json
{
  "NodeId": "http://microsoft.com/Opc/OpcPlc/#s=DipData",
  "EndpointUrl": "opc.tcp://192.168.0.100:50000/",
  "ApplicationUri": "urn:OpcPlc:192",
  "DisplayName": null,
  "Timestamp": "2020-04-16T11:18:03.5511918Z",
  "Status": "Good",
  "Value": {
    "Value": -3.2162452993532734E-14,
    "SourceTimestamp": "2020-04-16T11:18:03.5375812Z",
    "ServerTimestamp": "2020-04-16T11:18:03.5376173Z"
  },
  "ExtensionFields": {
    "EndpointId": "uat5ccaee1cdce2d686f96b9dd7fa937e171dabb75b",
    "PublisherId": "uat5ccaee1cdce2d686f96b9dd7fa937e171dabb75b",
    "DataSetWriterId": "uat5ccaee1cdce2d686f96b9dd7fa937e171dabb75b"
  }
}
```

```json
{
  "NodeId": "http://microsoft.com/Opc/OpcPlc/#s=PositiveTrendData",
  "EndpointUrl": "opc.tcp://192.168.0.100:50000/",
  "ApplicationUri": "urn:OpcPlc:192",
  "DisplayName": null,
  "Timestamp": "2020-04-16T11:18:03.5511918Z",
  "Status": "Good",
  "Value": {
    "Value": 2018.00,
    "SourceTimestamp": "2020-04-16T11:18:03.5375812Z",
    "ServerTimestamp": "2020-04-16T11:18:03.5376173Z"
  },
  "ExtensionFields": {
    "EndpointId": "uat5ccaee1cdce2d686f96b9dd7fa937e171dabb75b",
    "PublisherId": "uat5ccaee1cdce2d686f96b9dd7fa937e171dabb75b",
    "DataSetWriterId": "uat5ccaee1cdce2d686f96b9dd7fa937e171dabb75b"
  }
}
```


## Steps

1. Deploy an `Azure Date Explorer Cluster` service in your resource group (This may take some time)

---

### A: Via EventHub

1. Visit the Eventhub Namespace of your Resource Group
    1. Click on your EventHub and add a Consumer Group `opc-data`
1. Visit the IoT Hub of your Resource Group
    1. On `Message Routing`, add the event hub + consumer group as a new `Custom Endpoint`
    1. Still on `Message Routing`, add a new route of all telemetry messages to the newly created EventHub endpoint

### B: Via IoTHub

1. Visit the IoT Hub of your Resource Group
    1. On `Message Routing`, add a new `default` route if it doesn't exist
        1. Endoints: `Events`
        1. Data Source: `Device Telemetry Messages`

---

1. Visit your newly created `Azure Date Explorer` service
    1. Create a database with a name of your choice and navigate to it via `Databases` on the left
    1. Create a table within that database using the `Query` tab on the right
        ```sql
        .create table IoTRawTable (timestamp: datetime, deviceid:string, rawjson:dynamic)
        ```
    1. Create a json mapping for your table:
        ```sql
        .create-or-alter table IoTRawTable ingestion json mapping 'RawDataMapping'
        '['
        '{ "column":"deviceid",  "path":"$.iothub-connection-device-id", "datatype":"string"},'
        '{ "column":"rawjson",   "path":"$",                             "datatype":"dynamic"},'
        '{ "column":"timestamp", "path":"$.iothub-enqueuedtime",         "datatype":"datetime"}'
        ']'

        .alter table IoTRawTable policy ingestionbatching @'{"MaximumBatchingTimeSpan":"00:00:10", "MaximumNumberOfItems": 10, "MaximumRawDataSizeMB": 1}'
        ```
    1. Create a new `Data Ingestion` in the portal and fill out the required details for IoTHub/EventHub
        1. When selecting IoTHub, make sure to select the following `Event System Properties`:
          * `iothub-connection-device-id`
          * `iothub-enqueuedtime`
    1. After some Minutes, try the following query:
    ```sql
    IoTRawTable
    | take 10
    ```

![img](../.imgs/adx_query_success.png)

## Example Queries

### Extract a mapping out of the JSON, sorted by latency

```sql
let MyMapping = IoTRawTable
| project deviceid,
    timestamp,
    sourcetimestamp = todatetime(rawjson.Value.ServerTimestamp),
    publishertimestamp = todatetime(rawjson.Timestamp),
    delay = timestamp - todatetime(rawjson.Value.ServerTimestamp),
    latency = timestamp - todatetime(rawjson.Timestamp),
    value = toreal(rawjson.Value.Value),
    nodeid = tostring(rawjson.NodeId),
    status = tostring(rawjson.Status),
    appuri = tostring(rawjson.ApplicationUri)
| where isnotnull(value)
| sort by latency asc;
```

### Render charts

```sql
MyMapping
| summarize event_count = count()
 by bin(latency, 2ms), nodeid
 | sort by latency asc
 | render timechart
```

### Detect Anomalies

```sql
MyMapping
| where nodeid == 'http://microsoft.com/Opc/OpcPlc/#s=DipData'
| summarize Values = make_list(value)
| extend series_decompose_anomalies(Values)
| mv-expand Values, series_decompose_anomalies_Values_ad_flag
| project Values, series_decompose_anomalies_Values_ad_flag
```
