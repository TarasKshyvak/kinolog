namespace DAL.Entities
{
    public class Movie : BaseEntity
    {
        public string? Name { get; set; }
        public int Year { get; set; }
        public Guid RatingId { get; set; }
        public IEnumerable<Genre>? Genres { get; set; }
        public IEnumerable<Rating>? UsersRatings { get; set; }
        public IEnumerable<Creator>? Creators { get; set; }
    }
}
