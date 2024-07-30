using SciQuery.Domain.Entities;

namespace SciQuery.Service.Interfaces;

public interface ITagService
{
    Task<IEnumerable<Tag>> GetAllTagsAsync();
    Task<Tag> GetTagByIdAsync(int id);
    Task<Tag> CreateTagAsync(Tag tag);
    Task<Tag> UpdateTagAsync(int id, Tag tag);
    Task<bool> DeleteTagAsync(int id);
}
