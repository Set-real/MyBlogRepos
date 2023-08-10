using BlogApp.Data.Model.DataModel;
using System.Security.Principal;

namespace BlogApp.Contracts.Models.Users
{
    public class UserRequest
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get ; set; }
        public Role Role { get; set; }
    }
}
