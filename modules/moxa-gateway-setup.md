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

* Go to [Install the Azure IoT Edge runtime on Debian-based Linux systems](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-install-iot-edge-linux)
* Follow the instructions given to install:
  * Moby
  * IoT Edge Runtime

👉 **Tip!** The Moxa device also uses Debian and is ARM based, so it's compatible with **Raspian Stretch**

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
