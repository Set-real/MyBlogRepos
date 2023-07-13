using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Articles
{
    public class EditArticleRequest
    {
        public string NewArticleName { get; set; }
        public string NewArticleContext { get; set; }
    }
}
