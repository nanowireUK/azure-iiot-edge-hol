# IoTEdge Baremetal DPS using TPM

## Intro

This guide will connect a IoT Edge gateway to an IoT Hub via Device Provisioning Service (DPS) using a hardware TPM Module. While it's possible to use any gateway, this example will use a Moxa UC-8100A which features a TPM Module.

## Prerequisites

* [Moxa Gateway Setup](./moxa-gateway-setup.md)
* Gateway internet access
* Gateway SSH connection
* Device Provisioning Service linked to an IoT Hub

## Steps

1. SSH to the Gateway
1. Download and run the latest TPMProvisioning tool from [GitHub Releases](https://github.com/nanowireUK/azure-iiot-edge-hol/releases/)
    ```sh
    wget https://github.com/nanowireUK/azure-iiot-edge-hol/releases/download/0.0.2/TPMProvisioningTool
    chmod +x ./TPMProvisioningTool
    ENDORSEMENT_KEY="$(./TPMProvisioningTool)"
    echo "$ENDORSEMENT_KEY"
    # Output: Endorsement Key
    ```
1. Generate a device unique registration-id (for example, `echo "$ENDORSEMENT_KEY" | sha256sum`)
1. Add a new TPM `Invididual Registration` in Azure DPS with the above values or the values given out by your gateway vendor
    * device id can be left empty
1. `sudo nano /etc/iotedge/config.yaml`
    1. comment the manual provisioning
    1. uncomment the TPM part and fill in `registration_id` and `scope_id`
1. Restart IoTEdge `sudo systemctl restart iotedge`
1. Check the status of the registration via portal or `sudo systemctl status iotedge`
