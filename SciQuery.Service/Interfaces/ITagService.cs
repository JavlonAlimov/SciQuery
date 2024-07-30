using SciQuery.Domain.Entities;
using SciQuery.Service.DTOs.Answer;
using SciQuery.Service.DTOs.Question;
using SciQuery.Service.Pagination.PaginatedList;

namespace SciQuery.Service.Interfaces;

public interface ITagService
{
    Task<IEnumerable<Tag>> GetAllTagsAsync();
    Task<Tag> GetTagByIdAsync(int id);
    Task<Tag> CreateTagAsync(Tag tag);
    Task<Tag> UpdateTagAsync(int id, Tag tag);
    Task<bool> DeleteTagAsync(int id);
}
