
using System.Collections.Generic;
using System.ServiceModel;
namespace WCFDuplex.Collection
{
    public class CallBackChannelCollections
    {
        private Dictionary<string, IServiceCallBack> userChannels;
        private static CallBackChannelCollections _instance;
        public static CallBackChannelCollections InstanceContext
        {
            get { return _instance ?? (_instance = (new CallBackChannelCollections())); }
        }

        public int Count
        {
            get { return userChannels.Count; }
        }

        private CallBackChannelCollections()
        {
            userChannels = new Dictionary<string, IServiceCallBack>();
        }

        public bool Exists(string username)
        {
            bool flag = false;
            lock (userChannels)
            {
                foreach(var item in userChannels)
                {
                    if (item.Key.Equals(username, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        flag = true;
                        break;
                    }
                } 
            }
            return flag;
        }

        public bool Exists(IServiceCallBack channel)
        {
            bool flag = false;
            lock (userChannels)
            {
                foreach (var item in userChannels)
                {
                    if (item.Value.Equals(channel))
                    {
                        flag = true;
                        break;
                    }
                }
            }
            return flag;
        }

        public void Add(string username, IServiceCallBack channel)
        {
            if (!userChannels.ContainsKey(username) && 
                !userChannels.ContainsValue(channel))
            {
                userChannels.Add(username, channel);
            }
        }

        public void Remove(string username)
        {
            if (userChannels.ContainsKey(username))
            {
                userChannels.Remove(username);
            }
        }

        public IServiceCallBack Get(string username)
        {
            return userChannels[username];
        }

        public IList<IServiceCallBack> GetExcept(string username)
        {
            IList<IServiceCallBack> channels = new List<IServiceCallBack>();
            lock (userChannels)
            {
                foreach (var item in userChannels)
                {
                    if (!item.Key.Equals(username, System.StringComparison.InvariantCultureIgnoreCase))
                    {
                        channels.Add(item.Value); 
                    }
                } 
            }
            return channels;
        }
    }
}
