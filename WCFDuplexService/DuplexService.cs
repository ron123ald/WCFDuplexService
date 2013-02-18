
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using WCFDuplex.Collection;
using WCFDuplex.Contracts;
using WCFDuplex.DataContracts;
using WCFDuplex.Exceptions.Faults;
using WCFDuplex.Services;
namespace WCFDuplex
{
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class DuplexService : IDuplexService
    {
        private CallBackChannelCollections callBackCollections;

        public DuplexService()
        {
            callBackCollections = (CallBackChannelCollections.InstanceContext);
        }

        public bool KeepAlive()
        {
            return true;
        }

        public void Register(RegisterDataContract data)
        {
            if (data == null)
                throw new ArgumentNullException("data", "data cannot be null");

            IUser user = new UserService();
            try
            {
                user.RegisterProfile(data);
            }
            catch (Exception Ex)
            {
                ServiceFaultException SFEx = new ServiceFaultException(Ex.Message, "Register");
                throw new FaultException<ServiceFaultException>(SFEx, new FaultReason(SFEx.Description), new FaultCode("Register"));
            }
            finally
            {
                LoginDataContract loginDetail = new LoginDataContract(data.Username, data.Password);
                user.RegisterLogin(loginDetail, data.EmailAddress);
                OperationContext.Current.GetCallbackChannel<IServiceCallBack>().DoLoginCallBack(loginDetail);
            }
        }

        public bool Login(LoginDataContract data)
        {
            throw new NotImplementedException();
        }

        public bool Logout(LoginDataContract data)
        {
            throw new NotImplementedException();
        }
    }
}
