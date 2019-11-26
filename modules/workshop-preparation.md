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
* [UC8100A image](https://www.moxa.com/en/support/search?psid=95158)
* [Firmware for UC-8100A-ME-T Series (installation image)](https://www.moxa.com/Moxa/media/PDIM/S100000603/moxa-uc-8100a-me-t-series-installation-image-firmware-v1.3.zip)
* Do a `sudo mx-set-def`
* Delete docker folder in `/overlayfs`
