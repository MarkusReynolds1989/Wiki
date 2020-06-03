using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternalWiki.Data

{
    public static class BluePrint
    {
        public static Dictionary<int, string> ArticleList = new Dictionary<int, string>();
        //TODO: Method to write text file.
        
        //Run on start up to get a dictionary of all the articles we already have and give them an ID.
        public static void FillArticleList()
        {
            var count = 0;
            foreach (var item in Directory.EnumerateFiles(
                @"C:\Users\MR071411\Desktop\FunCode\CSharp\Wiki\InternalWiki\Pages\Articles"))
            {
                ArticleList.Add(count++, item);
            }
        }
        
        //Add a new key (the last key of the list + 1) and a path.
        private static void AddToArticleList(int id ,string path)
        {
            ArticleList.Add(id,path);
        }

        public static bool WriteArticle(string content,string title)
        {
            var path = @"C:\Users\MR071411\Desktop\FunCode\CSharp\Wiki\InternalWiki\Pages\Articles\";
            var articleId = ArticleList.Keys.Last() + 1;
            AddToArticleList(articleId, path + title);
            File.WriteAllText(path + title + ".txt", content);
            return true;
        }

        //TODO: Method to read a file.
        //Reads the file into raw html that the page can consume.
        //Doesn't currently separate the title/content ext.
        public static string ReadArticle(int id)
        {
            var article = ArticleList[id];
            var path = article;
            return File.ReadAllText(path);
        }
    }
}