using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookink_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Course_TrainerController : ControllerBase
    {
        private readonly IRepository<Course_Trainer_Dto> repo;

        public Course_TrainerController(IRepository<Course_Trainer_Dto> repo)
        {
            this.repo = repo;
        }

        [HttpGet("get-all-courses_trainer")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}get-course_trainer-by-id", Name = "Course_Trainer_Route")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost("add-course")]
        public IActionResult AddItem(Course_Trainer_Dto entity)
        {
            if (ModelState.IsValid)
                repo.AddItem(entity);
            else
                return BadRequest(ModelState);

            string url = Url.Link("Course_Trainer_Route", new { id = entity.Course_Id });
            return Created(url, entity);
        }

        [HttpPut("{id}update-course_trainer")]
        public IActionResult UpdateItem(Course_Trainer_Dto entity)
        {
            if (ModelState.IsValid)
                repo.Update(entity);
            else
                return BadRequest(ModelState);

            return Ok(entity);
        }

        [HttpDelete("{id}delete-course_trainer")]
        public IActionResult DeleteItem(int id)
        {
            repo.Delete(id);
            return Ok("Delete Successfully");
        }
    }
}
