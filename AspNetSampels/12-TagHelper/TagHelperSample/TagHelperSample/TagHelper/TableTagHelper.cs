using Microsoft.AspNetCore.Razor.TagHelpers;

namespace TagHelperSample.TagHelper
{
    public class TableTagHelper:Microsoft.AspNetCore.Razor.TagHelpers.TagHelper
    {
        public string CustomColor { get; set; } = "warning";

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.Attributes.Add("class", $"table table-bordered table-striped table-{CustomColor}");
        }
    }
}
