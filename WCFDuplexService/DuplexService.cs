
using System;
using System.ServiceModel;
using System.ServiceModel.Activation;
using WCFDuplex.Collection;
using WCFDuplex.Contracts;
using WCFDuplex.DataContracts;
using WCFDuplex.Exceptions.Faults;
using WCFDuplex.Services;
using WCFDuplex.Tools;
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
            int profileId = 0;
            int loginId = 0;
            try
            {
                profileId = user.RegisterProfile(data);
            }
            catch (Exception Ex)
            {
                ServiceFaultException SFEx = new ServiceFaultException(Ex.Message, "Register");
                throw new FaultException<ServiceFaultException>(SFEx, new FaultReason(SFEx.Description), new FaultCode("Register"));
            }
            finally
            {
                LoginDataContract loginDetail = new LoginDataContract(data.Username, data.Password);
                loginId = user.RegisterLogin(loginDetail, profileId);

                user.RegisterStatus(ChatState.INITIAL, loginId);

                OperationContext.Current.GetCallbackChannel<IServiceCallBack>().DoLoginCallBack(loginDetail);
            }
        }

        public bool Login(LoginDataContract data)
        {
            bool response = false;
            if (!callBackCollections.Exists(data.Username))
            {
                callBackCollections.Add(data.Username, OperationContext.Current.GetCallbackChannel<IServiceCallBack>());
            }

            IUser user = new UserService();
            user.Login(data);
            /// notify other online users
            Action<string, ChatState> Notify = new Action<string, ChatState>(ServiceUtils.CallBackNotify);
            Notify.Invoke(data.Username, ChatState.ONLINE);

            return response;
        }

        public bool Logout(LoginDataContract data)
        {
            bool response = false;
            if (callBackCollections.Exists(data.Username))
            {
                callBackCollections.Remove(data.Username);
            }

            IUser user = new UserService();
            user.Logout(data);
            /// notify other online users
            Action<string, ChatState> Notify = new Action<string, ChatState>(ServiceUtils.CallBackNotify);
            Notify.Invoke(data.Username, ChatState.OFFLINE);

            return response;
        }
    }
}
