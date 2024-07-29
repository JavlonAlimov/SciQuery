using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace SciQuery.Domain.User;

public class User : IdentityUser
{
    [Key]
    public int Id {  get; set; }
}
