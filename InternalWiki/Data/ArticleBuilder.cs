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
        public string CreateArticle(Article article)
        {
            var articleHtml = new StringBuilder();
            var tagBuilder = new StringBuilder();
            foreach (var item in article.Tags)
            {
                tagBuilder.Append(item + ",");
            }

            articleHtml.Append("@page");
            articleHtml.Append($"\n@model InternalWiki.Pages.{article.Title}Model");
            articleHtml.Append($"\n<div id = \"{article.Title}\">");
            articleHtml.Append($"\n<h1> {article.Title} </h1>");
            articleHtml.Append("\n</div>");
            //Responsible for creating the article.
            return articleHtml.ToString();
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
            var linkTitle = $"{article.Title} ";
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