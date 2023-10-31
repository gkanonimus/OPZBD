public interface IRepository<T> where T : class
{
    void Create(T entity);
    void Update(T entity);
    void Delete(T entity);
    T GetById(int id);
    List<T> GetAll();
}
