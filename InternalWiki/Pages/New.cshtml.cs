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
            foreach(var item in Article.Tags)
            {
                tags.Append(item + ",");
            }
            var saveString =
                "@page \n@{ViewData[\"Title\"] =" +
                $"\"{Article.Title}\";" + 
                "}\n" +
                $@"<h1> {Article.Title} </h1>" + "\n" +
                $@"<p> {Article.Content} </p>" + "\n" +
                $@"<p> {tags} </p>" + "\n";
            var path = $"Pages/{Article.Title}.cshtml";
            System.IO.File.WriteAllText(path, saveString);
            //AddLink
        }
        public void OnGet()
        {

        }
    }
}