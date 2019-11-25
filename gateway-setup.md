# Gateway setup

## Install the IoT Edge Runtime

* Go to [documentation](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-install-iot-edge-linux#install-a-specific-runtime-version)
    > This is required since we are installing on a Tier 2 OS
* Follow the instructions given to install:
    * Moby
    * IoT Edge Runtime
    * libiothsm
* Modify the Docker storage location
    > Required since Moxa uses overlayfs
    * `sudo nano /etc/docker/daemon.json`
    ```json
    {
        "graph": "/overlayfs",
        "log-driver": "json-file",
        "log-opts": {
            "max-size": "10m",
            "max-file": "2"
        }
    }
    ```

## Moby
From https://github.com/Azure/azure-iotedge/releases/tag/1.0.7
https://github.com/Azure/azure-iotedge/releases/download/1.0.7/moby-engine_3.0.5_armhf.deb
https://github.com/Azure/azure-iotedge/releases/download/1.0.7/moby-cli_3.0.5_armhf.deb

## IoT Edge
From https://github.com/Azure/azure-iotedge/releases/tag/1.0.8
https://github.com/Azure/azure-iotedge/releases/download/1.0.8/libiothsm-std_1.0.8-2_armhf.deb
https://github.com/Azure/azure-iotedge/releases/download/1.0.8/iotedge_1.0.8-2_armhf.deb
