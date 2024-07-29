using System.ComponentModel.DataAnnotations;

namespace SciQuery.Service.User.AddOrUpdateUserModel;

public class AddOrUpdateUserModel
{
    [Required(ErrorMessage = "Username is Required")]
    public string UserName { get; set; } = string.Empty;
    
    [Required(ErrorMessage ="Password is Required")]
    public string Password { get; set; } = string.Empty;
 
    [Required(ErrorMessage ="Email is Required")]
    public string Email { get; set; } = string.Empty;
}
