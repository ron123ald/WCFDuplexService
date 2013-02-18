
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

        public void RegisterProfile(RegisterDataContract registerData)
        {
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
                    profileRepo.Insert(profile);
                    profileRepo.Save();
                }
                else
                    throw new Exception("Profile Exists");
            }
        }

        public void RegisterLogin(LoginDataContract login, string emailAddress)
        {
        }

        public void Login(LoginDataContract login)
        {
            throw new System.NotImplementedException();
        }

        public void Logout(LoginDataContract logout)
        {
            throw new System.NotImplementedException();
        }
    }
}