using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookink_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonController : ControllerBase
    {
        private readonly IRepository<LessonDto> repo;

        public LessonController(IRepository<LessonDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet("get-all-lesson")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}get-lesson-by-id", Name = "LessonRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost("add-course")]
        public IActionResult AddItem(LessonDto entity)
        {
            if (ModelState.IsValid)
                repo.AddItem(entity);
            else
                return BadRequest(ModelState);

            string url = Url.Link("LessonRoute", new { id = entity.ID });
            return Created(url, entity);
        }

        [HttpPut("{id}update-lesson")]
        public IActionResult UpdateItem(LessonDto entity)
        {
            if (ModelState.IsValid)
                repo.Update(entity);
            else
                return BadRequest(ModelState);

            return Ok(entity);
        }

        [HttpDelete("{id}delete-lesson")]
        public IActionResult DeleteItem(int id)
        {
            repo.Delete(id);
            return Ok("Delete Successfully");
        }
    }
}
