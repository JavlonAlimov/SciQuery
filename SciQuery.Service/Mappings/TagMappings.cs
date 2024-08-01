using AutoMapper;
using SciQuery.Domain.Entities;
using SciQuery.Service.DTOs.Question;
using SciQuery.Service.DTOs.Tag;
using SciQuery.Service.Interfaces;

namespace SciQuery.Service.Mappings;

public class TagMappings : Profile
{
    public TagMappings()
    {
        CreateMap<Tag, TagDto>().ReverseMap();  
        CreateMap<TagForCreateDto,Tag>().ReverseMap();
    }
}
