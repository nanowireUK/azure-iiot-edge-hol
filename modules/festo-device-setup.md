# Festo CPX-CEC2 Device Setup

## Introduction

The Festo CPX-CEC2 device has been programmed with a CODESYS application containing an OPC UA Application exposing the various attributes.

## Configuration

The network settings of the device are configured using the [Festo Field Device Tool](https://www.festo.com/net/en-gb_gb/SupportPortal/default.aspx?tab=0&q=8004365).

* Install tool
* Set fixed IP on PC
  * 192.168.1.170 (or anything in 192.168.2.0/24 range except 192.168.1.160)
  * Subnet 255.255.255.0
* Launch FFDT
* Device should autodiscover and appear in List View
* Richt click and change Network settings

## Restoring

The device can be restored to defaults by programmimng the [firmware](assets\CPX-CEC-C1-V3_Temperatursensor_Systainer_withOPCUA_22_11_2019.cec2_bak) using the [Festo Field Device Tool](https://www.festo.com/net/en-gb_gb/SupportPortal/default.aspx?tab=0&q=8004365).

## Links

[User guide for CPX IoT Gateway](https://www.festo.com/net/SupportPortal/Files/640345/CPX-IOT_instruction_2019-04a_8108872d1.pdf)

[Festo Field Device Tool](https://www.festo.com/net/en-gb_gb/SupportPortal/default.aspx?tab=0&q=8004365)

## CPX-CEC2 Details

| Property    | Value                                        |
| ----------- | -------------------------------------------- |
| Projectname | CPX-CEC-C1-V3                                |
| Kernel      | FESTO CPX                                    |
| Driver      | CPX-CEC2 2.0.12-cec20 (7b80011ba009 ) [-CEC] |
| CPU         | ARMv7                                        |
| Partnumber  | unknown                                      |
| IP Address  | 192.168.1.160                                |
| IP Netmask  | 255.255.255.0                                |
| MAC         | v00:0E:F0:5A:DE:AE                           |
