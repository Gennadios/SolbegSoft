using HotDesk.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }

        [Required(ErrorMessage = "First Name can't be null")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name can't be null")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login can't be null")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password can't be null")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, specify role")]
        public int RoleId { get; set; }
    }
}
