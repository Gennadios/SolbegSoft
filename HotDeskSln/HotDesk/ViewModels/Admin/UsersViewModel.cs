using HotDesk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class UsersViewModel
    {
        public IEnumerable<User> Users { get; set; }
        public IEnumerable<Role> Roles { get; set; }

        [Required(ErrorMessage = "First Name can't be null")]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Only latin characters allowed.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name can't be null")]
        [RegularExpression(@"[A-Za-z]+", ErrorMessage = "Only latin characters allowed.")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Login can't be null")]
        [Remote(action: "CheckUserLogin", controller: "Admin", ErrorMessage = "This username already exists.")]
        [RegularExpression(@"[A-Za-z0-9]+", ErrorMessage = "Only latin characters and numbers allowed.")]
        [StringLength(20, MinimumLength = 5, ErrorMessage = "Login should be between 5 and  40 characters long.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Password can't be null")]
        [StringLength(40, MinimumLength = 8, ErrorMessage = "Password should be between 8 and 40 characters long.")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Please, specify role")]
        public int RoleId { get; set; }
    }
}
