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
        public UserViewModel[] UserView { get; set; }
    }
    public class UserViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string GetFullName()
        {
            return FirstName + " " + LastName;
        }
    }
}
