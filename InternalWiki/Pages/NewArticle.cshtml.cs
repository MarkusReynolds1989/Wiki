using System;
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
            var pubTime = DateTime.Now;
            var article = new Article(title, content, tags, pubTime, DateTime.Now);
            
            ArticleController.WriteJsonArticles(article);
        }
    }
}