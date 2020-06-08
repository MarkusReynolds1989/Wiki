using System;
using System.Linq;
using System.Text;
using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class ArticleModel : PageModel
    {
        public void OnGet(int id)
        {
            var raw = BluePrint.ReadArticle(id); 
            var position = raw.IndexOf("\r\n", StringComparison.Ordinal);
            var title = raw.Substring(0, position);
            var content = raw.Remove(0, position);
            //Sets the content for the page based upon the id provided.
            ViewData["content"] = content;
            ViewData["title"] = title;
            ViewData["id"] = id;
        }
    }
}