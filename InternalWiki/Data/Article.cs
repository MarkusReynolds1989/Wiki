using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InternalWiki.Data
{
    public class Article
    {
        public string Title { get; set; }
        public IList<string> Tags { get; set; }
        public string Content { get; set; }
        
    }
}
