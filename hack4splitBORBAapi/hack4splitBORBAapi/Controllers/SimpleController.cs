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
    public class SimpleController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public SimpleController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // POST: add-event
        [HttpPost]
        [Route("add-event")]
        public async Task<ActionResult> AddEvent([FromBody] EventModelDTO eventObj) {

            if (eventObj == null)
                return Problem();

            EventModel newEvent = new EventModel{
                Id = 0,
                latitude = eventObj.latitude,
                longitude = eventObj.longitude,
                description = eventObj.description,
                image_url = eventObj.image_url,
                contact = eventObj.contact,
                working_hours = eventObj.working_hours,
                Ratings = null!
            };

            await _dbContext.Events!.AddAsync(newEvent);
            await _dbContext.SaveChangesAsync();

            return Ok(new
            {
                Message = "Created a new Event."
            });
        }

        // POST: add-rating
        [HttpPost]
        [Route("add-rating")]
        public async Task<ActionResult> AddRating([FromBody] RatingModelDTO ratingObj, [FromQuery] string userName, [FromQuery] string eventName) {
            
            if (ratingObj == null || userName == "" || eventName == "")
                return Problem();

            var user = await _dbContext.Users!.FirstOrDefaultAsync(x => x.Username == userName);
            var _event = await _dbContext.Events!.FirstOrDefaultAsync(x => x.name == eventName);

            if (user == null || _event == null)
                return NotFound(new {
                    Message = "User or Event not found."
                });

            RatingModel newRating = new RatingModel {
                Id = 0,
                Rating = ratingObj.Rating,
                Comment = ratingObj.Comment,
                User = user,
                Event = _event
            };

            user.Ratings.Add(newRating);
            _event.Ratings.Add(newRating);

            await _dbContext.SaveChangesAsync();

            return Ok(new {
                Message = "You created a new Rating for this Event."
            });
        }

        // GET: get-ratings
        [HttpGet]
        [Route("get-ratings")]
        public async Task<IEnumerable<RatingModel>> GetRatings() {

            var rating = await _dbContext.Ratings!.Include(x => x.User).Include(x => x.Event).ToListAsync();

            return rating;
        }

        // GET: event
        [HttpGet]
        [Route("get-event")]
        public async Task<IEnumerable<EventModel>> GetEvent() {

            var _event = await _dbContext.Events!.Include(x => x.Ratings).ToArrayAsync();

            return _event;
        }
    }
}
