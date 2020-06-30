using System;
$if$ ($ext_Wizard_IsDuplexService$ == True)using System.ServiceModel;$endif$
using $ext_CommonProj$;

namespace $safeprojectname$
{
    internal class $ext_Wizard_ServiceImplClass$ : $ext_Wizard_ServiceContract$
    {
        $if$ ($ext_Wizard_IsDuplexService$ == True)public void Ping(string message)
        {
            Console.WriteLine($"Operation '{nameof(Ping)}' was called with argument '{message}'.");
            Console.WriteLine($"Invoking callback operation '{nameof($ext_Wizard_CallbackContract$.Reply)}' with message '{message}'.");
            var cbChannel = OperationContext.Current.GetCallbackChannel<$ext_Wizard_CallbackContract$>();
            cbChannel.Reply(message);
        }
        $else$public void Ping(string message)
        {
            Console.WriteLine($"Operation '{nameof(Ping)}' was called with argument '{message}'.");
        }$endif$
}
}