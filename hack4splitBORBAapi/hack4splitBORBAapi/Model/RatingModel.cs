using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace hack4splitBORBAapi.Model
{
    public class RatingModel
    {
        [Key]
        public uint Id { get; set; }
        public string? Rating { get; set; }
        public string? Comment { get; set; }

        public UserModel User { get; set; } = null!;
        public EventModel Event { get; set; } = null!;
    }
}
