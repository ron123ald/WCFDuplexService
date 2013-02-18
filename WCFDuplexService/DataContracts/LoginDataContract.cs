
using System.Runtime.Serialization;
namespace WCFDuplex.DataContracts
{
    [DataContract]
    public class LoginDataContract
    {
        private string username;
        private string password;

        public LoginDataContract(string username)
        {
            this.username = username;
            this.password = string.Empty;
        }

        public LoginDataContract(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [DataMember]
        public string Username
        {
            get { return username; }
            set { username = value; }
        }

        [DataMember]
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
    }
}
