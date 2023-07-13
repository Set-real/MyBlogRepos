using Microsoft.AspNetCore.Mvc.Formatters;

namespace BlogApp.Model.DataModel
{
    /// <summary>
    /// Модель статьи
    /// </summary>
    public class Article
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; } = DateTime.Now;

        // Связь статьи с пользователем
        public Guid User_Id { get; set; }
        public User User { get; set; }

        // Привязка комментария к статье
        public List<Comment> Comments { get; set; } = new List<Comment>();

        // Создаю привязку с тегом "многие ко многим"
        public List<Teg> tegs { get; set; } = new List<Teg>();
    }
}
