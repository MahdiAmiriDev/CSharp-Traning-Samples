using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.TagHelper
{
    [HtmlTargetElement("p",Attributes = "paragraph-color")]
    public class PTagHelper: Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public string ParagraphColor { get; set; } = "text-bg-danger";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", ParagraphColor);
        }
    }
}
