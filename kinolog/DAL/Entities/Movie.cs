namespace DAL.Entities
{
    public class Movie : BaseEntity
    {
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public Guid RatingId { get; set; }
        public IEnumerable<Genre> Genres { get; set; } = null!;
        public IEnumerable<Rating> UsersRatings { get; set; } = null!;
        public IEnumerable<Creator> Creators { get; set; } = null!;
    }
}
