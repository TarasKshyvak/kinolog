namespace BLL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; } = null!;
        public IEnumerable<RatingModel> MoviesRatings { get; set; } = null!;
    }
}
