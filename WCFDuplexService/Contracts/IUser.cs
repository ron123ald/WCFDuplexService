
using WCFDuplex.DataContracts;
using WCFDuplex.Tools;
namespace WCFDuplex.Contracts
{
    public interface IUser
    {
        int RegisterProfile(RegisterDataContract register);

        int RegisterLogin(LoginDataContract login, int profileId);

        void RegisterStatus(ChatState status, int loginId);

        bool Login(LoginDataContract login);

        bool Logout(LoginDataContract logout);

        bool ChangeUserStatus(ChatState status, int userId);
    }
}
