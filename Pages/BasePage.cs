using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TeamUP.Facade;
using TeamUP.Domain;
using TeamUP.Aids;

namespace TeamUP.Pages {
    public abstract class BasePage<TView, TEntity, TRepo> : PageModel
        where TView : BaseView, new()
        where TEntity : Entity
        where TRepo : IBaseRepo<TEntity> {
        protected readonly TRepo repo;
        protected abstract TView toView(TEntity? entity);
        protected abstract TEntity toObject(TView? item);
        protected abstract IActionResult redirectToIndex();

        [BindProperty] public TView Item { get; set; } = new TView();
        public IList<TView> Items { get; set; } = new List<TView>();

        public BasePage(TRepo r) => repo = r;
        public string ItemId => Item?.Id ?? string.Empty;
        protected abstract IActionResult getCreate();
        protected virtual async Task<IActionResult> perform(Func<Task<IActionResult>> f, int idx, string? filter, string? order, bool removeKeys = false) {
            setAttributes(idx, filter, order);
            if (removeKeys) removeKey(nameof(filter), nameof(order));
            return await f();
        }
        protected abstract Task<IActionResult> postCreateAsync();
        protected abstract Task<IActionResult> getDetailsAsync(string id);
        protected abstract Task<IActionResult> getDeleteAsync(string id);
        protected abstract Task<IActionResult> postDeleteAsync(string id);
        protected abstract Task<IActionResult> getEditAsync(string id);
        protected abstract Task<IActionResult> postEditAsync();
        protected abstract Task<IActionResult> getIndexAsync();
        protected abstract void setAttributes(int idx, string? filter, string? order);
        internal virtual void removeKey(params string[] keys) {
            foreach (var key in keys ?? Array.Empty<string>()) {
                Safe.Run(() => ModelState.Remove(key));
            }
        }
        public IActionResult OnGetCreate(int idx = 0, string? filter = null, string? order = null) {
            setAttributes(idx, filter, order);
            return getCreate();
        }
        public async Task<IActionResult> OnPostCreateAsync(int idx = 0, string? filter = null, string? order = null)
            => await perform(() => postCreateAsync(), idx, filter, order, true);
        public async Task<IActionResult> OnGetDetailsAsync(string id, int idx = 0, string? filter = null, string? order = null)
            => await perform(() => getDetailsAsync(id), idx, filter, order);
        public async Task<IActionResult> OnGetDeleteAsync(string id, int idx = 0, string? filter = null, string? order = null)
            => await perform(() => getDeleteAsync(id), idx, filter, order);
        public async Task<IActionResult> OnPostDeleteAsync(string id, int idx = 0, string? filter = null, string? order = null)
         => await perform(() => postDeleteAsync(id), idx, filter, order);
        public async Task<IActionResult> OnGetEditAsync(string id, int idx = 0, string? filter = null, string? order = null)
         => await perform(() => getEditAsync(id), idx, filter, order);
        public async Task<IActionResult> OnPostEditAsync(int idx = 0, string? filter = null, string? order = null)
         => await perform(() => postEditAsync(), idx, filter, order, true);
        public async Task<IActionResult> OnGetIndexAsync(int idx = 0, string? filter = null, string? order = null)
         => await perform(() => getIndexAsync(), idx, filter, order);
    }
}
