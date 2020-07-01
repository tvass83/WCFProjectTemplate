using System.ServiceModel;
$if$ ($ext_Wizard_IsRestService$ == True)using System.ServiceModel.Web;
using $safeprojectname$.DTO;
$endif$
namespace $safeprojectname$
{
    $if$ ($ext_Wizard_IsDuplexService$ == True)[ServiceContract(CallbackContract = typeof($ext_Wizard_CallbackContract$))]
    $else$[ServiceContract]$endif$
    $if$ ($ext_Wizard_IsRestService$ == True)[XmlSerializerFormat]
    public interface $ext_Wizard_ServiceContract$
    {
        [WebGet(UriTemplate = "Ping?message={message}")]
        [OperationContract]
        CustomData Ping(string message);

        [WebInvoke]
        [OperationContract]
        CustomData Ping2(string message);
}
    $else$public interface $ext_Wizard_ServiceContract$
    {
        [OperationContract]
        void Ping(string message);
    }
    $endif$
}
