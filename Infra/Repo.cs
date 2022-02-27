
using Microsoft.EntityFrameworkCore;
using TeamUP.Data;

namespace TeamUP.Domain
{
    public abstract class Repo<TDomain, TData> : IRepo<TDomain> where TDomain : Entity<TData> where TData : EntityData, new()
    {
        private readonly DbContext db;
        private readonly DbSet<TData> set;
        protected Repo(DbContext c, DbSet<TData> s)
        {
            db = c;
            set = s;
        }
        public bool Add(TDomain obj)=> AddAsync(obj).GetAwaiter().GetResult();
        public async Task<bool> AddAsync(TDomain obj)
        {
            var d =obj.Data;
            try { 
            await set.AddAsync(d);
            await db.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool Delete(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> DeleteAsync(string id)
        {
            throw new NotImplementedException();
        }
        public List<TDomain> Get()
        {
            throw new NotImplementedException();
        }
        public TDomain Get(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<TDomain> GetAsync(string id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<TDomain>> GetAsync()
        {
            throw new NotImplementedException();
        }
        public bool Update(TDomain obj)
        {
            throw new NotImplementedException();
        }
        public async Task<bool> UpdateAsync(TDomain obj)
        {
            throw new NotImplementedException();
        }
    }


}
