# Setting Up VS Code for IoT Development #

You are going to install the required VS Code extensions and optionally connect to a Linux VM via SSH for remote development.
*Please keep in mind, if you want to work in a remote VM you will need to install all prerequisites in that VM after you've connected to it*

## Requirements for deploying the Industrial IoT solution ##

1. Azure subscription
   * Can sign in on the Azure Portal with Microsoft or Organisational Account
   * Can create Azure Active Directory (AAD) Apps in the respective tenant, with Microsoft Graph
1. Local machine
   * Ability to connect via SSH (either Putty,  WSL or Powershell)
   * PowerShell
   * Azure CLI Extensions

```powershell
Set-ExecutionPolicy -ExecutionPolicy Unrestricted -Force
Install-Module -Name Az -AllowClobber
Install-Module -Name AzureAD -AllowClobber
```

   * Modern Browser

## Required software for developing IoT Edge solutions ##

You will need to have the following pre-requisites installed on your development workstation in order to develop for IoT Edge:

* [Visual Studio Code](https://code.visualstudio.com/Download)
  * [Azure IoT Tools Extension](https://marketplace.visualstudio.com/items?itemName=vsciot-vscode.azure-iot-tools)
* [Docker Desktop](https://hub.docker.com/editions/community/docker-ce-desktop-windows)
* [.NET Core](https://dotnet.microsoft.com/download/dotnet-core)

## Optional Software ##

You will need to have the following pre-requisites installed on your development workstation:

* [Node.js](https://nodejs.org/en/)
* [Download Ubuntu Server LTS 18.04](https://ubuntu.com/download/desktop)
  > This is needed only if you want to set up an Edge instance on your machine for development purposes
* [Enable Hyper-V in Windows](https://docs.microsoft.com/en-us/virtualization/hyper-v-on-windows/quick-start/enable-hyper-v)
* [Enable and install WSL](https://docs.microsoft.com/en-us/windows/wsl/install-win10)
* [Visual Studio Code Remote Development Extension](https://marketplace.visualstudio.com/items?itemName=ms-vscode-remote.vscode-remote-extensionpack)

## Steps ##

| #   | Step                                                                                                    |
| --- | ------------------------------------------------------------------------------------------------------- |
| 1.  | Install all required software and any optional software that is wanted                                  |
| 2.  | In VS Code, sign in to Azure using your company credentials                                             |
| 3.  | Set up a local Ubuntu Server VM with minimum 1 GB memory                                                |
| 4.  | Install the extension                                                                                   |
