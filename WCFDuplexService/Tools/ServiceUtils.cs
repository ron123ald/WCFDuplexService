
using System.Collections.Generic;
using System.ServiceModel;
using WCFDuplex.Collection;
using WCFDuplex.Database;
namespace WCFDuplex.Tools
{
    public static class ServiceUtils
    {
        public static bool IsExist<T>(object context, string data)
        {
            bool flag = false;

            switch (typeof(T).Name)
            {
                case "tbl_ChatUserLogin":
                    for (int i = 0; i < ((List<tbl_ChatUserLogin>)context).Count; i++)
                    {
                        if (((List<tbl_ChatUserLogin>)context)[i].Username.Equals(data, System.StringComparison.InvariantCultureIgnoreCase))
                        {
                            flag = true;
                            break;
                        }
                    }
                    break;
                case "tbl_ChatUserProfile":
                    for (int i = 0; i < ((List<tbl_ChatUserProfile>)context).Count; i++)
                    {
                        if (((List<tbl_ChatUserProfile>)context)[i].EmailAddess.Equals(data, System.StringComparison.InvariantCultureIgnoreCase))
                        {
                            flag = true;
                            break;
                        }
                    }
                    break;
                default:
                    break;
            }

            return flag;
        }

        public static void CallBackNotify(string username, ChatState status)
        {
            IList<IServiceCallBack> channels = (CallBackChannelCollections.InstanceContext).GetExcept(username);
            switch (status)
            {
                case ChatState.ONLINE:
                    for (int i = 0; i < channels.Count; i++)
                    {
                        try
                        {
                            channels[i].DoAddOnlineUser(username);
                        }
                        catch 
                        {
                        }
                    }
                    break;
                case ChatState.OFFLINE:
                    for (int i = 0; i < channels.Count; i++)
                    {
                        try
                        {
                            channels[i].DoRemoveOfflineUser(username);
                        }
                        catch
                        {
                        }
                    }
                    break;
                case ChatState.CONNECTING:
                    break;
                case ChatState.CONNECTED:
                    break;
                case ChatState.DISCONNECTED:
                    break;
                default:
                    break;
            }
        }
    }
}
