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
            //Creates a new article, saves it to local storage.
            var articleBuilder = new ArticleBuilder();
            var saveString = articleBuilder.CreateArticle(Article);
            var path = $"Pages/{Article.Title}.cshtml";
            var link = $"{Article.Title}";
            var linkPath = $"Pages/links.txt";
            System.IO.File.WriteAllText(path, saveString.ToString());
            System.IO.File.AppendAllText(linkPath, " " + link + " ");
        }

    }
}