using SciQuery.Service.DTOs.Comment;
using SciQuery.Service.DTOs.User;
using SciQuery.Service.DTOs.Vote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SciQuery.Service.DTOs.Answer
{
    public class AnswerDto
    {
        public int Id { get; set; }
        public string? Body { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int QuestionId { get; set; }
        public string UserId { get; set; }
        public UserDto User { get; set; }

        public ICollection<VoteDto> Votes { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}
