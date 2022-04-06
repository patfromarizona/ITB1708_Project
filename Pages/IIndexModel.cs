
using TeamUP.Facade;

namespace TeamUP.Pages
{
    public interface IIndexModel<TView> where TView : BaseView
    {
        public string[] IndexColumns { get; }
        public IList<TView>? Items { get; }
        public object? GetValue(string name, TView v);
    }
}
