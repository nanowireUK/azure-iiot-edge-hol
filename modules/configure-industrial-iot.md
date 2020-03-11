# Configure Industrial IoT Components

## Introduction

In this module we will configure the gateway to communicate with our IoT Hub within the Indsutrial IoT solution.

## Steps

### Edge Module Deployment

* Follow the [guide](https://github.com/Azure/Industrial-IoT/blob/master/docs/deploy/howto-deploy-modules-portal.md)

### Configure cloud dashboard

* Locate the `App Service` in your Resource Group
* Open the URL of it (`Overview` Tab)
* Refresh page
* Should see all gateways with twin modules

### Test out OPC Publisher

    * Invoke Direct Method `PublishNodes` with payload
```jtson
    {
      "OpcNodes": [
        {
          "Id": "ns=2;s=|var|CPX-CEC-C1-V3.Application.GVL.temperature_CH0",
          "OpcSamplingInterval": 2000,
          "OpcPublishingInterval": 5000
        }
      ],
      "EndpointUrl": "opc.tcp://192.168.1.160:4840",
      "UseSecurity": false
    }
    ```
