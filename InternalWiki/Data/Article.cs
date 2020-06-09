using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.AspNetCore.Html;

namespace InternalWiki.Data
{
    // Take a text file and convert it to an article.
    public class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Tags { get; set; }
        public string Path { get; set; }
        public DateTime PublishTime { get; set; }
        public DateTime UpDateTime { get; set; }

        // Insert a file, return an article object.
        public Article(List<string> raw)
        {
            Title = SetTitle(raw);
            Content = SetContent(raw);
            Tags = SetTags(raw);
            Path = SetPath();
        }

        // Insert components of an article, get an article.
        public Article(
            string title
            , string content
            , string tags)
        {
            Title = title;
            Content = content;
            Tags = tags;
            Path = SetPath();
        }

        private string SetTitle(List<string> rawInput) =>
            rawInput.First();

        private string SetContent(List<string> rawInput)
        {
            var content = new StringBuilder();
            foreach (var line in rawInput.Skip(1).SkipLast(1))
            {
                content.Append($"{line}");
            }
            return content.ToString();
        }

        private string SetTags(List<string> rawInput) =>
            rawInput.Last();

        private string SetPath() =>
            $@"C:\Users\MR071411\Desktop\FunCode\CSharp\Wiki\InternalWiki\Pages\Articles\{Title}.html";

        public string FormatArticle() =>
            $"{Title}\n{Content}\nTags: {Tags}";
    }
}