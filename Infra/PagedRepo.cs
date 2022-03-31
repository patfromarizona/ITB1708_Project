using Microsoft.EntityFrameworkCore;
using TeamUP.Data;
using TeamUP.Domain;

namespace TeamUP.Infra
{
    public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData> 
        where TDomain : Entity<TData>, new() where TData : EntityData, new()
    {
        protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
