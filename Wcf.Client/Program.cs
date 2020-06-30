using System;
using System.ServiceModel;
using $ext_CommonProj$;

namespace $safeprojectname$
{
    class Program
    {
        static void Main(string[] args)
    {
            $if$ ($ext_Wizard_IsDuplexService$ == True)using (var channelFactory = new DuplexChannelFactory<$ext_Wizard_ServiceContract$>(new $ext_Wizard_CallbackImplClass$(), "NetTcpEndpoint"))
            $else$using (var channelFactory = new ChannelFactory<$ext_Wizard_ServiceContract$>("NetTcpEndpoint"))
            $endif${
                var pingService = channelFactory.CreateChannel();
                string msg = Guid.NewGuid().ToString();
                Console.WriteLine($"Calling '{nameof($ext_Wizard_ServiceContract$.Ping)}' over TCP with message '{msg}'.");
                pingService.Ping(msg);
        }

            $if$ ($ext_Wizard_IsDuplexService$ == True)using (var channelFactory = new DuplexChannelFactory<$ext_Wizard_ServiceContract$>(new $ext_Wizard_CallbackImplClass$(), "NamedPipeEndpoint"))
            $else$using (var channelFactory = new ChannelFactory<$ext_Wizard_ServiceContract$>("NamedPipeEndpoint"))
            $endif${
                var pingService = channelFactory.CreateChannel();
                string msg = Guid.NewGuid().ToString();
                Console.WriteLine($"Calling '{nameof($ext_Wizard_ServiceContract$.Ping)}' over named pipe with message '{msg}'.");
                pingService.Ping(msg);
            }
        }
    }
}
