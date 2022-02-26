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

        private static List<object> htmlStrings<TModel, TResult>(IHtmlHelper<TModel> html, Expression<Func<TModel, TResult>> expression)
        {
            var l = new List<object>();
            //l.Add(new HtmlString("<div class=\"row\">"));
            //l.Add(new HtmlString("<dd class=\"col-sm-2\">"));
            //l.Add(html.LabelFor(expression, null, new { @class = "control-label" }));
            //l.Add(new HtmlString("</dd>"));
            //l.Add(new HtmlString("<dd class=\"col-sm-10\">"));
            //l.Add(html.EditorFor(expression, new { htlmAttributes = new { @class = "form-control" } }));
            //l.Add(html.ValidationMessageFor(expression, null, new { @class = "text-danger" }));
            //l.Add(new HtmlString("</dd>"));
            //l.Add(new HtmlString("</div>"));


            l.Add(new HtmlString("<dl class=\"row\">"));
            l.Add(new HtmlString("<dt class=\"col-sm-2\">"));
            l.Add(html.DisplayNameFor(expression));
            l.Add(new HtmlString("</dt>"));
            l.Add(new HtmlString("<dd class=\"col-sm-10\">"));
            l.Add(html.DisplayFor(expression));
            l.Add(new HtmlString("</dd>"));
            l.Add(new HtmlString("</dl>")); 


            return l;
        }
    }
}
