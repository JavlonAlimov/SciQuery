using SciQuery.Domain.Entities;
using SciQuery.Service.DTOs.Question;

namespace SciQuery.Service.DTOs.Tag;

public class TagDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<QuestionTag> QuestionTags { get; set; }
}
