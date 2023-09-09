namespace Common.Repository
{
    public interface IRepositoryBase<T>
    {
        public IEnumerable<T> GetAll();
        public T? GetById(int id);
        public void Update(T entity);
        public void Delete(int id);
    }
}
