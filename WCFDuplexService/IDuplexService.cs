
using System.ServiceModel;
using WCFDuplex.DataContracts;
using WCFDuplex.Exceptions.Faults;
namespace WCFDuplex
{
    [ServiceContract(CallbackContract = typeof(IServiceCallBack))]
    public interface IDuplexService
    {
        [OperationContract]
        bool KeepAlive();

        [OperationContract]
        [FaultContract(typeof(ServiceFaultException))]
        void Register(RegisterDataContract data);

        [OperationContract]
        [FaultContract(typeof(ServiceFaultException))]
        bool Login(LoginDataContract data);

        [OperationContract]
        [FaultContract(typeof(ServiceFaultException))]
        bool Logout(LoginDataContract data);
    }

    [ServiceContract]
    public interface IServiceCallBack
    {
        [OperationContract]
        void DoLoginCallBack(LoginDataContract data);
    }
}
