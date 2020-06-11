using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InternalWiki.Data
{
    // Take a text file and convert it to an article.
    public class Article
    {
        public string Title { get; set; }
        public string Content { get;set; } 
        public string Tags { get; set; }
        public DateTime PublishTime { get; set; }
        public DateTime UpDateTime { get; set; }

        // Insert components of an article, get an article.
        public Article(
            string title
            , string content
            , string tags
            , DateTime publishTime
            , DateTime upDateTime)
        {
            Title = title;
            Content = content;
            Tags = tags;
            UpDateTime = DateTime.Now;
            PublishTime = publishTime;
        }

        //private string SetTitle(List<string> rawInput) =>
        //   rawInput.First();

        private string SetContent(List<string> rawInput)
        {
            var content = new StringBuilder();
            foreach (var line in rawInput.Skip(1).SkipLast(1))
            {
                content.Append($"{line}");
            }

            return content.ToString();
        }

        public string FormatContent()
        {
            var newString = string.Empty;
            foreach (var item in Content.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                newString += $"{item}\n";
            }

            return newString;
        }
        
        private string SetTags(List<string> rawInput) =>
            rawInput.Last();

        /* private string SetPath() =>
            $@"C:\Users\MR071411\Desktop\FunCode\CSharp\Wiki\InternalWiki\Pages\Articles\{Title}.html"; */

        public string FormatArticle() =>
            $"{Title}\n{Content}\nTags: {Tags}";
    }
}