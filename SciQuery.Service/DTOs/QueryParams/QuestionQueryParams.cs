using System.Globalization;

namespace SciQuery.Service.DTOs.QueryParams;

public class QuestionQueryParams
{
    public ICollection<string> Tags{ get; set; }
}
