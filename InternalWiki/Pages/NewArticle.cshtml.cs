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
            var newArticle = new ArticleBuilder();
            newArticle.SaveNewArticle(Article);
        }
    }
}