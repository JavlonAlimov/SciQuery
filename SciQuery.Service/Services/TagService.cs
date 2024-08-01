using Microsoft.EntityFrameworkCore;
using SciQuery.Domain.Entities;
using SciQuery.Infrastructure.Persistance.DbContext;
using SciQuery.Service.Interfaces;

namespace SciQuery.Service.Services;

public class TagService(SciQueryDbContext context) : ITagService
{
    private readonly SciQueryDbContext _context = context;

    public async Task<IEnumerable<Tag>> GetAllTagsAsync()
    {
        return await _context.Tags.ToListAsync();
    }

    public async Task<Tag> GetTagByIdAsync(int id)
    {
        return await _context.Tags.FindAsync(id);
    }

    public async Task<Tag> CreateTagAsync(Tag tag)
    {
        _context.Tags.Add(tag);
        await _context.SaveChangesAsync();
        return tag;
    }

    public async Task<Tag> UpdateTagAsync(int id, Tag tag)
    {
        var existingTag = await _context.Tags.FindAsync(id);
        if (existingTag == null)
        {
            return null;
        }

        existingTag.Name = tag.Name;

        await _context.SaveChangesAsync();
        return existingTag;
    }

    public async Task<bool> DeleteTagAsync(int id)
    {
        var tag = await _context.Tags.FindAsync(id);
        if (tag == null)
        {
            return false;
        }

        _context.Tags.Remove(tag);
        await _context.SaveChangesAsync();
        return true;
    }
}
