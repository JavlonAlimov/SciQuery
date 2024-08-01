using SciQuery.Domain.UserModels;

namespace SciQuery.Domain.Entities;
public class Answer
{
    public int Id { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public string? Body { get; set; }
    public List<string?>? ImagePath { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; } = DateTime.Now;

    public virtual ICollection<Vote> Votes { get; set; }
    public virtual ICollection<Comment> Comments{ get; set; }


}
