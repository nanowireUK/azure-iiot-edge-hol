# IoTEdge Baremetal DPS using TPM

## Intro

This guide will connect a IoT Edge gateway to an IoT Hub via Device Provisioning Service (DPS) using a hardware TPM Module. While it's possible to use any gateway, this example will use a Moxa UC-8100A which features a TPM Module.

> NOTE: In this example, we take ownership of the TPM Module and generate a new Endorsement Key + Registration ID. Often, you already received those values by the vendor. In this case, you can skip the first 3 steps and directly create the Individual Registration in azure.

## Prerequisites

* [Moxa Gateway Setup](./moxa-gateway-setup.md)
* Gateway internet access
* Gateway SSH connection
* Device Provisioning Service linked to an IoT Hub

## Steps

1. SSH to the Gateway
1. `/usr/sbin/tpm2_takeownership -c`
1. Download and run the latest TPMProvisioning tool from [GitHub Releases](https://github.com/nanowireUK/azure-iiot-edge-hol/releases/)
    ```sh
    wget https://github.com/nanowireUK/azure-iiot-edge-hol/releases/download/0.0.1/TPMProvisioningTool
    chmod +x ./TPMProvisioningTool
    ./TPMProvisioningTool <DPS_ID_Scope> tpm-device
    # Output: Endorsement Key
    ```
1. Add a new TPM `Invididual Registration` in Azure DPS with the above values or the values given out by your gateway vendor
    * device id can be left empty
1. `sudo nano /etc/iotedge/config.yaml`
    1. comment the manual provisioning
    1. uncomment the TPM part and fill in `registration_id` and `scope_id`
1. Restart IoTEdge `sudo systemctl restart iotedge`
1. Check the status of the registration via portal or `sudo systemctl status iotedge`
