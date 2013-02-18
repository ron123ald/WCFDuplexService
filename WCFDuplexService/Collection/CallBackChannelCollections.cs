
using System.Collections.Generic;
using System.ServiceModel;
namespace WCFDuplex.Collection
{
    public class CallBackChannelCollections
    {
        private Dictionary<string, IContextChannel> userCallBackContexts;
        private static CallBackChannelCollections _instance;
        public static CallBackChannelCollections InstanceContext
        {
            get { return _instance ?? (_instance = (new CallBackChannelCollections())); }
        }

        private CallBackChannelCollections()
        {
            userCallBackContexts = new Dictionary<string, IContextChannel>();
        }


    }
}
