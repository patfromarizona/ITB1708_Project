using Microsoft.EntityFrameworkCore;
using TeamUP.Data;
using TeamUP.Domain;

namespace TeamUP.Infra
{
    public abstract class OrderedRepo<TDomain, TData> : FilteredRepo<TDomain, TData> 
        where TDomain : Entity<TData>, new() where TData : EntityData, new()
    {
        protected OrderedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
    }
}
