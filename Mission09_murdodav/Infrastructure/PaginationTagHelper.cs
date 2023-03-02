using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mission09_murdodav.Models.ViewModels;

namespace Mission09_murdodav.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        // Dynamically create the page links for us
        // This will help us create those dynamic links (has to be created when the object is instantiated, so it's put in the constructor)
        private IUrlHelperFactory uhf;

        // The Constructor (passed an IUrlHelperFactory object called "uhf_temp")
        public PaginationTagHelper(IUrlHelperFactory uhf_temp)
        {
            // setting that temporary object equal to our uhf variable (of type IUrlHelperFactory)
            uhf = uhf_temp;
        }

        // getting a ViewContext object
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        // getting a PageInfo object from page-model="@Model.pageInfo" in Index.cshtml
        public PageInfo PageModel { get; set; }

        // getting the PageAction object from page-model="Index" in Index.cshtml
        public string PageAction { get; set; }

        // overriding the general TagHelper class that we're inheriting from
        // TagHelperContext helps us build the links
        // TagHelperOutput is what we're sending back to the page
        public override void Process(TagHelperContext thc, TagHelperOutput tho)
        {
            // passing the ViewContext to the uh through the GetUrlHelper method
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            // using a div, because that's what we specified above, to loop through and create our links
            TagBuilder final = new TagBuilder("div");

            // for each pagination page we need (as long as i is less than the total number of pages we need (with i starting at 1)
            for (int i = 1; i < PageModel.TotalPages; i++)
            {
                // Building the <a> tag

                // add a new "<a>" tag inside the <div>
                TagBuilder tb = new TagBuilder("a");


                // Building our Connection String (our href)

                // as the "href", start by adding the PageAction ("page-action" in the html) with a new page number being equal to the current page number
                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });

                // append the current page number to the href to finish off the <a> tag
                tb.InnerHtml.Append(i.ToString());

                // Adding the <a> tag to the main <div>

                // Adding the finished <a> tag to the "final" result (which is the main "div" we are putting all this into)
                final.InnerHtml.AppendHtml(tb);
            }

            // now that that div is all put together with all the <a> tags added to it, we are going to append it to the TagHelperOutput (tho)
            tho.Content.AppendHtml(final.InnerHtml);
        }
    }
}
