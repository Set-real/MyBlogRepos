using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Data.Queries
{
    /// <summary>
    /// Класс для обновления пользователя
    /// </summary>
    public class UpdateUserQuery
    {
        public string NewUserFirstName { get; set; }
        public string NewPassword { get; set; }
        public string NewEmail { get; set; }
        public string NewUserLastName { get; set; }
        public string NewLogin { get; set; }
        public UpdateUserQuery(string newUserFirstName, string newPassword, string newEmail, string newUserLastName, string newLogin)
        {
            NewUserFirstName = newUserFirstName;
            NewPassword = newPassword;
            NewEmail = newEmail;
            NewUserLastName = newUserLastName;
            NewLogin = newLogin;
        }
    }
}
