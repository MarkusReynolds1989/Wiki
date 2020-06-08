using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class NewArticle : PageModel
    {
        public void OnPost()
        {
            var title = Request.Form["Title"];
            var content = Request.Form["Content"];
            if (BluePrint.WriteArticle(content, title))
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