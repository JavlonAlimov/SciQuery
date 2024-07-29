using System.ComponentModel.DataAnnotations;

namespace SciQuery.Service.User.LoginViewModel;

public class LoginViewModel
{
    [Required(ErrorMessage = "User name is required")]
    public string UserName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Password is required")]
    public string Password { get; set; } = string.Empty;
}
