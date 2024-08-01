using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SciQuery.Domain.Exceptions;
using SciQuery.Domain.UserModels;
using SciQuery.Service.DTOs.Question;
using SciQuery.Service.Interfaces;
using System.Security.Claims;

namespace SciQuery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController(IQuestionService questionService) : ControllerBase
    {
        private readonly IQuestionService _questionService = questionService;

        [HttpGet]
        public async Task<IActionResult> GetAllQuestions()
        {
            var questions = await _questionService.GetAllAsync();
            return Ok(questions);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionById(int id)
        {
            var question = await _questionService.GetByIdAsync(id);
            if (question == null)
            {
                return NotFound();
            }
            return Ok(question);
        }

        [HttpPost]
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionForCreateDto questionDto)
        {
            questionDto.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier) 
                ?? throw new EntityNotFoundException("User does not found!");

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var createdQuestion = await _questionService.CreateAsync(questionDto);
            return Created(nameof(GetQuestionById),new { createdQuestion });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionForUpdateDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _questionService.UpdateAsync(id, questionDto);
            
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            await _questionService.DeleteAsync(id);
            
            return NoContent();
        }
    }
}
