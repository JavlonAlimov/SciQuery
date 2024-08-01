using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SciQuery.Service.DTOs.Comment;
using SciQuery.Service.Interfaces;

namespace SciQuery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController(ICommentService commentService) : ControllerBase
    {
        private readonly ICommentService _commentService = commentService;

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCommentById(int id)
        {
            var comment = await _commentService.GetCommentByIdAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            return Ok(comment);
        }

        [HttpGet("question/{questionId}")]
        public async Task<IActionResult> GetAllCommentsByQuestionId(int questionId)
        {
            var comments = await _commentService.GetAllCommentsByQuestionIdAsync(questionId);
            return Ok(comments);
        }

        [HttpGet("answer/{answerId}")]
        public async Task<IActionResult> GetAllCommentsByAnswerId(int answerId)
        {
            var comments = await _commentService.GetAllCommentsByAnswerIdAsync(answerId);
            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> CreateComment([FromBody] CommentForCreateDto commentCreateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdComment = await _commentService.CreateCommentAsync(commentCreateDto);
            return CreatedAtAction(nameof(GetCommentById), new { id = createdComment.Id }, createdComment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateComment(int id, [FromBody] CommentForUpdateDto commentUpdateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedComment = await _commentService.UpdateCommentAsync(id, commentUpdateDto);
            if (updatedComment == null)
            {
                return NotFound();
            }

            return Ok(updatedComment);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteComment(int id)
        {
            var result = await _commentService.DeleteCommentAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
