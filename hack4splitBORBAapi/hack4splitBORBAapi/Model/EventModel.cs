using System.ComponentModel.DataAnnotations;

namespace hack4splitBORBAapi.Model
{
    public class EventModel
    {
        [Key]
        public uint Id { get; set; }

        public float latitude { get; set; }
        public float longitude { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? image_url { get; set; }
        public string? contact { get; set; }
        public string? working_hours { get; set; }

        public ICollection<RatingModel> Ratings { get; set; } = new List<RatingModel>();
    }
}
