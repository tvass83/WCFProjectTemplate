using System;
$if$ ($ext_Wizard_IsRestService$ == True)using $ext_CommonProj$.DTO;
using System.Diagnostics;
using System.Net;
using System.Xml.Serialization;$endif$
using System.ServiceModel;
using $ext_CommonProj$;

namespace $safeprojectname$
{
    class Program
    {
        static void Main(string[] args)
        {
            $if$ ($ext_Wizard_IsRestService$ == True)// Method 1
            using (var channelFactory = new ChannelFactory<$ext_Wizard_ServiceContract$>("RestEndpoint"))
            {
                var proxy = channelFactory.CreateChannel();
                Console.WriteLine($"Calling {nameof($ext_Wizard_ServiceContract$.Ping)} over http via ChannelFactory.");
                var reply = proxy.Ping(Guid.NewGuid().ToString());
                Console.WriteLine($"\tService replied with: '{reply.Message}'");
                Console.WriteLine($"Calling {nameof($ext_Wizard_ServiceContract$.Ping2)} over http via ChannelFactory.");
                reply = proxy.Ping2(Guid.NewGuid().ToString());
                Console.WriteLine($"\tService replied with: '{reply.Message}'");
            }

            // Method 2 - HTTP GET
            var ser = new XmlSerializer(typeof(CustomData));
            var req = WebRequest.Create($"http://localhost:9999/$ext_Wizard_ServiceImplClass$/Ping?message={Guid.NewGuid().ToString()}");
        
            Console.WriteLine($"Calling {nameof($ext_Wizard_ServiceContract$.Ping)} over http via HttpWebRequest (GET)");
            
            using (var resp = req.GetResponse())
            {
                var ret = (CustomData)ser.Deserialize(resp.GetResponseStream());
                Console.WriteLine($"\tService replied with: '{ret.Message}'");
            }

            // HTTP POST
            ser = new XmlSerializer(typeof(string));
            req = WebRequest.Create($"http://localhost:9999/$ext_Wizard_ServiceImplClass$/Ping2");
            req.Method = WebRequestMethods.Http.Post;
            req.ContentType = "text/xml";

            ser.Serialize(req.GetRequestStream(), Guid.NewGuid().ToString());

            Console.WriteLine($"Calling {nameof($ext_Wizard_ServiceContract$.Ping)} over http via HttpWebRequest (POST)");

            using (var resp = req.GetResponse())
            {
                ser = new XmlSerializer(typeof(CustomData));
                var ret = (CustomData)ser.Deserialize(resp.GetResponseStream());
                Console.WriteLine($"\tService replied with: '{ret.Message}'");
            }

            // Method 3 - HTTP GET
            string uri = $"http://localhost:9999/$ext_Wizard_ServiceImplClass$/Ping?message={Guid.NewGuid().ToString()}";
            Console.WriteLine("Opening the following URI with the default browser:");
            Console.WriteLine($"\t{uri}");
            
            var p = new Process();
            p.StartInfo = new ProcessStartInfo(uri);
            p.Start();$endif$
            $if$ ($ext_Wizard_RestOffDuplexOn$ == True)using (var channelFactory = new DuplexChannelFactory<$ext_Wizard_ServiceContract$>(new $ext_Wizard_CallbackImplClass$(), "NetTcpEndpoint"))
            {
                var proxy = channelFactory.CreateChannel();
                string msg = Guid.NewGuid().ToString();
                Console.WriteLine($"Calling '{nameof($ext_Wizard_ServiceContract$.Ping)}' over TCP with message '{msg}' via DuplexChannelFactory.");
                proxy.Ping(msg);
            }

            using (var channelFactory = new DuplexChannelFactory<$ext_Wizard_ServiceContract$>(new $ext_Wizard_CallbackImplClass$(), "NamedPipeEndpoint"))
            {
                var proxy = channelFactory.CreateChannel();
                string msg = Guid.NewGuid().ToString();
                Console.WriteLine($"Calling '{nameof($ext_Wizard_ServiceContract$.Ping)}' over named pipe with message '{msg}' via DuplexChannelFactory.");
                proxy.Ping(msg);
            }$endif$
            $if$ ($ext_Wizard_RestOffDuplexOff$ == True)using (var channelFactory = new ChannelFactory<$ext_Wizard_ServiceContract$>("NetTcpEndpoint"))
            {
                var proxy = channelFactory.CreateChannel();
                string msg = Guid.NewGuid().ToString();
                Console.WriteLine($"Calling '{nameof($ext_Wizard_ServiceContract$.Ping)}' over TCP with message '{msg}' via ChannelFactory.");
                proxy.Ping(msg);
            }

            using (var channelFactory = new ChannelFactory<$ext_Wizard_ServiceContract$>("NamedPipeEndpoint"))
            {
                var proxy = channelFactory.CreateChannel();
                string msg = Guid.NewGuid().ToString();
                Console.WriteLine($"Calling '{nameof($ext_Wizard_ServiceContract$.Ping)}' over named pipe with message '{msg}' via ChannelFactory.");
                proxy.Ping(msg);
            }$endif$
        }
    }
}
