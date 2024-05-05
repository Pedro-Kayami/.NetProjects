using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudyCrudAPI.Entities;
using StudyCrudAPI.Persistence;

namespace StudyCrudAPI.Controllers
{
    [Route("api/dev-events")]
    [ApiController]
    public class DevEventsController : ControllerBase
    {
        private readonly DevEventsDbContext _context;

        public DevEventsController(DevEventsDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
           var devEvents = _context.DevEvents.Where(id => !id.IsDeleted).ToList();
            return Ok(devEvents);
        }

        [HttpGet("{id}")]
        public IActionResult GetbyId(Guid id)
        {
            var devEvent = _context.DevEvents.FirstOrDefault(d => d.id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            return Ok(devEvent);
        }

        [HttpPost]
        public IActionResult Post(DevEvent devEvent)
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetbyId), new { id = devEvent.id }, devEvent);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id,DevEvent input)
        {
            var devEvent = _context.DevEvents.FirstOrDefault(d => d.id == id);
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Update(input.Title, input.Description, input.StartDate, input.EndDate);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var devEvent = _context.DevEvents.FirstOrDefault(d => d.id == id);
            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Delete();

            return NoContent();
        }

        [HttpPost("{id}/speakers")]
        public IActionResult PostSpeaker(Guid id, DevEventsSpeaker speaker)
        {
            var devEvent = _context.DevEvents.FirstOrDefault(d => d.id == id);

            if (devEvent == null)
            {
                return NotFound();
            }

            devEvent.Speakers.Add(speaker);
            return NoContent();
        }
    }
}
