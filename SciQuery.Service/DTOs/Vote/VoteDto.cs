using SciQuery.Domain.Votes;
using SciQuery.Service.DTOs.User;

namespace SciQuery.Service.DTOs.Vote;

public class VoteDto
{
    public int Id { get; set; }
    public VoteEnum VoteEnum { get; set; }
    public int QuestionId { get; set; }
    public int AnswerId { get; set; }
    public int UserId { get; set; }
    public UserDto User { get; set; }
}
