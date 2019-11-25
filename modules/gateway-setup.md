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
            "dns": ["1.1.1.1"],
            "log-opts": {
                "max-size": "10m",
                "max-file": "2"
            }
        }
        ```

    * Restart docker to apply the new configuration `sudo systemctl restart docker`

## Current Libraries

### Moby

> Links from [1.0.7 Release](https://github.com/Azure/azure-iotedge/releases/tag/1.0.7)

* Moby Engine

    ```sh
    sudo wget -O moby-engine_3.0.5_armhf.deb https://github.com/Azure/azure-iotedge/releases/download/1.0.7/moby-engine_3.0.5_armhf.deb
    sudo dpkg -i moby-engine_3.0.5_armhf.deb
    ```

* Moby Cli

    ```sh
    sudo wget -O moby-cli_3.0.5_armhf.deb https://github.com/Azure/azure-iotedge/releases/download/1.0.7/moby-cli_3.0.5_armhf.deb
    sudo dpkg -i moby-cli_3.0.5_armhf.deb
    ```

### IoT Edge

> Links from [1.0.8 Release](https://github.com/Azure/azure-iotedge/releases/tag/1.0.8)

* IoT Edge HSM library

    ```sh
    sudo wget -O libiothsm-std_1.0.8-2_armhf.deb https://github.com/Azure/azure-iotedge/releases/download/1.0.8/libiothsm-std_1.0.8-2_armhf.deb
    sudo dpkg -i libiothsm-std_1.0.8-2_armhf.deb
    ```

* IoT Edge dSecurity Daemon

    ```sh
    sudo wget -O iotedge_1.0.8-2_armhf.deb https://github.com/Azure/azure-iotedge/releases/download/1.0.8/libiothsm-std_1.0.8-2_armhf.deb
    sudo dpkg -i iotedge_1.0.8-2_armhf.deb
    ```
