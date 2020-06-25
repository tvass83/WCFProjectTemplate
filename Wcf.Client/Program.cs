using System;
using System.ServiceModel;
using $ext_CommonProj$;

namespace $safeprojectname$
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var channelFactory = new DuplexChannelFactory<IPingService>(new PingServiceCallback(), "PingEndpoint"))
            {
                IPingService pingService = channelFactory.CreateChannel();
                Console.WriteLine($"Calling {nameof(IPingService.Ping)} over TCP.");
                pingService.Ping(Guid.NewGuid().ToString());
            }

            using (var channelFactory = new DuplexChannelFactory<IPingService>(new PingServiceCallback(), "LocalPingEndpoint"))
            {
                IPingService pingService = channelFactory.CreateChannel();
                Console.WriteLine($"Calling {nameof(IPingService.Ping)} over named pipe.");
                pingService.Ping("local");
            }
        }
    }
}
