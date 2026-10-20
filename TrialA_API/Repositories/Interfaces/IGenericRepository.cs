namespace TrialA_API.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task Add(T entity);
        void Delete(T entity);
        void Update(T entity);

        Task<IEnumerable<T>> GetAll();
        Task<T> GetById(int id);
    }
}
