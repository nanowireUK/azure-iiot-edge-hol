using System;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Provisioning.Security;

namespace TPMProvisioningTool
{
  class Program
  {
    private static string _idScope;
    private static string _registrationId;

    static int Main(string[] args)
    {
      Console.WriteLine("-- TPM Provision Client --");

      if (args.Length > 0)
      {
        _idScope = args[0];
      }
      if (args.Length > 1)
      {
        _registrationId = args[1];
      }
      if (string.IsNullOrEmpty(_idScope) || string.IsNullOrEmpty(_registrationId))
      {
        Console.WriteLine("Usage: TPMProvisioningTool <IDScope> <RegistrationID>");
        return 1;
      }

      using (var security = new SecurityProviderTpmHsm(_registrationId))
      {
        // Note that the TPM simulator will create an NVChip file containing the simulated TPM state.
        Console.WriteLine("Extracting endorsement key...");
        string base64EK = Convert.ToBase64String(security.GetEndorsementKey());

        Console.WriteLine($"\tMechanism: TPM");
        Console.WriteLine($"\tEndorsement key: {base64EK}");
        Console.WriteLine($"\tRegistration ID: {_registrationId}");
        Console.WriteLine("\n\n");
      }

      return 0;
    }
  }
}
