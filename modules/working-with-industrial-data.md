# Working with Industrial Data

Once we have the OPC-UA Application connected through the IoT Edge Gateway, the next step would usually be to store and visualise the data.

The Industrial IoT Solution includes a pre-configured instance of Time Series Insights which can be used for this purpose. To access this instance perform the following:

* Go to your IIoT Resource Group
* Select the 'tsi-xxxxxx' Time Series Insights Environment service
* Configure your user as a Reader and Contributor under 'Data Access Policies'
* Click 'Go to TSI Explorer' to go through the Explorer

## Creating your own Time Series Insights instance

* Create TSI instance
  * Select Gen2 (L1)
  * Time series ID. `publisherId, dataSetWriterId, nodeId` is the one provided in IIoT setup.
    > 👉 **Warning!** This is a fundamental property of a TSI instance and cannot be changed.
  * Create a storage account with name and defaults
  * Enable Warm Store for 31 Days
  * On next page, configure the Event Source
    * Event Hub
    * Create new consumer group
    * Timestamp `TimeStamp`
  * Review and Create
* Once deployed go to your TSI Instance
* Configure your user as a Reader and Contributor under 'Data Access Policies'
* Click 'Go to TSI Explorer' to go through the Explorer
