# Install Industrial IoT Components

## Links
[IIoT Engineering Tool](https://github.com/dacolgit/IIot-EngTool)


## Cloud deployment

Follow instructions in [Industrial IoT Github](https://github.com/Azure/Industrial-IoT)

## Edge Module Deployment

* Deploy manifest


## Configure cloud dashboard

* Go to URL in App Service
* Refresh page
* Should see all gateways with twin modules


## Test out OPC Publisher

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
        "EndpointUrl": "opc.tcp://192.168.2.20:4840",
        "UseSecurity": false
    }
    ```