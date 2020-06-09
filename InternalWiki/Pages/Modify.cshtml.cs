using InternalWiki.Data;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class Modify : PageModel
    {
        [BindProperty] private Article Article { get; set; }

        public void OnGet(int id)
        {
            Article = ArticleController.ReadArticle(id);

            //Sets the content for the page based upon the id provided.
            ViewData["content"] = Article.Content;
            ViewData["title"] = Article.Title;
            ViewData["id"] = Article.Tags;
        }

        public void OnPost()
        {
            var title = Request.Form["title"];
            var content = Request.Form["content"];
            var tags = Request.Form["tags"];

            if (ArticleController.ModifyArticle(new Article(title, content, tags)))
            {
                ViewData["pSuccess"] = "Modify complete.";
            }
            else
            {
                ViewData["pSuccess"] = "Modify failed.";
            }
        }
    }
}