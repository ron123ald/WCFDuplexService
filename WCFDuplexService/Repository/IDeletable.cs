
namespace WCFDuplex.Repository
{
    public interface IDeletable<T> where T : class
    {
        void Delete(T entity);
    }
}
