using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InternalWiki.Data;
using System.IO;
using System.Text;

namespace InternalWiki
{
    public class NewModel : PageModel
    {
        [BindProperty]
        public Article Article { get; set; }

        public void OnPost()
        {
            //Takes all the users input and builds a page from it.
            var tags = new StringBuilder();
            var saveString = new StringBuilder();
            for(int i = 0; i < Article.Tags.Count(); i++)
            {
                tags.Append(Article.Tags[i] + ",");
            }
            saveString
                .Append("@page \n@{ViewData[\"Title\"] =")
                .Append($"\"{Article.Title}\";")
                .Append("}\n")
                .Append($"<div id = \"title\"> <h1> {Article.Title} </h1> </div>")
                .Append("\n")
                .Append($"<div id = \"content\"> {Article.Content} </div>")
                .Append("\n")
                .Append("\n")
                .Append("<button class = \"btn-secondary\"> Modify </button>")
                .Append($"<div id = \"tags\"> {tags} </div>");
            var path = $"Pages/{Article.Title}.cshtml";
            System.IO.File.WriteAllText(path, saveString.ToString());
            //AddLink
        }
        public void OnGet()
        {
        }
    }
}