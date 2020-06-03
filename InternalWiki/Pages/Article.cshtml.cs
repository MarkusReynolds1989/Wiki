using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class ArticleModel : PageModel
    {
        public void OnGet(int id)
        {
            //Sets the content for the page based upon the id provided.
            ViewData["content"] = BluePrint.ReadArticle(id);
        }

        public void OnPost()
        {
        }
    }
}