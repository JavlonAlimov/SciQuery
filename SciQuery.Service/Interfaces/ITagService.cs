using SciQuery.Domain.Entities;
using SciQuery.Service.DTOs.Tag;
using SciQuery.Service.Pagination.PaginatedList;

namespace SciQuery.Service.Interfaces;

public interface ITagService
{
    Task<PaginatedList<TagDto>> GetAllTagsAsync();
    Task<Tag> GetTagByIdAsync(int id);
    Task<Tag> CreateTagAsync(TagForCreateDto tag);
    Task<Tag> UpdateTagAsync(int id, Tag tag);
    Task<bool> DeleteTagAsync(int id);
}
