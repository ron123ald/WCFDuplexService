
using System;
using System.Linq;
using WCFDuplex.Database;
namespace WCFDuplex.Repository
{
    public class LoginRepository : Repository<tbl_ChatUserLogin>, IInsertable<tbl_ChatUserLogin>, ISaveable
    {
        public LoginRepository(ChatDBDataContext context)
            : base(context)
        {
        }

        public override tbl_ChatUserLogin Get(string arg)
        {
            return (from m in Context.tbl_ChatUserLogins
                    where m.Username.Equals(arg, StringComparison.InvariantCultureIgnoreCase)
                    select m).SingleOrDefault();
        }

        public void Insert(tbl_ChatUserLogin entity)
        {
            Context.tbl_ChatUserLogins.InsertOnSubmit(entity);
        }

        public void Save()
        {
            Context.SubmitChanges();
        }
    }
}
