using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InternalWiki.Data;
using System.IO;
using System.Text;
namespace InternalWiki
{
    public class ArticlesModel : PageModel
    {
        public static List<string> linkList = new List<string>();
        public void OnGet()
        {
            //Method to pull all links to articles

            /*
            Example:
            foreach(var item in list) {
                string.append("<a> whatever </a>");
            }
            */

            /* 1. Grab from txt and put into list
             * 2. Take from list and add to html string
             * 3. Update page.
             */
            if (linkList.Count < 1)
            {
                var input = System.IO.File.ReadAllText(@"Pages/links.txt");
                foreach (var item in input.Split(" ",StringSplitOptions.RemoveEmptyEntries))
                {
                    linkList.Add(item);
                }
            }
        }
    }
}