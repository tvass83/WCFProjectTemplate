using System.ServiceModel;

namespace $safeprojectname$
{
    public interface $ext_Wizard_CallbackContract$
    {
        [OperationContract(IsOneWay = true)]
        void Reply(string msgFromService);
    }
}
