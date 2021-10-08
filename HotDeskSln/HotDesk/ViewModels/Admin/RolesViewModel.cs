using HotDesk.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class RolesViewModel
    {
        public IEnumerable<Role> Roles { get; set; }

        [Required(ErrorMessage = "Role name cannot be null")]
        [Remote(action:"CheckRoleName", controller: "Admin", ErrorMessage = "This role already exists")]
        public string RoleName { get; set; }
    }
}
