
using WCFDuplex.DataContracts;
namespace WCFDuplex.Contracts
{
    public interface IUser
    {
        void RegisterProfile(RegisterDataContract register);

        void RegisterLogin(LoginDataContract login, string emailAddress);

        void Login(LoginDataContract login);

        void Logout(LoginDataContract logout);
    }
}
