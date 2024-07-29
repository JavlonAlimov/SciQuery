namespace SciQuery.Domain.Question;

public class Question
{
    public int QuestionId { get; set; }
    public int UserId { get; set; }
    public string?  Title { get; set; }
    public string?  Body { get; set; }
    public string?  ImagePath { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime UpdatedDate { get; set;}

}

