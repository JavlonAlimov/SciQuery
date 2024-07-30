using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SciQuery.Service.DTOs.Question;
using SciQuery.Service.Interfaces;

namespace SciQuery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuestionsController : ControllerBase
    {
        private readonly IQuestionService _questionService;

        public QuestionsController(IQuestionService questionService)
        {
            _questionService = questionService;
        }

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
        public async Task<IActionResult> CreateQuestion([FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdQuestion = await _questionService.CreateAsync(questionDto);
            return CreatedAtAction(nameof(GetQuestionById), new { id = createdQuestion.QuestionId }, createdQuestion);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateQuestion(int id, [FromBody] QuestionDto questionDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedQuestion = await _questionService.UpdateAsync(id, questionDto);
            if (updatedQuestion == null)
            {
                return NotFound();
            }

            return Ok(updatedQuestion);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuestion(int id)
        {
            var result = await _questionService.DeleteAsync(id);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
