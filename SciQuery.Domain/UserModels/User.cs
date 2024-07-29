using Microsoft.AspNetCore.Identity;
using SciQuery.Domain.Common;
using SciQuery.Domain.Entities;

namespace SciQuery.Domain.User;

public class User : IdentityUser
{
    public string ProfileImagePath { get; set; }
    public int Reputation {  get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? LastLogindate { get; set; } 

    public virtual ICollection<Question> Questions { get; set;}
    public virtual ICollection<Answer> Answers { get; set; }
    public virtual ICollection<Vote> Votes { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<ReputationChange> ReputationChanges { get; set; }
}
