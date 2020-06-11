using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Html;
using Microsoft.CodeAnalysis.CSharp;
using Newtonsoft.Json;
using JsonConverter = System.Text.Json.Serialization.JsonConverter;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace InternalWiki.Data

{
    public static class ArticleController
    {
        public static readonly Dictionary<int, Article> ArticleList = new Dictionary<int, Article>();

        private const string ArticleJsonPath =
            @"C:\Users\MR071411\Desktop\FunCode\CSharp\Wiki\InternalWiki\Pages\Articles\articles.json";
        //"/home/markus/Code/C#/Wiki/InternalWiki/Pages/Articles/articles.json";

        // Add a single article to the list.
        private static void AddToArticleList(int id, Article article) =>
            ArticleList.Add(id, article);

        // Increment the articleID.
        private static int IncArticleId() =>
            ArticleList.Keys.Last() + 1;

        // Read data from Json into string.
        public static string ReadJsonArticles() =>
            File.ReadAllText(ArticleJsonPath);

        // Deserialize objects from Json into a list and process into dictionary.
        public static void DeserializeArticles(string data)
        {
            var articles = JsonConvert.DeserializeObject<List<Article>>(data);
            if (articles != null && articles.Count > 0)
            {
                var count = 0;
                foreach (var article in articles)
                {
                    AddToArticleList(count++, article);
                }
            }
        }

        // Serialize articles in dictionary to a string for writing.
        private static string SerializeArticles(Dictionary<int, Article>.ValueCollection articles) =>
            JsonConvert.SerializeObject(articles, Formatting.Indented);

        // Serialize and Write article into article.json.
        public static void WriteJsonArticles(Article article)
        {
            // Add the new article to the dictionary first that way we can write it to the json list.
            AddToArticleList(ArticleList.Count <= 0 ? 0 : IncArticleId(), article);

            File.WriteAllText(ArticleJsonPath, SerializeArticles(ArticleList.Values));
        }

        public static void UpdateJson() =>
            File.WriteAllText(ArticleJsonPath, SerializeArticles(ArticleList.Values));
    }
}