using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;

namespace WebsitesProject.Helpers.TagHelpers
{
    [HtmlTargetElement("currency")]
    public class CurrencyTagHelper : TagHelper
    {
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "strong";
            output.PostContent.SetHtmlContent(" $");
        }
    }
}