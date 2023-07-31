using BlogApp.Data.Model.DataModel;
using BlogApp.Model.DataModel;

namespace BlogApp.Model
{
    /// <summary>
    /// Модель пользователя
    /// </summary>
    public class User
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public string Email { get; set; } 
        public string Password { get; set; }
        public string Login { get; set; }

        // Привязываю статью к пользователю
        public List<Article> Articles { get; set; } = new List<Article>();

        // Привязываю комментарий к пользователю
        public List<Comment> Comments { get; set; } = new List<Comment>();
        
        // Привязываю роли многие ко многим
        public List<Role> Roles { get; set; } = new List<Role>();
    }
}
