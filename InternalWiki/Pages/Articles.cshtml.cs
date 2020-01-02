using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using InternalWiki.Data;
using System.IO;
using System.Text;
namespace InternalWiki
{
    public class ArticlesModel : PageModel
    {
        public void OnPost()
        {

        }
        public void OnGet()
        {
            //Method to pull all links to articles
        }
    }
}