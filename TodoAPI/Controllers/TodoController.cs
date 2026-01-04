using Microsoft.AspNetCore.Mvc;
using TodoAPI.Core.Models;
using TodoAPI.Core.Interfaces;

namespace TodoAPI.Controllers
{
    //[ApiController]
    //[Route("api/[controller]")]
    //public class TodoController : ControllerBase
    //{
    //    private readonly ITodoRepository _repository;

    //    public TodoController(ITodoRepository repository)
    //    {
    //        _repository = repository;
    //    }

    //    [HttpGet]
    //    public IActionResult Get() => Ok(_repository.GetAll());

    //    [HttpPost]
    //    public IActionResult Post([FromBody] TodoItem item)
    //    {
    //        _repository.Add(item);
    //        return CreatedAtAction(nameof(Get), new { id = item.Id }, item);
    //    }

    //    [HttpDelete("{id}")]
    //    public IActionResult Delete(int id)
    //    {
    //        _repository.Delete(id);
    //        return NoContent();
    //    }
    //}
}
