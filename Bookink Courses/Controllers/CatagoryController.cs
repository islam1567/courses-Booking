using Bookink_Courses.Models.DTOs;
using Bookink_Courses.Models.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bookink_Courses.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        private readonly IRepository<CatagoryDto> repo;

        public CatagoryController(IRepository<CatagoryDto> repo)
        {
            this.repo = repo;
        }

        [HttpGet("get-all-catagory")]
        public IActionResult GetAll()
        {
            return Ok(repo.GetAll());
        }

        [HttpGet("{id:int}get-Catagory-by-id", Name = "CatagoryRoute")]
        public IActionResult GetById(int id)
        {
            return Ok(repo.GetById(id));
        }

        [HttpPost("add-catagory")]
        public IActionResult AddItem(CatagoryDto entity)
        {
            if (ModelState.IsValid)
                repo.AddItem(entity);
            else
                return BadRequest(ModelState);

            string url = Url.Link("CatagoryRoute", new { id = entity.ID });
            return Created(url, entity);
        }

        [HttpPut("{id}update-catagory")]
        public IActionResult UpdateItem(CatagoryDto entity)
        {
            if (ModelState.IsValid)
                repo.Update(entity);
            else
                return BadRequest(ModelState);

            return Ok(entity);
        }

        [HttpDelete("{id}delete-catagory")]
        public IActionResult DeleteItem(int id)
        {
            repo.Delete(id);
            return Ok("Delete Successfully");
        }
    }
}
