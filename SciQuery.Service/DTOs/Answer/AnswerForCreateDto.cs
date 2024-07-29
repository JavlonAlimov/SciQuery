using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciQuery.Service.DTOs.Answer
{
    public class AnswerForCreateDto
    {
        public string Body { get; set; }
        public int QuestionId { get; set; }
        public int UserId { get; set; }

    }
}
