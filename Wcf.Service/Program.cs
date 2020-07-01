using System;
using System.ServiceModel;
$if$ ($ext_Wizard_IsRestService$ == True)using System.ServiceModel.Web;$endif$

namespace $safeprojectname$
{
    class Program
    {
        private static void Main(string[] args)
    {
            $if$ ($ext_Wizard_IsRestService$ == True)var serviceHost = new WebServiceHost(typeof($ext_Wizard_ServiceImplClass$));
            $else$var serviceHost = new ServiceHost(typeof($ext_Wizard_ServiceImplClass$));
            $endif$serviceHost.Open();

            Console.WriteLine("Service is running. Press any key to exit...");
            Console.ReadKey();
        }
    }
}
