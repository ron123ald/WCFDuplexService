
using System;
namespace WCFDuplex.Database
{
    public abstract class DBContext<T> where T : class, IDisposable
    {
        private bool disposed = false;
        private T context;

        public T Context
        {
            get { return context; }
        }

        public DBContext(T context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    this.context.Dispose();
                }
                disposed = true;
            }
        }
    }
}
