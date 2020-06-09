using System;
using System.Linq;
using System.Text;
using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class ArticleModel : PageModel
    {
        [BindProperty]
        private Article Article {get; set; }
        
        public void OnGet(int id)
        {
            Article = ArticleController.ReadArticle(id);
            ViewData["title"] = Article.Title;
            ViewData["content"] = Article.Content;
            ViewData["tags"] = Article.Tags;
        }
    }
}