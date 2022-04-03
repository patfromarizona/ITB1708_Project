
namespace TeamUP.Domain
{
    public interface IRepo<T> : IPagedRepo<T> where T : Entity
    {
    }
    public interface IPagedRepo<T> : IOrderedRepo<T> where T : Entity
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; }
        public bool HasNextPage { get; }
        public bool HasPreviousPage { get; }
        public int PageSize { get; set; }
    }
    public interface IOrderedRepo<T> : IFilteredRepo<T> where T : Entity
    {
        public string CurrentSort { get; set; }
        public string SortOrder(string propertyName);
    }
    public interface IFilteredRepo<T> : ICrudRepo<T> where T : Entity
    {
        public string CurrentFilter {get; set;}
    }
    public interface ICrudRepo<T> : IBaseRepo<T> where T : Entity
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
