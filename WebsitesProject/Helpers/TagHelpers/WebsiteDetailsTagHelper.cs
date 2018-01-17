using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Threading.Tasks;
using WebsitesProject.Models;

namespace WebsitesProject.Helpers.TagHelpers
{
    [HtmlTargetElement("webdetails")]
    public class WebsiteDetailsTagHelper : TagHelper
    {
        public Website Website { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "details";
            output.PreContent.SetHtmlContent($@"<summary>");
            output.PostContent.SetHtmlContent($@"</summary>
                                                <p>{Website.Description}</p>
                                                <p>{Website.CreatedAt}</p>");
        }
    }
}