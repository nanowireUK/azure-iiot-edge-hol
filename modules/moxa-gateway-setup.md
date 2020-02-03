# Gateway setup

## Introduction

This module walks through the steps required to onboard the [Moxa UC-8112 Industrial PC](https://www.moxa.com/en/products/industrial-computing/arm-based-computers/uc-8100-series/uc-8112-lx) as an Azure IoT Edge Gateway.

## Steps

> Ensure the device is set to a standard base image if required by following this [guide](workshop-preparation.md)

### Configure networking on Moxa GW

* Run `sudo nano /etc/network/interfaces`
* Overwrite with following configuration

    ```bash
    # interfaces(5) file used by ifup(8) and ifdown(8)
    # Include files from /etc/network/interfaces.d:
    source-directory /etc/network/interfaces.d
    auto eth0 eth1 lo
    iface lo inet loopback
    # eth0 is the port connecting to the router
    iface eth0 inet dhcp

    # eth1 is the port connecting to the Festo CPX-CEC device with fixed IP settings
    iface eth1 inet static
            address 192.168.2.127
            network 192.168.2.0
            netmask 255.255.255.0
            broadcast 192.168.2.255
    ```

* Run `sudo systemctl restart networking` to restart networking

### Install the IoT Edge Runtime

* Go to [documentation for installing a specific runtime version](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-install-iot-edge-linux#install-a-specific-runtime-version)
    > This is required since we are installing on a Tier 2 OS. For installing on Ubuntu LTS or Raspbian Stretch follow this [guide]() instead.

* Follow the instructions given to install:
  * Moby
  * IoT Edge Runtime
  * libiothsm
* Modify the Docker storage location
    > This is specifically required for the Moxa device since this already uses overlayfs.
  * Run `sudo nano /etc/docker/daemon.json` and paste in the following configuration

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

### Current Libraries

#### Moby

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

#### IoT Edge

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
