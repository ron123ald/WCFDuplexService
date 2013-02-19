
using System;
using System.Collections.Generic;
using WCFDuplex.Contracts;
using WCFDuplex.Database;
using WCFDuplex.DataContracts;
using WCFDuplex.Repository;
using WCFDuplex.Tools;
namespace WCFDuplex.Services
{
    public class UserService : IUser
    {
        public UserService()
        {
        }

        public int RegisterProfile(RegisterDataContract registerData)
        {
            int profileId = 0;
            using (ProfileRepository profileRepo = new ProfileRepository(new ChatDBDataContext())) 
            {
                List<tbl_ChatUserProfile> profiles = profileRepo.Get();
                if (!ServiceUtils.IsExist<tbl_ChatUserProfile>(profiles, registerData.EmailAddress))
                {
                    tbl_ChatUserProfile profile = new tbl_ChatUserProfile
                    {
                        Address = registerData.Address,
                        EmailAddess = registerData.EmailAddress,
                        FullName = registerData.FullName,
                        PhoneNumber = registerData.PhoneNumber
                    };
                    profileRepo.Create(profile);
                    profileRepo.Save();

                    profileId = profileRepo.Get(registerData.EmailAddress).id;
                }
                else
                    throw new Exception("Profile Exists");
            }
            return profileId;
        }

        public int RegisterLogin(LoginDataContract loginData, int profileId)
        {
            int loginId = 0;
            using (LoginRepository loginRepo = new LoginRepository(new ChatDBDataContext()))
            {
                loginRepo.Create(new tbl_ChatUserLogin()
                {
                    Username = loginData.Username, Password = loginData.Password, ProfileId = profileId
                });
                loginRepo.Save();

                loginId = loginRepo.Get(loginData.Username).Id;
            }
            return loginId;
        }

        public void RegisterStatus(ChatState status, int loginId)
        {
            using (StatusRepository statusRepo = new StatusRepository(new ChatDBDataContext()))
            {
                statusRepo.Create(new tbl_ChatUserStatus()
                {
                    Status = (int)status, UserID = loginId
                });
                statusRepo.Save();
            }
        }

        public bool Login(LoginDataContract loginData)
        {
            bool flag = false;
            using (LoginRepository loginRepo = new LoginRepository(new ChatDBDataContext()))
            {
                tbl_ChatUserLogin login = loginRepo.Get(loginData.Username);
                if (login != null)
                {
                    flag = ChangeUserStatus(ChatState.ONLINE, login.Id);
                }
            }
            return flag;
        }

        public bool Logout(LoginDataContract logoutData)
        {
            bool flag = false;
            using (LoginRepository loginRepo = new LoginRepository(new ChatDBDataContext()))
            {
                tbl_ChatUserLogin login = loginRepo.Get(logoutData.Username);
                if (login != null)
                {
                    flag = ChangeUserStatus(ChatState.OFFLINE, login.Id);
                }
            }
            return flag;
        }

        public bool ChangeUserStatus(ChatState status, int userId)
        {
            bool flag = false;
            using (StatusRepository statusRepo = new StatusRepository(new ChatDBDataContext()))
            {
                tbl_ChatUserStatus statusRec = statusRepo.Get(userId.ToString());
                statusRec.Status = (int)status;
                statusRepo.Save();

                if (statusRepo.Get(userId.ToString()).Status.Equals((int)status))
                    flag = true;
            }
            return flag;
        }
    }
}