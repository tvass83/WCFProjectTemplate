using System;
$if$ ($ext_Wizard_IsDuplexService$ == True)using System.ServiceModel;
$endif$using $ext_CommonProj$;
$if$ ($ext_Wizard_RestOnDuplexOff$ == True)
using System.Collections.Generic;
using $ext_CommonProj$.DTO;$endif$

namespace $safeprojectname$
{
    internal class $ext_Wizard_ServiceImplClass$ : $ext_Wizard_ServiceContract$
    {
        $if$ ($ext_Wizard_RestOnDuplexOff$ == True)public CustomData Ping(string message)
        {
            Console.WriteLine($"Operation '{nameof(Ping)}' was called with argument '{message}'");

            return new CustomData
            {
                Message = message,
                Value = new List<string>() { "item1", "item2" }
            };
        }$endif$
        $if$ ($ext_Wizard_RestOffDuplexOn$ == True)public void Ping(string message)
        {
            Console.WriteLine($"Operation '{nameof(Ping)}' was called with argument '{message}'.");
            Console.WriteLine($"Invoking callback operation '{nameof($ext_Wizard_CallbackContract$.Reply)}' with message '{message}'.");
            var cbChannel = OperationContext.Current.GetCallbackChannel<$ext_Wizard_CallbackContract$>();
            cbChannel.Reply(message);
        }$endif$
        $if$ ($ext_Wizard_RestOffDuplexOff$ == True)public void Ping(string message)
        {
            Console.WriteLine($"Operation '{nameof(Ping)}' was called with argument '{message}'.");
        }$endif$
    }
}