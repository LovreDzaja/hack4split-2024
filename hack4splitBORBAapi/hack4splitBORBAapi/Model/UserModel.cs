using System.ComponentModel.DataAnnotations;

namespace hack4splitBORBAapi.Model
{
    public class UserModel
    {
        [Key]
        public uint Id { get; set; }
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        public ICollection<RatingModel> Ratings { get; set; } = new List<RatingModel>();
    }
}
