using InternalWiki.Data;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace InternalWiki.Pages
{
    public class NewArticle : PageModel
    {
        public void OnPost()
        {
            var title = Request.Form["Title"];
            var content = Request.Form["Content"];
            BluePrint.WriteArticle(content, title);
        }
    }
}