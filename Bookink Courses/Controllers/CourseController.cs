using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookink_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CourseController : ControllerBase
    {
        private readonly IRepository<CourseDto> repo;

        public CourseController(IRepository<CourseDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet("get-all-courses")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}get_course_by_id", Name ="CourseRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost("add-course")]
        public IActionResult AddItem(CourseDto entity)
        {
            if(ModelState.IsValid)
                repo.AddItem(entity);
            else
                return BadRequest(ModelState);

            string url = Url.Link("CourseRoute", new { id = entity.ID });
            return Created(url, entity);
        }

        [HttpPut("{id}update-course")]
        public IActionResult UpdateItem(CourseDto entity)
        {
            if(ModelState.IsValid)
                repo.Update(entity);
            else
                return BadRequest(ModelState);

            return Ok(entity);
        }

        [HttpDelete("{id}delete-course")]
        public IActionResult DeleteItem(int id)
        {
            repo.Delete(id);
            return Ok("Delete Successfully");
        }
    }
}
