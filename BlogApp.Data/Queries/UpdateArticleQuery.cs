namespace BlogApp.Data.Queries
{
    /// <summary>
    /// Класс для обновления статьи
    /// </summary>
    public class UpdateArticleQuery
    {
        public string NewContent { get; } = string.Empty;
        public string NewName { get; } = string.Empty;

        public UpdateArticleQuery(string newContent, string newName) 
        {
            NewContent = newContent;
            NewName = newName;
        }
    }
}
