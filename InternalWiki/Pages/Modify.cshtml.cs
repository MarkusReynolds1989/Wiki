using System;
using System.Diagnostics;
using InternalWiki.Data;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class Modify : PageModel
    {
        public void OnGet(int id)
        {
            //Sets the content for the page based upon the id provided.
            var article = ArticleController.ArticleList[id];
            ViewData["id"] = id;
            ViewData["content"] = article.Content;
            ViewData["title"] = article.Title;
            ViewData["tags"] = article.Tags;
        }

        public void OnPost()
        {
            var id = int.Parse(Request.Form["Id"]);
            var pubTime = ArticleController.ArticleList[id].PublishTime;
            var title = Request.Form["Title"];
            var content = Request.Form["Content"];
            var tags = Request.Form["Tags"];
            Debug.WriteLine(title);
            var article = new Article(title, content, tags, pubTime, DateTime.Now);
            // Replace the old article in the dictionary.
            ArticleController.ArticleList[id] = article;
            // Rewrite the list to the json file.
            ArticleController.UpdateJson();
        }
    }
}