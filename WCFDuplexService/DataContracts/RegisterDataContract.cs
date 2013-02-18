
using System.Runtime.Serialization;
namespace WCFDuplex.DataContracts
{
    [DataContract]
    public class RegisterDataContract : LoginDataContract
    {
        private string address;
        private string fullname;
        private string emailAddress;
        private string phoneNumber;
        
        public RegisterDataContract(string address, string fullName, string emailAddress, string phoneNumber, string username, string password)
            : base(username, password)
        {
            this.address = address;
            this.fullname = fullName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
        }

        [DataMember]
        public string Address;

        [DataMember]
        public string FullName;

        [DataMember]
        public string EmailAddress;

        [DataMember]
        public string PhoneNumber;
    }
}
