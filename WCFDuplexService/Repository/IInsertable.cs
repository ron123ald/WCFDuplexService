
namespace WCFDuplex.Repository
{
    public interface IInsertable<T> where T : class
    {
        void Insert(T entity);
    }
}
