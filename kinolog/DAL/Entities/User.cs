namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string Username { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; } = null!;
        public IEnumerable<Rating> MoviesRatings{ get; set; } = null!;
    }
}
