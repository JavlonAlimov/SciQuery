using AutoMapper;
using SciQuery.Domain.Entities;
using SciQuery.Domain.Votes;
using SciQuery.Service.DTOs.Answer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciQuery.Service.Mappings;

internal class AnswerMappings : Profile
{
    public AnswerMappings()
    {
        CreateMap<Answer, AnswerDto>()
            .ForMember(c => c.Votes, m => m.MapFrom(e => GetVotes(e)))
            .ReverseMap();
        CreateMap<AnswerForCreateDto, Answer>();
        CreateMap<AnswerForUpdateDto, Answer>();
    }
    private int GetVotes(Answer answer) =>
        answer.Votes.Count(x => x.VoteType == VoteEnum.Like) 
        - answer.Votes.Count(x => x.VoteType == VoteEnum.Dislike);
}
