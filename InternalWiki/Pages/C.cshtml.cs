using System;
using System.Diagnostics;
using System.Linq.Expressions;
using System.Threading.Tasks;
using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class C : PageModel
    {
        [BindProperty] public Article Article { get; set; }
        
        public void OnPost()
        {
            //Updates an article, saves it to local storage.
            var articleBuilder = new ArticleBuilder();
            var saveString = articleBuilder.CreateArticle(Article);
            var path = $"Pages/C.cshtml";
            Debug.WriteLine(path);
            Debug.WriteLine(saveString);
            System.IO.File.WriteAllText(path, saveString);
        }
    }
}