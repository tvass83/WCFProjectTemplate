using System.ServiceModel;

namespace $safeprojectname$
{
    [ServiceContract(CallbackContract = typeof(IPingServiceCallback))]
    public interface IPingService
    {
        [OperationContract]
        void Ping(string message);
    }
}
