using InternalWiki.Data;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class NewArticle : PageModel
    {
        public void OnPost()
        {
            var title = Request.Form["Title"];
            var content = Request.Form["Content"]; 
            var tags = Request.Form["Tags"];
            
            if (ArticleController.WriteArticle(title,content,tags))
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