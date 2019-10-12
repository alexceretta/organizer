using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using organizer_web.Interfaces;
using organizer_web.Models;

namespace organizer_web.Controllers
{

    [Route("/api/[controller]")]
    public class ToDoController : Controller
    {

        private readonly IToDoService toDoService;

        public ToDoController(IToDoService toDoService)
        {
            this.toDoService = toDoService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDo>>> Get()
        {
            var items = toDoService.GetAll();

            if (items.Count() == 0)
            {
                return NoContent();
            }

            return Ok(await items.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDo>> Get(Guid id)
        {
            var item = await toDoService.Get(id);

            if (item == null)
            {
                return NoContent();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<ActionResult<ToDo>> Post([FromBody] ToDo item)
        {
            var result = await toDoService.Create(item);
            Console.WriteLine("Created");
            return CreatedAtAction(nameof(Get), new { result.Id }, result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ToDo>> Update(Guid id, [FromBody] ToDo item)
        {
            var toDo = await toDoService.Get(id);

            if(toDo == null)
            {
                return NotFound();
            }

            var result = await toDoService.Update(item);
            Console.WriteLine("Updated");
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            await toDoService.Delete(id);
            Console.WriteLine("Deleted");
            return Ok();
        }
    }

}