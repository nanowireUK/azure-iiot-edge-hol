# Deploy Cloud Industrial IoT Components

## Introduction

In this module we deploy the [Azure Industrial IoT](https://github.com/Azure/Industrial-IoT) services into our subscription.

> The deployment script tries to register 2 AAD applications in Azure Active Directory. Depending on your rights to the selected AAD tenant, this might fail. There are 2 options:
>
> * If you chose a AAD tenant from a list of tenants, restart the script and choose a different one from the list.
> * Alternatively, deploy a private AAD tenant in another subscription, restart the script and select to use it.

## Steps

Follow instructions in [Industrial IoT Github](https://github.com/Azure/Industrial-IoT/blob/master/docs/deploy/howto-deploy-all-in-one.md) to deploy the necessary PaaS and microservices.

## Links
[IIoT Engineering Tool](https://github.com/dacolgit/IIot-EngTool)
