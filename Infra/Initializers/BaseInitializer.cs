using Microsoft.EntityFrameworkCore;
using TeamUP.Data;

namespace TeamUP.Infra.Initializers
{
    public abstract class BaseInitializer<TData> where TData : EntityData
    {
        internal protected DbContext? db;
        internal protected DbSet<TData>? set;
        protected BaseInitializer(DbContext? c, DbSet<TData>? s)
        {
            db = c;
            set = s;
        }
        public void Init()
        {
            if (set?.Any() ?? true) return;
            set.AddRange(getEntities);
            db?.SaveChanges();
        }
        protected abstract IEnumerable<TData> getEntities { get; }
          
    }		

    public static class TeamUpDbInitializer
    {
        public static void Init(TeamUPDb? db)
        {
            new StudentsInitializer(db).Init();
            new TeamWorksInitializer(db).Init();    
            new UniversitiesInitializer(db).Init();
            new LocationsInitializer(db).Init();
        }
    }
}
