using AutoMapper;
using SciQuery.Domain.Entities;
using SciQuery.Domain.Votes;
using SciQuery.Service.DTOs.Question;
namespace SciQuery.Service.Mappings;

public class QuestionMappings : Profile
{
    public QuestionMappings()
    {
        CreateMap<Question, QuestionDto>()
            .ForMember(c => c.Votes, m => m.MapFrom(e => GetVotes(e)))
            .ReverseMap();
        CreateMap<QuestionForCreateDto, Question>();
        CreateMap<QuestionForUpdateDto, Question>();
    }
    private int GetVotes(Question question) => 
        question.Votes.Count(x => x.VoteType == VoteEnum.Like)
            - question.Votes.Count(x => x.VoteType == VoteEnum.Dislike);
}
