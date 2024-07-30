using SciQuery.Service.DTOs.Answer;
using SciQuery.Service.DTOs.Comment;
using SciQuery.Service.DTOs.Tag;
using SciQuery.Service.DTOs.User;
using SciQuery.Service.DTOs.Vote;

namespace SciQuery.Service.DTOs.Question;

public class QuestionDto
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }
    public int UserId { get; set; }
    public UserDto User { get; set; }
    public int Votes { get; set; }

    public ICollection<AnswerDto> Answers { get; set; }
    public ICollection<CommentDto> Comments { get; set; }
    public ICollection<TagDto> Tags {  get; set; }
}
