using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SciQuery.Domain.Entities;
using SciQuery.Domain.Exceptions;
using SciQuery.Infrastructure.Persistance.DbContext;
using SciQuery.Service.DTOs.Question;
using SciQuery.Service.Interfaces;
using SciQuery.Service.Mappings.Extensions;
using SciQuery.Service.Pagination.PaginatedList;

namespace SciQuery.Service.Services;

public class QuestionService(SciQueryDbContext dbContext,IMapper mapper) : IQuestionService
{
    private readonly SciQueryDbContext _context = dbContext;
    private readonly IMapper _mapper = mapper;

    public async Task<PaginatedList<QuestionDto>> GetAllAsync()
    {
        var questions = await _context.Questions
            .Include(q => q.User)
            .ToPaginatedList<QuestionDto, Question>(_mapper.ConfigurationProvider, 1, 15);

        return _mapper.Map<PaginatedList<QuestionDto>>(questions);
    }
    public async Task<QuestionDto> GetByIdAsync(int id)
    {
        var question = await _context.Questions
            .Include(q => q.User)
            .Include(q => q.QuestionTags)
            .ThenInclude(qt => qt.Tag)
            .Include(q => q.Comments)
            .Include(q => q.Votes)
            .AsNoTracking()
            .AsSplitQuery()
            .FirstOrDefaultAsync(q => q.Id == id);
        
        return question == null
            ? throw new EntityNotFoundException($"Question with id : {id} is not found!")
            : _mapper.Map<QuestionDto>(question);
    }

    public async Task<QuestionDto> CreateAsync(QuestionForCreateDto questionCreateDto)
    {
        var question = _mapper.Map<Question>(questionCreateDto);
        question.CreatedDate = DateTime.UtcNow;

        _context.Questions.Add(question);
        await _context.SaveChangesAsync();

        return _mapper.Map<QuestionDto>(question);
    }

    public async Task UpdateAsync(int id, QuestionForUpdateDto questionUpdateDto)
    {
        var question = await _context.Questions.FindAsync(id) 
            ?? throw new EntityNotFoundException($"Question with id : {id} is not found!");

        _mapper.Map(questionUpdateDto, question);
        
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var question = await _context.Questions.FindAsync(id)
            ?? throw new EntityNotFoundException($"Question with id : {id} is not found!");


        _context.Questions.Remove(question);
        await _context.SaveChangesAsync();
    }
}

