using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace InternalWiki.Data
{
    public interface ICreateArticle
    {
        string CreateArticle(Article article);
        string CreateCodeBehind(Article article);
        void SaveNewArticle(Article article);
    }
}

 