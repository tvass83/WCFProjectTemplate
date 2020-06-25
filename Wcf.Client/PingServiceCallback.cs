using System;
using $ext_CommonProj$;

namespace $safeprojectname$
{
    internal class PingServiceCallback : IPingServiceCallback
    {
        public void Reply(string msgFromService)
        {
            Console.WriteLine($"Operation '{nameof(Reply)}' was called with message '{msgFromService}'");
        }
    }
}
