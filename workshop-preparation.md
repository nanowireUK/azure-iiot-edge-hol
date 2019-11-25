# Workshop Preparation

## Re-image Gateway device

* Connect the device with serial-to-usb converter
    * Baud 115200
    * Baudrate=115200 bps
    * Parity=None
    * Data bits=8
    * Stop bits =1
    * Flow Control=None
* [Quickstart guide](https://www.moxa.com/Moxa/media/PDIM/S100000603/moxa-uc-8100a-me-t-series-qig-v1.0.pdf)
* [Debian 9 Quickstart](https://www.moxa.com/Moxa/media/PDIM/S100000603/moxa-arm-based-computer-linux-user-manual-for-debian-9-manual-v4.1.pdf)
* Do a `sudo mx-set-def`
* Delete docker folder in `/overlayfs`

## Configure networking on Moxa GW

* `sudo nano /etc/network/interfaces'
* Write in following

    ```bash
    # interfaces(5) file used by ifup(8) and ifdown(8)
    # Include files from /etc/network/interfaces.d:
    source-directory /etc/network/interfaces.d
    auto eth0 eth1 lo
    iface lo inet loopback
    iface eth0 inet dhcp
    #iface eth0 inet static
    #        address 192.168.3.127
    #        network 192.168.3.0
    #        netmask 255.255.255.0
    #        broadcast 192.168.3.255
    iface eth1 inet static
            address 192.168.4.127
            network 192.168.4.0
            netmask 255.255.255.0
            broadcast 192.168.4.255
    ```

* `sudo systemctl restart networking`
