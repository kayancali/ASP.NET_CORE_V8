using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using StoreApp.Web.Models;

namespace StoreApp.Web.TagHelpers
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PageLinkTagHelper : TagHelper
    {
        private IUrlHelperFactory _urlHelperFactory;
        
        public PageLinkTagHelper(IUrlHelperFactory urlHelperFactory)
        {
            _urlHelperFactory = urlHelperFactory;
        }

        [ViewContext]
        public ViewContext? ViewContext { get; set; }
        
        public PageInfoModel? PageModel { get; set; }
        
        public string? PageAction { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = _urlHelperFactory.GetUrlHelper(ViewContext);

                TagBuilder nav = new TagBuilder("nav");
                TagBuilder ul = new TagBuilder("ul");
                ul.AddCssClass("pagination pagination-lg");

                for (int i = 1; i <= PageModel.TotalPages; i++)
                {
                    TagBuilder li = new TagBuilder("li");
                    li.AddCssClass("page-item");

                    if (i == PageModel.CurrentPage)
                    {
                        li.AddCssClass("active"); // Aktif sayfa için 'active' sınıfını ekliyoruz
                        TagBuilder span = new TagBuilder("span");
                        span.AddCssClass("page-link");
                        span.InnerHtml.Append(i.ToString());
                        li.InnerHtml.AppendHtml(span);
                    }
                    else
                    {
                        TagBuilder link = new TagBuilder("a");
                        link.AddCssClass("page-link");
                        link.Attributes["href"] = urlHelper.Action(PageAction, new { page = i });
                        link.InnerHtml.Append(i.ToString());
                        li.InnerHtml.AppendHtml(link);
                    }

                    ul.InnerHtml.AppendHtml(li);
                }

                nav.InnerHtml.AppendHtml(ul);
                output.Content.AppendHtml(nav);
            }
}

    }
}
