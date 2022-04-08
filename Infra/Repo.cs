using Microsoft.EntityFrameworkCore;
using TeamUP.Data;
using TeamUP.Domain;

namespace TeamUP.Infra
{
    public abstract class Repo<TDomain, TData> : PagedRepo<TDomain,TData> where TDomain : Entity<TData>, new() where TData : EntityData, new()
    {
        protected Repo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        internal protected bool contains(string? value, string s) => value?.Contains(s) ?? false;

    }


}
