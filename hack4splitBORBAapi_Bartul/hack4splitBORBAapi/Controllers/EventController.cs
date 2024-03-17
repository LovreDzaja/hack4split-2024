using hack4splitBORBAapi.Context;
using hack4splitBORBAapi.Model;
using hack4splitBORBAapi.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace hack4splitBORBAapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public EventController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: adding event
        [HttpPost]
        [Route("adding")]

        public async Task<ActionResult> AddingNewEvent([FromBody]EventModelDTO eventModelDTO)
        {
            if (eventModelDTO == null)
                return BadRequest();

            if (await CheckEventExistAsync(eventModelDTO.name!))
                return BadRequest(new
                {
                    Message = "Event Already Exists."
                });

            EventModel newEvent = new EventModel
            {
                Id = 0,
                latitude = eventModelDTO.latitude,
                longitude = eventModelDTO.longitude,
                name = eventModelDTO.name,
                description = eventModelDTO.description,
                image_url = eventModelDTO.image_url,
                contact =  eventModelDTO.contact,
                working_hours = eventModelDTO.working_hours,
                Ratings = null!
            };

            await _dbContext.Events!.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // GET: getting all activities
        [HttpGet]
        [Route("getActivities")]
        public async Task<IEnumerable<EventModel>> GetActivities()
        {

            var activities = await _dbContext.Events!.ToListAsync();

            return activities;
        }

        private Task<bool> CheckEventExistAsync(string name)
           => _dbContext.Events!.AnyAsync(x => x.name == name);
    }
}
