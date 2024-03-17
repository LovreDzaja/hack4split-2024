using hack4splitBORBAapi.Context;
using hack4splitBORBAapi.Model;
using hack4splitBORBAapi.Model.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata.Ecma335;

namespace hack4splitBORBAapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public RatingController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        // POST: adding new rating
        [HttpPost]
        [Route("add")]
        public async Task<ActionResult> AddRating([FromBody]RatingDTO ratingDTO, string username, string eventName)
        {
            if (ratingDTO == null)
                return BadRequest();

            var user = await _dbContext.Users!.Where( x => x.Username == username!).FirstOrDefaultAsync();
            var activity = await _dbContext.Events!.Where(x => x.name == eventName!).FirstOrDefaultAsync();

            RatingModel rating = new RatingModel
            {
                Id = 0,
                Rating = ratingDTO.Rating,
                Comment = ratingDTO.Comment,
                User = user!,
                Event = activity!
            };

            await _dbContext.Ratings!.AddAsync(rating);

            user!.Ratings.Add(rating);
            activity!.Ratings.Add(rating);

            await _dbContext.SaveChangesAsync();

            return Ok();
        }

        // GET: getting all activities
        [HttpGet]
        [Route("getRatings")]
        public async Task<IEnumerable<RatingModel>> GetRatings()
        {

            var ratings = await _dbContext.Ratings!.ToListAsync();

            return ratings;
        }
    }
}
