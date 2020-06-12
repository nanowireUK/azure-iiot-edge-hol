# Technical Requirements

The following page describes the technical requirements  

## Network Requirements

### IoT Edge Client

| URL (\* = wildcard)                       | Outbound TCP Ports    | Usage |
| -----                                     | -----                 | ----- |
| mcr.microsoft.com                         | 443                   | Microsoft Container Registry |
| global.azure-devices-provisioning.net     | 443                   | DPS access (optional) |
| \*.azurecr.io                             | 443                   | Personal and third-party container registries |
| \*.blob.core.windows.net                  | 443                   | Download Azure Container Registry image deltas from blob storage |
| \*.azure-devices.net                      | 5671, 8883, 443       | IoT Hub access |
| \*.docker.io                              | 443                   | Docker Hub access (optional) |
| *.azurewebsites.net                       | 443                   | Azure App Service hosted APIs (optional) |

### Developer Client

## Azure Subscription Requirements

* Can sign in on the [Azure Portal](https://portal.azure.com) with Microsoft or Organisational Account
