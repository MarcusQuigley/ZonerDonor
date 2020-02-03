using Microsoft.AspNetCore.Razor.TagHelpers;

namespace ZonerDonor.TagHelpers
{
    public class IfTagHelper : TagHelper
    {
        [HtmlAttributeName("include-if")]
        public bool Include { get; set; } = true;

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            // Always strip the outer tag name as we never want <if> to render
            output.TagName = null;

            if (Include )
            {
                return;
            }

            output.SuppressOutput();
        }
    }
}
