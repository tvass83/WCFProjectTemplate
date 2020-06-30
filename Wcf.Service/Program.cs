using System;
using System.ServiceModel;

namespace $safeprojectname$
{
    class Program
    {
        private static void Main(string[] args)
        {
            ServiceHost serviceHost = new ServiceHost(typeof($ext_Wizard_ServiceImplClass$));
            serviceHost.Open();

            Console.WriteLine("Service is running. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
