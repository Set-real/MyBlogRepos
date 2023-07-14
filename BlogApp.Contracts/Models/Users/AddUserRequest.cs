﻿namespace BlogApp.Contracts.Models.Users
{
    public class AddUserRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Login { get ; set; }
        public DateTime Birthday { get; set; }
    }
}
