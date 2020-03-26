# Azure Industrial IoT Edge Hands-On Lab

## Context

This hands-on lab will walk you through the steps to build a complete Azure Industrial IoT Edge solution on a Moxa industrial PC and bring the data from a Festo device into the Azure cloud.

## 1. Day - Main lab pathway

1. [Set up development environment](modules/setup-dev-environment-local.md)
2. [Deploy the Industrial IoT Solution](modules/deploy-industrial-iot.md)
3. Setup a Gateway
   1. [Moxa](modules/moxa-gateway-setup.md)
   2. [Raspberry PI](modules/raspberry-pi-setup.md)
4. [Register the Gateway in IoT Hub](modules/register-gateway-iothub.md)
5. [Configure the end-to-end solution](modules/configure-industrial-iot.md)
6. [Set up additional cloud service](modules/setting-up-cloud-services.md)

## 2. Day - Additional modules pathway

* Zero Touch Device Provisioning via Device Provisiong Service (DPS)
  * [Using a bare-metal IoT Edge Runtime](modules/iotedge-baremetal-tpm.md)
  * [Using Moxa Things Pro](modules/Getting-Started-with-TPM-UC-8112A-TPE110_v1.pdf)
* [Set up the Festo CPX CEC device](modules/festo-device-setup.md)
* [Connect the CPX IoT Gateway to Festo Dashboards](modules/festo-dashboard.md)

## Information

* Customer brings own Azure Sub.
