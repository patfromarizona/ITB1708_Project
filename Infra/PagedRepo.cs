using Microsoft.EntityFrameworkCore;
using TeamUP.Data;
using TeamUP.Domain;

namespace TeamUP.Infra
{
    public abstract class PagedRepo<TDomain, TData> : OrderedRepo<TDomain, TData>
        where TDomain : Entity<TData>, new() where TData : EntityData, new()
    {
        internal int skippedItemsCount => PageSize * PageIndex;
        internal static int itemsCountInPage = 10;

        public int PageIndex { get; set; }
        public int TotalPages => totalPages;
        public bool HasNextPage => PageIndex < TotalPages - 1;
        public bool HasPreviousPage => PageIndex > 0;
        public int PageSize { get; set; } = itemsCountInPage;

        internal int itemsCount => base.createSql().Count();
        internal int totalPages => (int)Math.Ceiling(countPages);
        private double countPages => itemsCount / (double)PageSize;

        protected PagedRepo(DbContext? c, DbSet<TData>? s) : base(c, s) { }
        protected internal override IQueryable<TData> createSql() => addSkipAndTake(base.createSql());
        internal IQueryable<TData> addSkipAndTake(IQueryable<TData> q) => q.Skip(skippedItemsCount).Take(itemsCountInPage);
    }
}
