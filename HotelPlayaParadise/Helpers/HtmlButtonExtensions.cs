using System.Web.Mvc;

namespace HotelPlayaParadise.Helpers
{
    public static class HtmlButtonExtensions
    {
        // Método principal con todos los parámetros
        public static MvcHtmlString ActionButton(this HtmlHelper html, string text, string action, string controller, object routeValues, object htmlAttributes)
        {
            var urlHelper = new UrlHelper(html.ViewContext.RequestContext);
            var url = urlHelper.Action(action, controller, routeValues);

            var builder = new TagBuilder("button");
            builder.MergeAttribute("type", "button");
            builder.MergeAttribute("onclick", $"location.href='{url}'");
            builder.SetInnerText(text);
            builder.MergeAttributes(HtmlHelper.AnonymousObjectToHtmlAttributes(htmlAttributes));

            return MvcHtmlString.Create(builder.ToString(TagRenderMode.Normal));
        }

        // Sobrecarga sin htmlAttributes
        public static MvcHtmlString ActionButton(this HtmlHelper html, string text, string action, string controller, object routeValues)
        {
            return ActionButton(html, text, action, controller, routeValues, null);
        }

        // Sobrecarga sin routeValues y htmlAttributes
        public static MvcHtmlString ActionButton(this HtmlHelper html, string text, string action, string controller)
        {
            return ActionButton(html, text, action, controller, null, null);
        }
    }
}