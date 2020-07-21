# Deploy Cloud Industrial IoT Components

## Introduction

In this module we deploy the [Azure Industrial IoT](https://github.com/Azure/Industrial-IoT) services into our subscription.

> 👉 **Warning!** The deployment script tries to register 2 AAD applications in Azure Active Directory. Depending on your rights to the selected AAD tenant, this might fail. There are 2 options:
> * If you chose a AAD tenant from a list of tenants, restart the script and choose a different one from the list.
> * Alternatively, deploy a private AAD tenant in another subscription, restart the script and select to use it.

## Steps

Follow instructions in [Industrial IoT Github](https://github.com/Azure/Industrial-IoT/blob/master/docs/deploy/howto-deploy-all-in-one.md) to deploy the necessary PaaS and microservices.

⚠ **We're using the release 2.7.170, so make sure to run `git checkout release/2.7.170` after cloning the repository or [download the 2.7.170 archive here](https://github.com/Azure/Industrial-IoT/archive/release/2.7.170.zip)**

⚠ **By default, the deploy scripts includes simulators. To skip them, run the script via `.\deploy app`**

👉 **Tip!** Make sure you start your `PowerShell` with Administrator Rights.

👉 **Tip!** PowerShell 7 seems to cause some problems. Use the built-in PowerShell if possible.

👉 **Tip!** The setup will ask you if you want to save some credentials to the file-system. **Always do**, this will allow us to connect to your setup later.

## Links
[IIoT Engineering Tool](https://github.com/dacolgit/IIot-EngTool)
