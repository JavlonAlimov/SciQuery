namespace SciQuery.Service.DTOs.User;

public class UserDto
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public int Reputation { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime LastLogindate { get; set; } = DateTime.Now;
}
