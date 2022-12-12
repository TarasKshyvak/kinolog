namespace BLL.Models
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public Guid? RoleId { get; set; }
        public IEnumerable<RatingModel>? MoviesRatings { get; set; } = null!;
        public string Password { get; set; } = string.Empty;
    }
}
