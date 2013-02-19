
using System;
using System.Collections.Generic;
using System.Linq;
using WCFDuplex.Database;
using WCFDuplex.Repository.Behavior;
namespace WCFDuplex.Repository
{
    public class ProfileRepository : Repository<tbl_ChatUserProfile>, IGetListable<tbl_ChatUserProfile>, ICreateable<tbl_ChatUserProfile>, ISaveable
    {
        public ProfileRepository(ChatDBDataContext context)
            : base(context)
        {
        }

        public override tbl_ChatUserProfile Get(string arg)
        {
            return (from m in Context.tbl_ChatUserProfiles
                    where m.EmailAddess.Equals(arg, StringComparison.InvariantCultureIgnoreCase)
                    select m).SingleOrDefault();
        }

        public List<tbl_ChatUserProfile> GetList(object arg)
        {
            return (from m in Context.tbl_ChatUserProfiles
                    where m.EmailAddess.Equals((string)arg, StringComparison.InvariantCultureIgnoreCase)
                    select m).ToList();
        }

        public List<tbl_ChatUserProfile> Get()
        {
            return (from m in Context.tbl_ChatUserProfiles
                    select m).ToList();
        }

        public void Create(tbl_ChatUserProfile entity)
        {
            Context.tbl_ChatUserProfiles.InsertOnSubmit(entity);
        }

        public void Save()
        {
            Context.SubmitChanges();
        }
    }
}
