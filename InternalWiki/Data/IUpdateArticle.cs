namespace InternalWiki.Data
{
    public interface IUpdateArticle 
    {
        string UpdateArticle(Article article);
        string UpdateCodeBehind(Article article);
        void SaveUpdate(Article article);
    }
}