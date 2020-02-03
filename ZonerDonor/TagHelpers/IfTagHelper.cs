using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
