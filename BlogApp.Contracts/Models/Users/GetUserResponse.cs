using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Contracts.Models.Users
{
    public class GetUserResponse
    {
        public int UserAmount { get; set; }
        public UserView UserView { get; set; }
    }
    public class UserView
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }
        public DateTime Birthday { get; set; }
    }
}
