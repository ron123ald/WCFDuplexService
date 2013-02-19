
namespace WCFDuplex.Repository.Behavior
{
    public interface IRemovable<T> where T : class
    {
        void Remove(T entity);
    }
}
