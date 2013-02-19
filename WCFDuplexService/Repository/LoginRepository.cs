
using System;
using System.Linq;
using WCFDuplex.Database;
using WCFDuplex.Repository.Behavior;
namespace WCFDuplex.Repository
{
    public class LoginRepository : Repository<tbl_ChatUserLogin>, ICreateable<tbl_ChatUserLogin>, ISaveable
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

        public void Create(tbl_ChatUserLogin entity)
        {
            Context.tbl_ChatUserLogins.InsertOnSubmit(entity);
        }

        public void Save()
        {
            Context.SubmitChanges();
        }
    }
}
