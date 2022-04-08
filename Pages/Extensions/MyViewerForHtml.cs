using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq.Expressions;

namespace TeamUP.Pages.Extensions
{
    public static class MyViewerForHtml
    {
        public static IHtmlContent MyViewerFor<TModel, TResult>(this IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            var s = htmlStrings(html, expression);
            return new HtmlContentBuilder(s);
        }

        public static IHtmlContent MyViewerFor<TModel, TResult>(this IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, dynamic value)
        {
            var s = htmlStrings(h, e, value);
            return new HtmlContentBuilder(s);
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> expression)
        {
            var l = new List<object>
            {
               new HtmlString("<dl class=\"row\">"),
               new HtmlString("<dt class=\"col-sm-2\">"),
               h.DisplayNameFor(expression),
               new HtmlString("</dt>"),
               new HtmlString("<dd class=\"col-sm-10\">"),
               h.DisplayFor(expression),
               new HtmlString("</dd>"),
               new HtmlString("</dl>")
            };
            return l;
        }

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> h, Expression<Func<TModel, TResult>> e, dynamic value)
        {
            var l = new List<object> 
            {
                new HtmlString("<dl class=\"row\">"),
                new HtmlString("<dt class=\"col-sm-2\">"),
                h.DisplayNameFor(e),
                new HtmlString("</dt>"),
                new HtmlString("<dd class=\"col-sm-10\">"),
                h.Raw(value),
                new HtmlString("</dd>"),
                new HtmlString("</dl>")
            };
            return l;
        }
    }
}
