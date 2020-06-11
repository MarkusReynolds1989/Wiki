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
        public string Content { get; set; }
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
    }
}