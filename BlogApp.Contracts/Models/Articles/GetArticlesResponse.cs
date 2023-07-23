namespace BlogApp.Contracts.Models.Articles
{
    public class GetArticlesResponse
    {
        public int ArticleAmont { get; set; }
        public ArticleView[] articleViews { get ; set; }  

    }

    public class ArticleView
    {
        public Guid Id { get; set; }
        public string Content { get; set; }
        public string Name { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
