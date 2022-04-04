using TeamUP.Facade;
using TeamUP.Domain;
using Microsoft.AspNetCore.Mvc;

namespace TeamUP.Pages
{
    public abstract class PagedPage<TView, TEntity, TRepo> : OrderedPage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : Entity
        where TRepo : IPagedRepo<TEntity>
    {
        protected PagedPage(TRepo r) : base(r) { }             
        public int PageIndex
        {
            get => repo.PageIndex;
            set => repo.PageIndex = value;
        }
        public int TotalPages => repo.TotalPages;
        public bool HasNextPage => repo.HasNextPage;
        public bool HasPreviousPage => repo.HasPreviousPage;
        protected override void setAttributes(int idx, string? filter, string? order)
        {
            PageIndex = idx;
            CurrentFilter = filter;
            CurrentSort = order;
        }

        protected override IActionResult redirectToIndex()
        {
            return RedirectToPage("./Index", "Index", new
            {
                pageIndex = PageIndex,
                currentFilter = CurrentFilter,
                sortOrder = CurrentSort
            });
        }
    }
}
