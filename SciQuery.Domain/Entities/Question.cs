namespace SciQuery.Domain.Entities;

public class Question
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User.User User { get; set; }
    public string? Title { get; set; }
    public string? Body { get; set; }
    public List<string?>? ImagePath { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public DateTime? UpdatedDate { get; set; }


    public virtual ICollection<Answer> Answers { get; set; }
    public virtual ICollection<Comment> Comments { get; set; }
    public virtual ICollection<QuestionTag> QuestionTags { get; set; }
    public virtual ICollection<Vote> Votes { get; set; }


}

