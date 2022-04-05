using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TeamUP.Pages.Extensions
{
    public static class MyTabHdrHtml
    {
        public static IHtmlContent MyTabHdr<TModel>(
            this IHtmlHelper<TModel> h, string name)
        {
            var s = htmlStrings(name, h.ViewData.Model as IPageModel);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings(string name, IPageModel? m)
        {
            var l = new List<object>();
            //<a href="/TeamWorks?order=Name&amp;idx=0&amp;handler=Index">Name</a>
            //<a href="/?handler=Index&amp;order=&amp;idx=0&amp;filter=">UniversityLocation</a>
            l.Add(new HtmlString($"<a href=\"/{pageName(m)}?"));
            l.Add(new HtmlString($"handler=Index&amp;"));
            l.Add(new HtmlString($"order={m?.SortOrder(name)}&amp;"));
            l.Add(new HtmlString($"idx={m?.PageIndex??0}&amp;"));
            l.Add(new HtmlString($"filter={m?.CurrentFilter}\">"));
            l.Add(new HtmlString($"{name}</a>"));
            return l;
        }
        private static string? pageName(IPageModel m) => m?.GetType()?.Name?.Replace("Page", "");
    }
}
