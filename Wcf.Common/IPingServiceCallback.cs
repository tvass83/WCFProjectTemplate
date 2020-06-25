using System.ServiceModel;

namespace $safeprojectname$
{
    public interface IPingServiceCallback
    {
        [OperationContract(IsOneWay = true)]
        void Reply(string msgFromService);
    }
}
