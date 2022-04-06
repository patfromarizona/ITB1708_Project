using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using TeamUP.Facade;

namespace TeamUP.Pages.Extensions
{
    public static class MyBtnHtml
    {
        public static IHtmlContent MyBtn<TModel>(
            this IHtmlHelper<TModel> h, string handler, string id)
        {
            var s = htmlStrings(handler, id, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings(string handler, string id, IPageModel? m)
        {
            var l = new List<object>();
            l.Add(new HtmlString($"<a href=\"/{pageName(m)}/{handler}?"));
            l.Add(new HtmlString($"handler={handler}&amp;"));
            l.Add(new HtmlString($"order={m?.CurrentOrder}&amp;"));
            l.Add(new HtmlString($"id={id}&amp;"));
            l.Add(new HtmlString($"idx={m?.PageIndex ?? 0}&amp;"));
            l.Add(new HtmlString($"filter={m?.CurrentFilter}\">"));
            l.Add(new HtmlString($"{handler}</a>"));
            return l;
        }
        private static string? pageName(IPageModel? m) => m?.GetType()?.Name?.Replace("Page", "");
    }

    public static class ShowTableHtml
    {
        public static IHtmlContent ShowTable<TModel, TView>(this IHtmlHelper<TModel> h, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : BaseView
        {
            var s = htmlStrings<TModel, TView>(h, items);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TModel, TView>(IHtmlHelper<TModel> h, IList<TView>? items)
            where TModel : IIndexModel<TView> where TView : BaseView
        {
            var l = new List<object>();
            var m = h.ViewData.Model;
            l.Add(new HtmlString($"<table class=\"table\">"));
            l.Add(new HtmlString($"<thead>"));
            l.Add(new HtmlString($"<tr>"));
            foreach (var name in m.IndexColumns)
            {
                l.Add(new HtmlString($"<th>"));
                l.Add(h.MyTabHdr(name));
                l.Add(new HtmlString($"</th>"));
            }
            l.Add(new HtmlString($"<th></th>"));
            l.Add(new HtmlString($"</tr>"));
            l.Add(new HtmlString($"</thead>"));
            l.Add(new HtmlString($"<tbody>"));
            foreach (var item in m.Items ?? new List<TView>())
            {
                l.Add(new HtmlString($"<tr>"));
                foreach (var name in m.IndexColumns)
                {
                    l.Add(new HtmlString($"<th>"));
                    l.Add(h.Raw(m.GetValue(name, item)));
                    l.Add(new HtmlString($"</th>"));
                }
                l.Add(new HtmlString($"<td>"));
                l.Add(h.ItemButtons(item.Id));
                l.Add(new HtmlString($"</td>"));
                l.Add(new HtmlString($"</tr>"));
            }
            l.Add(new HtmlString($"</tbody>"));
            l.Add(new HtmlString($"</table>"));
            return l;
        }
    }
}
