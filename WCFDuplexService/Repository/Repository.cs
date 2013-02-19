
using System;
using WCFDuplex.Database;
namespace WCFDuplex.Repository
{
    public abstract class Repository<T> : DBContext<ChatDBDataContext>, IDisposable
    {

        public Repository(ChatDBDataContext context)
            : base(context)
        {
        }

        public abstract T Get(string arg);
    }
}
