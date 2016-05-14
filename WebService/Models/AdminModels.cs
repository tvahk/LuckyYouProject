using System.Collections.Generic;
using DomainLogic.IdentityModels;

namespace WebService.Models
{
    // Models used in admin page

    public class LoginModel
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }

    public class ManageModel
    {
        public List<User> Users { get; set; }
        public List<string> Roles { get; set; } 
    }

    public class EditModel
    {
        public User User { get; set; }
        public bool IsAdmin { get; set; }
    }
}