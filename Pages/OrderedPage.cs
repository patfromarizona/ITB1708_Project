using TeamUP.Facade;
using TeamUP.Domain;

namespace TeamUP.Pages
{
    public abstract class OrderedPage<TView, TEntity, TRepo> : FilteredPage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : Entity
        where TRepo : IOrderedRepo<TEntity>
    {
        protected OrderedPage(TRepo r) : base(r) { }
    }
}
