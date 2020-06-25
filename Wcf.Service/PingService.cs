using System;
using System.ServiceModel;
using $ext_CommonProj$;

namespace $safeprojectname$
{
    internal class PingService : IPingService
    {
        public void Ping(string message)
        {
            Console.WriteLine($"Operation '{nameof(Ping)}' was called with argument '{message}'");
            IPingServiceCallback cbChannel = OperationContext.Current.GetCallbackChannel<IPingServiceCallback>();
            cbChannel.Reply(message);
        }
    }
}
