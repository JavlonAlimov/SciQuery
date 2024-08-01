using AutoMapper;
using SciQuery.Domain.Entities;
using SciQuery.Domain.Votes;
using SciQuery.Service.DTOs.Question;

namespace SciQuery.Service.Mappings
{
    public class QuestionMappings : Profile
    {
        public QuestionMappings()
        {
            CreateMap<Question, QuestionDto>();
            CreateMap<QuestionForCreateDto, Question>();
            CreateMap<QuestionForUpdateDto, Question>();
        }
    }
}
