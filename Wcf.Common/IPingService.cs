using System.ServiceModel;

namespace $safeprojectname$
{
    $if$ ($ext_Wizard_IsDuplexService$ == True)[ServiceContract(CallbackContract = typeof($ext_Wizard_CallbackContract$))]
    $else$[ServiceContract]
    $endif$public interface $ext_Wizard_ServiceContract$
    {
        [OperationContract]
        void Ping(string message);
    }
}
