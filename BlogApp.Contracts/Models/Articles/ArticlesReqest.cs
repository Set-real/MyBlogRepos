using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Articles
{
    public class ArticlesReqest
    {
        public Guid Id { get; set; }
        public string ArticlesName { get; set; }
        public string ArticleContext { get; set; }
    }
}
