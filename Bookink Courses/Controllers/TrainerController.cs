using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookink_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainerController : ControllerBase
    {
        private readonly IRepository<TrainerDto> repo;

        public TrainerController(IRepository<TrainerDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet("get-all-trainer")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}get-trainer-by-id", Name = "TrainerRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost("add-course")]
        public IActionResult AddItem(TrainerDto entity)
        {
            if (ModelState.IsValid)
                repo.AddItem(entity);
            else
                return BadRequest(ModelState);

            string url = Url.Link("TrainerRoute", new { id = entity.ID });
            return Created(url, entity);
        }

        [HttpPut("{id}update-trainer")]
        public IActionResult UpdateItem(TrainerDto entity)
        {
            if (ModelState.IsValid)
                repo.Update(entity);
            else
                return BadRequest(ModelState);

            return Ok(entity);
        }

        [HttpDelete("{id}delete-trainer")]
        public IActionResult DeleteItem(int id)
        {
            repo.Delete(id);
            return Ok("Delete Successfully");
        }
    }
}
