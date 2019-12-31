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
            var tags = new StringBuilder();
            foreach(var item in Article.Tags)
            {
                tags.Append(item);
            }
            var saveString =
                "@page \n@{ViewData[\"Title\"] =" +
                $"\"{Article.Title}\";" + 
                "}" +
                $@"<h1> {Article.Title} </h1>" +
                $@"<p> {Article.Content} </p>";
            var path = $"Pages/{Article.Title}.cshtml";
            System.IO.File.WriteAllText(path, saveString);
        }
        public void OnGet()
        {

        }
    }
}