using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using SciQuery.Domain.Entities;
using SciQuery.Infrastructure.Persistance.DbContext;
using SciQuery.Service.DTOs.Tag;
using SciQuery.Service.Interfaces;
using SciQuery.Service.Mappings.Extensions;
using SciQuery.Service.Pagination.PaginatedList;

namespace SciQuery.Service.Services;

public class TagService(SciQueryDbContext context , IMapper mapper) : ITagService
{

    private readonly SciQueryDbContext _context = context;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<TagDto>> GetAllTagsAsync()
    {
        var tags = await _context.Tags
            .Include(t => t.QuestionTags)
            .AsNoTracking()
            .ToPaginatedList<TagDto, Tag>(_mapper.ConfigurationProvider, 1, 15);
        return tags;
    }

    public async Task<Tag> GetTagByIdAsync(int id)
    {
        return await _context.Tags.FindAsync(id);
    }

    public async Task<Tag> CreateTagAsync(TagForCreateDto tag)
    {
        var entity = _mapper.Map<Tag>(tag); 

        _context.Tags.Add(entity);
        await _context.SaveChangesAsync();
        return entity;
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
