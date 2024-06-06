using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.TagHelper
{
    [HtmlTargetElement("alert")]
    public class AlertTagHelper: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public string InnerText { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "div";
            output.Attributes.Add("class", "alert alert-success");
            output.Attributes.Add("role", "alert");
            TagBuilder h2 = new TagBuilder("h2");
            h2.InnerHtml.Append(InnerText);
            output.PreContent.AppendHtml(h2);

        }
    }
}
