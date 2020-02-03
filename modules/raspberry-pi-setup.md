# Raspberry PI Gateway Setup

## Intro

This guide will setup a Raspberry PI to be an IoT Edge Device, useable in an IIoT Scenario.

## Steps

* Flash the latest `raspbian stretch` image on a SD Card
  * [Latest Release of now: raspbian-2019-04-09](https://downloads.raspberrypi.org/raspbian/images/raspbian-2019-04-09/)
  * Make sure you're using `stretch`. `buster` has compatability issues.
  * Tools for flashing on Windows: [Etcher](https://www.balena.io/etcher/), [Win32 Disk Imager](https://sourceforge.net/projects/win32diskimager/)
* Create an empty file named `ssh` on the boot partition, put the SD Card into the RPI and start it.
* Find out the RPI's IP (Router, nmap, etc.) and connect to it via SSH (Username `pi` and password `raspberry`)
* Follow [Install the Azure IoT Edge runtime on Debian-based Linux systems](https://docs.microsoft.com/en-us/azure/iot-edge/how-to-install-iot-edge-linux)
