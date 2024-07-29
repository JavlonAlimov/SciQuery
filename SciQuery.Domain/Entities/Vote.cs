using SciQuery.Domain.Votes;

namespace SciQuery.Domain.Entities;

public class Vote
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User.User User { get; set; }
    public int QuestionId { get; set; }
    public Question Question { get; set; }
    public int AnswerId { get; set; }
    public Answer Answer { get; set; }
    public VoteEnum EnumType { get; set; }
}
