using System;
using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class Modify : PageModel
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

        public void OnPost()
        {
            var title = Request.Form["title"];
            var content = Request.Form["content"];
            if (BluePrint.ModifyArticle(content, title))
            {
                ViewData["postSuccess"] = "Post success!";
            }
            else
            {
                ViewData["postSuccess"] = "Post failed!";
            }
        }
    }
}