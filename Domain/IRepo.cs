
namespace TeamUP.Domain
{
    public interface IRepo<T> : IBaseRepo<T> where T : Entity
    {
    }

    public interface IBaseRepo<T> where T : Entity
    {
        //CRUD
        bool Add(T obj);
        List<T> Get();
        T Get(string id);
        bool Update(T obj);
        bool Delete(string id);

        Task<bool> AddAsync(T obj);
        Task<T> GetAsync(string id);
        Task<List<T>> GetAsync();
        Task<bool> UpdateAsync(T obj);
        Task<bool> DeleteAsync(string id);      
        
    }
}
