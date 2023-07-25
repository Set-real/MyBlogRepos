using BlogApp.Model;

namespace BlogApp.Data.Model.DataModel
{
    public class Role
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }

        // Привязываю пользователей многие ко многим
        public List<User> Users { get; set; } = new List<User>();
    }
}
