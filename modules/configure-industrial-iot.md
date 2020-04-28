# Configure Industrial IoT Components

## Introduction

In this module we will configure the gateway to communicate with our IoT Hub within the Indsutrial IoT solution using the Industrial IoT CLI.

## Required

* A OPC UA Server on the local network of the gateway

👉 **Tip!** Since docker is already installed on the gateway, you can use a simulated OPC UA server on the gateway itself:
  ```sh
  # Replace the IP with the local IP of the gateway
  docker run -d -p 50000:50000 mcr.microsoft.com/iotedge/opc-plc -aa --unsecuretransport --ph 192.168.0.100
  ```

## Steps

### Check Cloud Dashboard

* Visit the URL of your IIoT setup, which is located in the deploy script output.
* Make sure the gateway is listed under `Discovery`, `Publisher` and `Gateway`.

### Test out OPC Publisher

* Navigate to your cloned `Azure/Industrial-IoT` repository, then into `api\src\Microsoft.Azure.IIoT.Api\cli`
* `dotnet restore` - Restore NuGET packages of the CLI
* `dotnet run console` - Open a console for managing your IIoT setup
  * `status` - Check if everything is running
  * [Follow the Industrial-IoT tutorial](https://github.com/Azure/Industrial-IoT/blob/master/docs/tutorials/tut-use-cli.md#exercise-1)

👉 **Note!** The CLI uses the REST API of the IIoT ssetup internally. This means all operations can also be automated by other systems.

👉 **Tip!** You can use a tool like [UAExpert](https://www.unified-automation.com/de/produkte/entwicklerwerkzeuge/uaexpert.html) to find out which nodes are available on the OPC UA Server without depending on the CLI

👉 **Tip!** The following nodes are available via the `mcr.microsoft.com/iotedge/opc-plc` server:

  <details>
  <summary>OPC UA Simulator Nodes</summary>

    ```json
    {
      "Id": "nsu=http://microsoft.com/Opc/OpcPlc/;s=StepUp"
    },
    {
      "Id": "nsu=http://microsoft.com/Opc/OpcPlc/;s=SpikeData"
    },
    {
      "Id": "nsu=http://microsoft.com/Opc/OpcPlc/;s=DipData"
    },
    {
      "Id": "nsu=http://microsoft.com/Opc/OpcPlc/;s=AlternatingBoolean"
    },
    {
      "Id": "nsu=http://microsoft.com/Opc/OpcPlc/;s=RandomUnsignedInt32"
    },
    {
      "Id": "nsu=http://microsoft.com/Opc/OpcPlc/;s=PositiveTrendData"
    },
    {
      "Id": "nsu=http://microsoft.com/Opc/OpcPlc/;s=NegativeTrendData"
    }
    ```
  </details>
