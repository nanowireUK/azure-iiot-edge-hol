# Azure Industrial IoT Edge Hands-On Lab

## Context

This hands-on lab will walk you through the steps to build a complete Azure Industrial IoT Edge solution on a Moxa industrial PC and bring the data from a Festo device into the Azure cloud.

## 1. Day - Main lab pathway

1. [Set up development environment](modules/setup-dev-environment-local.md)
1. [Deploy the Industrial IoT Solution](modules/deploy-industrial-iot.md)
1. Setup up the Gateway
   1. Either of the two choices:
      * [Moxa](modules/moxa-gateway-setup.md)
      * [Raspberry PI](modules/raspberry-pi-setup.md)
   1. [Register the Gateway in IoT Hub](modules/register-gateway-iothub.md)
1. [Connecting to an OPC-UA Application](modules/connecting-to-opcua-app.md)
1. [Working with Industrial Data](modules/working-with-industrial-data.md)

## 2. Day - Additional modules pathway

* Zero Touch Device Provisioning via Device Provisiong Service (DPS)
  * [Using a bare-metal IoT Edge Runtime](modules/iotedge-baremetal-tpm.md)
  * [Using Moxa Things Pro](modules/Getting-Started-with-TPM-UC-8112A-TPE110_v1.pdf)
* [Set up the Festo CPX CEC device](modules/festo-device-setup.md)
* [Connect the CPX IoT Gateway to Festo Dashboards](modules/festo-dashboard.md)
* [Process data in ADX](modules/adx.md)

## Information

* Customer brings own Azure Sub.
