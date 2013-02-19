
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

        public RegisterDataContract(string address, string fullName, string emailAddress, string phoneNumber, string username)
            : base(username)
        {
            this.address = address;
            this.fullname = fullName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
        }

        public RegisterDataContract(string address, string fullName, string emailAddress, string phoneNumber, string username, string password)
            : base(username, password)
        {
            this.address = address;
            this.fullname = fullName;
            this.emailAddress = emailAddress;
            this.phoneNumber = phoneNumber;
        }

        [DataMember]
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        [DataMember]
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }

        [DataMember]
        public string EmailAddress
        {
            get { return emailAddress; }
            set { emailAddress = value; }
        }

        [DataMember]
        public string PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; }
        }
    }
}
