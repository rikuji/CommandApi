using CommandApi.Data;
using CommandApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CommandApi.Controllers
{
    [ApiController]
    [Route("api/commands")]
    public class CommandsController : ControllerBase
    {
        private readonly CommandContext _context;

        public CommandsController(CommandContext context) => _context = context;

        [HttpGet]
        [Route("")]
        public ActionResult<IEnumerable<Command>> Get()
        {
            return _context.CommandItems;
        }

        [HttpGet]
        [Route("{id:int}")]
        public ActionResult<Command> GetById(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            return commandItem;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Command> Post([FromBody] Command command)
        {
            _context.CommandItems.Add(command);
            _context.SaveChanges();

            return CreatedAtAction("GetById", new Command { Id = command.Id }, command);
        }

        [HttpPut]
        [Route("{id:int}")]
        public ActionResult Put(int id, [FromBody] Command command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            _context.Entry(command).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete]
        [Route("{id:int}")]
        public ActionResult<Command> Delete(int id)
        {
            var commandItem = _context.CommandItems.Find(id);

            if (commandItem == null)
            {
                return NotFound();
            }

            _context.CommandItems.Remove(commandItem);
            _context.SaveChanges();

            return commandItem;
        }
    }
}
