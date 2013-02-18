
using System;
using WCFDuplex.Database;
namespace WCFDuplex.Repository
{
    public abstract class Repository<T> : DBContext<ChatDBDataContext>, IDisposable
    {

        public Repository(ChatDBDataContext dbContext)
            : base(dbContext)
        {
        }

        public abstract T Get(string arg);
    }
}
