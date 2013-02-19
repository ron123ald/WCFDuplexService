
namespace WCFDuplex.Repository.Behavior
{
    public interface ICreateable<T> where T : class
    {
        void Create(T entity);
    }
}
