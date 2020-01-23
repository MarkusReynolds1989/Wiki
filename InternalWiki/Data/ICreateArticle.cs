using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternalWiki.Data
{
    public interface ICreateArticle
    {
        IHtmlContent CreateArticle(Article article);
        string CreateCodeBehind(Article article);
        void SaveNewArticle(Article article);
    }
}

 