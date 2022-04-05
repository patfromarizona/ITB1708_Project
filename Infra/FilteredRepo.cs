using Microsoft.EntityFrameworkCore;
using TeamUP.Data;
using TeamUP.Domain;

namespace TeamUP.Infra
{
    public abstract class FilteredRepo<TDomain, TData> : CrudRepo<TDomain, TData> 
        where TDomain : Entity<TData>, new () where TData : EntityData, new ()
    {
        protected FilteredRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        public string? CurrentFilter { get; set; }

        protected internal override IQueryable<TData> createSql() => addFilter(base.createSql());
        internal virtual IQueryable<TData> addFilter(IQueryable<TData> q) => q;

    }
}
