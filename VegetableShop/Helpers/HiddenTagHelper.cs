using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VegetableShop.Helpers
{
    [HtmlTargetElement("div", Attributes = "hidden-condition")]
    public class HiddenTagHelper: TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }
        public bool Condition { get; set; }
        public string Type { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
        public string Css { get; set; }
        public IHtmlContent Label { get; set; }
        public string AutoComplete { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            TagBuilder tagBuilder = new TagBuilder("input");
            if (Condition)
            {
                tagBuilder.MergeAttribute("hidden", "hidden");
            }
            Console.WriteLine(Css);
            tagBuilder.AddCssClass(Css);
            tagBuilder.MergeAttribute("id", Name);
            tagBuilder.MergeAttribute("value", Value);
            tagBuilder.MergeAttribute("type", Type);
            tagBuilder.MergeAttribute("name", Name);
            tagBuilder.MergeAttribute("autocomplete", AutoComplete);
            if (!Condition)
            {
                output.Content.AppendHtml(Label);
            }      
            output.Content.AppendHtml(tagBuilder);
        }
    }
}
