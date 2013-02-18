
using System.Collections.Generic;
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
    }
}
