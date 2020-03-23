using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Provisioning.Security;

namespace TPMProvisioningTool
{
  class Program
  {
    static int Main(string[] args)
    {

      // The CTOR of Tpm2Lib prints errors to STDOUT, not very nice
      var savedOutStream = Console.Out;
      Console.SetOut(Console.Error);
      using (var security = new SecurityProviderTpmHsm(string.Empty))
      {
        Console.SetOut(savedOutStream);

        string base64EK = Convert.ToBase64String(security.GetEndorsementKey());
        Console.WriteLine($"{base64EK}");
      }

      return 0;
    }
  }

  public sealed class NullTextWriter : TextWriter
  {
    public override Encoding Encoding
    {
      get
      {
        return Encoding.UTF8;
      }
    }
  }
}
