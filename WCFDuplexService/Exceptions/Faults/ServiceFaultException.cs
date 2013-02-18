
using System.Runtime.Serialization;
namespace WCFDuplex.Exceptions.Faults
{
    [DataContract]
    public class ServiceFaultException
    {
        private string description;
        private string reason;

        public ServiceFaultException(string description, string reason)
        {
            this.description = description;
            this.reason = reason;
        }

        [DataMember]
        public string Description 
        {
            get { return description; }
            set { description = value; }
        }

        [DataMember]
        public string Reason
        {
            get { return reason; }
            set { reason = value; }
        }
    }
}
