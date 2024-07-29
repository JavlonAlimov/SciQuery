using Microsoft.AspNetCore.Identity;

namespace SciQuery.Domain.User;

public class User : IdentityUser
{
    public string ProfileImagePath { get; set; }
    public int Reputation {  get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastLogindate {  get; set; }
}
