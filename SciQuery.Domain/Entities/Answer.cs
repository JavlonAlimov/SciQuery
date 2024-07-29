using SciQuery.Domain.Common;
using SciQuery.Domain.User;

namespace SciQuery.Domain.Entities;
public class Answer : EntityBase
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int UserId { get; set; }
    public User.User User { get; set; }
    public string? Body { get; set; }
    public List<string?>? ImagePath { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }

    public virtual ICollection<Vote> Votes { get; set; }
    public virtual ICollection<Comment> Comments{ get; set; }


}
