using System.CodeDom.Compiler;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Text;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternalWiki.Data
{
    //This class builds a new article.
    public class ArticleBuilder : ICreateArticle
    {
        public IHtmlContent CreateArticle(Article article)
        {
            var articleHTML = new HtmlContentBuilder();
            var tagBuilder = new StringBuilder();
            foreach (var item in article.Tags)
            {
                tagBuilder.Append(item + ",");
            }

            articleHTML.Append("@page");
            articleHTML.Append($"@model InternalWiki.Pages.{article.Title}Model");
            articleHTML.Append($"div id = '{article.Title}'");
            articleHTML.Append($"<h1> {article.Title} </h1>");
            articleHTML.Append("</div>");
            //Responsible for creating the article.
            Debug.WriteLine(articleHTML);
            return articleHTML;
        }

        public string CreateCodeBehind(Article article)
        {
            //This will be the update;
            //UpdateArticle.
            
            return "";
        }

        //Save the new article.
        public void SaveNewArticle(Article article)
        {
            //Creates a new article, saves it to local storage.
            var articleBuilder = new ArticleBuilder();
            
            var articleContent = articleBuilder.CreateArticle(article);
            var articlePath = $"Pages/Articles/{article.Title}.cshtml";
            var linkTitle = $" {article.Title} ";
            var linkPath = $"Pages/links.txt";
            
            //Write the new article to a local file.
            void WriteNewArticle() => File.WriteAllTextAsync
            (articlePath,
                articleContent);
            //Add the link to the list.
            void WriteNewLink() => File.AppendAllTextAsync(linkPath
                , linkTitle);

            Parallel.Invoke(WriteNewLink
                , WriteNewArticle);
        }
    }
}