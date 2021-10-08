using System.ComponentModel.DataAnnotations;

namespace HotDesk.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please, input login.")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Please, input password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
