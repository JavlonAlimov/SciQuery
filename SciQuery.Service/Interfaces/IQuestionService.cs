using SciQuery.Service.DTOs.Question;

namespace SciQuery.Service.Interfaces;

public interface IQuestionService
{
    Task<List<QuestionDto>> GetAll();
    Task<QuestionDto> GetById(int id);
    
}
