# Configure Industrial IoT Components

## Introduction

In this module we will configure the gateway to coomunicate with our IoT Hub within the Indsutrial IoT solution.

## Steps

### Edge Module Deployment

* Follow the [guide](https://github.com/Azure/Industrial-IoT/blob/master/docs/howto-deploy-modules.md)

### Configure cloud dashboard

* Go to URL in App Service
* Refresh page
* Should see all gateways with twin modules

### Test out OPC Publisher

* Invoke Direct Method `PublishNodes` with payload
    ```json
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
