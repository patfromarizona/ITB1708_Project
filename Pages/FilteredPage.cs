using TeamUP.Facade;
using TeamUP.Domain;

namespace TeamUP.Pages
{
    public abstract class FilteredPage<TView, TEntity, TRepo> : CrudPage<TView, TEntity, TRepo>
        where TView : BaseView, new()
        where TEntity : Entity
        where TRepo : IFilteredRepo<TEntity>
    {
        protected FilteredPage(TRepo r) : base(r) { }
        public string? CurrentFilter
        {
            get => repo.CurrentFilter;
            set => repo.CurrentFilter = value;
        }
    }
}
