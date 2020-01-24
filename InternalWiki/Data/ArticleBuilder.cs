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
            //Header
            articleHtml.Append("@page");
            articleHtml.Append($"\n@model InternalWiki.Pages.Articles.{article.Title}Model");
            articleHtml.Append("\n@section Scripts\n{\n");
            articleHtml.Append("\t<script src =\"~/ts/ModifyArticle.js\"/>\n}");
            //Title
            articleHtml.Append("\n<div id = \"title\">");
            articleHtml.Append($"\n<h1> {article.Title} </h1>");
            articleHtml.Append("\n</div>\n<br/>\n");
            //Content
            articleHtml.Append("<div id = \"content\">\n");
            articleHtml.Append($"{article.Content}\n");
            articleHtml.Append("</div>\n");
            //Buttons
            articleHtml.Append("<div id = \"buttons\">\n");
            articleHtml.Append("<button class = \"btn btn-primary\"\n" +
                               "onclick = \" let modify = new ModifyArticle(" +
                               "'title','content','buttons','tags');\n" +
                               "\tmodify.ModifyAll()\">\n Modify \n</button>\n" +
                               "</div>");
            //Tags
            articleHtml.Append("<div id = \"tags\">\n");
            articleHtml.Append($"{tagBuilder}\n");
            articleHtml.Append("</div>");
            //Responsible for creating the article.
            return articleHtml.ToString();
        }

        public string CreateCodeBehind(Article article)
        {
            //This will be the update;
            //UpdateArticle.
            var articleCode = new StringBuilder();
            //Includes
            articleCode.Append("using InternalWiki.Data;\n");
            articleCode.Append("using Microsoft.AspNetCore.Mvc;\n");
            articleCode.Append("using Microsoft.AspNetCore.Mvc.RazorPages;\n");
            articleCode.Append("namespace InternalWiki.Pages.Articles\n{");
            //Main 
            articleCode.Append(
                $"public class {article.Title}Model : PageModel\n");
            articleCode.Append(
                "{\n[BindProperty] public Article article {get;set;}");
            articleCode.Append("\npublic void OnPost()\n{");
            articleCode.Append("var updateArticle = new ArticleUpdate();");
            articleCode.Append("\nupdateArticle.UpdateArticle(article);");
            articleCode.Append("\n}\n}\n}");
        return articleCode.ToString();
    }

        //Save the new article.
        public void SaveNewArticle(Article article)
        {
            //Creates a new article, saves it to local storage.
            var articleBuilder = new ArticleBuilder();
            
            var articleContent = articleBuilder.CreateArticle(article);
            var codeBehind = CreateCodeBehind(article); 
            var articlePath = $"Pages/Articles/{article.Title}.cshtml";
            var codePath = $"Pages/Articles/{article.Title}.cshtml.cs";
            var linkTitle = $"{article.Title} ";
            var linkPath = $"Pages/links.txt";
            
            //Write the new article to a local file.
            void WriteNewArticle() => File.WriteAllTextAsync
            (articlePath,
                articleContent);

            void WriteNewCode() => File.WriteAllTextAsync(codePath
                , codeBehind);
            
            //Add the link to the list.
            void WriteNewLink() => File.AppendAllTextAsync(linkPath
                , linkTitle);

            Parallel.Invoke(WriteNewLink
                , WriteNewArticle 
                , WriteNewCode);
        }
    }
}