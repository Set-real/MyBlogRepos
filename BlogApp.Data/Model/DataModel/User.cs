using BlogApp.Model.DataModel;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace BlogApp.Model
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string Login { get; set; }
        public DateTime Birthday { get; set; }

        // Привязываю статью к пользователю
        public List<Article> Articles { get; set; } = new List<Article>();

        // Привязываю комментарий к пользователю
        public List<Comment> Comments { get; set; } = new List<Comment>();
    }
}
