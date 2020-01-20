using System.Threading.Tasks;
using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class NewModel : PageModel
    {
        [BindProperty] public Article Article { get; set; }

        public void OnPost()
        {
            //Creates a new article, saves it to local storage.
            var articleBuilder = new ArticleBuilder();
            var saveString = articleBuilder.CreateArticle(Article);
            var path = $"Pages/{Article.Title}.cshtml";
            var link = $"{Article.Title}";
            var linkPath = $"Pages/links.txt";
            void WriteToPath() => System.IO.File.WriteAllText(path, saveString);
            void WriteToLink() => System.IO.File.AppendAllText(linkPath, " " + link + " ");
            Parallel.Invoke(WriteToLink,WriteToPath);
        }
    }
}