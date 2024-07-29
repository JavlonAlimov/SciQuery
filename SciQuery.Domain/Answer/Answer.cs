namespace SciQuery.Domain.Answer;

public class Answer
{
    public int AnswerId { get; set; }
    public int QuestionId { get; set; }
    public int UserId { get; set; }
    public string? Body { get; set; }
    public string? ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set; }

}
