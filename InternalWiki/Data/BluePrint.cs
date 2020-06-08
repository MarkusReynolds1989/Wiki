using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InternalWiki.Data

{
    public static class BluePrint
    {
        public static readonly Dictionary<int, string> ArticleList = new Dictionary<int, string>();

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
        private static void AddToArticleList(int id, string path)
        {
            ArticleList.Add(id, path);
        }

        //Increment the article count variable and add the new article to the folder.
        public static bool WriteArticle(string content, string title)
        {
            var path =
                @$"C:\Users\MR071411\Desktop\FunCode\CSharp\Wiki\InternalWiki\Pages\Articles\{title}.html";
            var articleId = ArticleList.Keys.Last() + 1;
            var addTitle = $"{title} \n {content}";
            AddToArticleList(articleId, path);
            File.WriteAllText(path, addTitle);
            return File.Exists(path);
        }

        //Don't mess with the dictionary, just rewrite the already existing file.
        public static bool ModifyArticle(string content, string title)
        {
            var path =
                @$"C:\Users\MR071411\Desktop\FunCode\CSharp\Wiki\InternalWiki\Pages\Articles\{title}.html";
            // Guard against writing files that don't exist.
            var addTitle = $"{title} \n {content}";
            File.WriteAllText(path, addTitle);

            return File.Exists(path);
        }

        //Reads the file into raw html that the page can consume.
        public static string ReadArticle(int id)
        {
            var article = ArticleList[id];
            var path = article;
            return File.ReadAllText(path);
        }
    }
}