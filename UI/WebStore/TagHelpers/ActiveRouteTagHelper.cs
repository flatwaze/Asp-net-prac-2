using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace WebStore.TagHelpers
{
    [HtmlTargetElement(Attributes = AttributeName)]
    public class ActiveRouteTagHelper : TagHelper
    {
        public const string AttributeName = "is-active-route";

        [HtmlAttributeName("asp-action")]
        public string Action { get; set; }

        [HtmlAttributeName("asp-controller")]
        public string Controller { get; set; }

        [HtmlAttributeName("asp-all-route-data", DictionaryAttributePrefix = "asp-route-")]
        private IDictionary<string, string> RouteValues { get; set; } =
            new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

        [HtmlAttributeNotBound, ViewContext]
        public ViewContext ViewContext { get; set; }

        private bool IsActive()
        {
            var routes = ViewContext.RouteData.Values;
            var controller = routes["controller"].ToString();
            var action = routes["action"].ToString();
            const StringComparison ignore_case = StringComparison.OrdinalIgnoreCase;
            if (!string.IsNullOrWhiteSpace(Controller) && !string.Equals(Controller, controller, ignore_case))
                return false;

            if (!string.IsNullOrWhiteSpace(Action) && !string.Equals(Action, action, ignore_case))
                return false;

            foreach (var (key, value) in RouteValues)
                if (!routes.ContainsKey(key) || routes[key].ToString() != value)
                    return false;

            return true;
        }

        private static void MakeActive(TagHelperOutput output)
        {
            var class_attribute = output.Attributes.FirstOrDefault(a => a.Name == "class");

            if (class_attribute is null)
            {
                output.Attributes.Add(new TagHelperAttribute("class", "active"));
            }
            else
            {
                if (class_attribute.Value.ToString().Contains("active")) return;
                output.Attributes.SetAttribute(
                    "class",
                    class_attribute.Value is null ? "active" : class_attribute.Value + " active");
            }
        }


        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (IsActive()) MakeActive(output);
            output.Attributes.RemoveAll(AttributeName);
        }
    }
}
