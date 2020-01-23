using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text;

namespace InternalWiki.Data
{
    //This class merely holds the article data.
    public class Article
    {
        public string Title { get; set; }
        //TODO: Does this need to be a list?
        public IList<string> Tags { get; set; }

        public string Content { get; set; }
    }
}
