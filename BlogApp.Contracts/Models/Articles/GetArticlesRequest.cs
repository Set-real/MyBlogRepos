using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Articles
{
    public class GetArticlesRequest
    {
        public int ArticleAmont { get; set; }
        public ArticleView[] articleViews { get ; set; }  

    }

    public class ArticleView
    {
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
