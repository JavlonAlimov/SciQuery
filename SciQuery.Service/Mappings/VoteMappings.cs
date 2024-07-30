using AutoMapper;
using SciQuery.Domain.Entities;
using SciQuery.Service.DTOs.Vote;

namespace SciQuery.Service.Mappings;

public class VoteMappings : Profile
{
    public VoteMappings()
    {
        CreateMap<Vote, VoteDto>().ReverseMap();
        CreateMap<VoteForCreateDto,Vote>();
    }
}
