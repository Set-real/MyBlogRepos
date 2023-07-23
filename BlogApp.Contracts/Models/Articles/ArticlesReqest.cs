namespace BlogApp.Contracts.Models.Articles
{
    public class ArticlesReqest
    {
        public Guid Id { get; set; }
        public string ArticlesName { get; set; }
        public string ArticleContext { get; set; }
    }
}
