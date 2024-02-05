namespace Nexu_SMS.Repository
{
    public interface IRepositoty<T> where T : class
    {
        T Get(string id);
        List<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(string id);
    }
}
