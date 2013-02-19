
using System.Linq;
using WCFDuplex.Database;
using WCFDuplex.Repository.Behavior;
namespace WCFDuplex.Repository
{
    public class StatusRepository : Repository<tbl_ChatUserStatus>, ICreateable<tbl_ChatUserStatus>, ISaveable
    {
        public StatusRepository(ChatDBDataContext context)
            : base(context)
        {
        }

        public override tbl_ChatUserStatus Get(string arg)
        {
            return (from m in Context.tbl_ChatUserStatus
                    where m.UserID.Equals(int.Parse(arg))
                    select m).SingleOrDefault();
        }

        public void Create(tbl_ChatUserStatus entity)
        {
            Context.tbl_ChatUserStatus.InsertOnSubmit(entity);
        }

        public void Save()
        {
            Context.SubmitChanges();
        }
    }
}
