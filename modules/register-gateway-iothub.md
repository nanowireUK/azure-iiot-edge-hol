# Register Gateway in IoT Hub

## Introduction

In this module we will register the gateway in our IoT Hub.

## Steps

### IoT Hub Edge Device

* Find your `IoT Hub` and click on the tab `IoT Edge`
* On clicking `Add an IoT Edge Device`, fill it with following properties:
  * `DeviceID = device-name`
* When the device is created, click on it and make note of the following parameters:
  * `Primary Connection String`

### IoT Edge Runtime Configuration

* SSH into your gateway of choice
* Edit `/etc/iotedge/config.yaml` and fill out the following part:

  ```yaml
  # Make sure the following lines are uncommented
  provisioning:
    source: "manual"
    device_connection_string: "<PRIMARY CONNECTION STRING>"
    dynamic_reprovisioning: false
  ```
* Restart your iotedge runtime `sudo systemctl restart iotedge`
