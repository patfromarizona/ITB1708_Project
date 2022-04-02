using TeamUP.Facade;
using TeamUP.Domain;

namespace TeamUP.Pages
{
    public abstract class CrudPage<TView, TEntity, TRepo> : BasePage<TView, TEntity, TRepo>
        where TView : BaseView
        where TEntity : Entity
        where TRepo : ICrudRepo<TEntity>
    {
        protected CrudPage(TRepo r) : base(r) { }
    }
}
