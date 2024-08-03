using SciQuery.Domain.Entities;
using SciQuery.Service.DTOs.QueryParams;
using SciQuery.Service.DTOs.Question;
using SciQuery.Service.DTOs.Tag;
using SciQuery.Service.Pagination.PaginatedList;

namespace SciQuery.Service.Interfaces;

public interface IQuestionService
{
    Task<PaginatedList<QuestionDto>> GetQuestionsByTags(QuestionQueryParams queryParams);
    Task<PaginatedList<QuestionDto>> GetAllAsync();
    Task<QuestionDto> GetByIdAsync(int id);
    Task<QuestionDto> CreateAsync(QuestionForCreateDto question);   
    Task UpdateAsync(int id,QuestionForUpdateDto question);
    Task DeleteAsync(int id);
}
