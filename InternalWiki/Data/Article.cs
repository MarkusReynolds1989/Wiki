using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace InternalWiki.Data
{
    public class Article
    {
        public string Title { get; set; }
        public IList<string> Tags { get; set; }
        public string Content { get; set; }
        
    }
    public class ArticleBuilder
    {

        public string CreateArticle(Article article)
        {
            var tagBuilder = new StringBuilder();
            foreach(var item in article.Tags)
            {
                tagBuilder.Append(item + ",");
            }
            //Responsible for creating the article.
            var articleString = new StringBuilder();
               articleString
                .Append("@page \n@{ViewData[\"Title\"] =")
                .Append($"\"{article.Title}\";")
                .Append("}\n")
                .Append($"<div id = \"title\"> <h1> {article.Title} </h1> </div>")
                .Append("\n")
                .Append($"<div id = \"content\"> {article.Content} </div>")
                .Append("\n")
                .Append("\n")
                .Append("</br> <button class = \"btn btn-secondary\"> Modify </button>")
                .Append($"<div id = \"tags\"> {tagBuilder} </div>");
            return articleString.ToString();
        }

        public string ModifyArticle(Article article)
        {
            return "";
        }
    }
}
