namespace DAL.Entities
{
    public class Movie : BaseEntity
    {
        public string? Name { get; set; }
        public int Year { get; set; }
        public Guid RatingId { get; set; }
        public IEnumerable<Genre>? Genre { get; set; }
        public Rating? Rating { get; set; }
        public IEnumerable<Creator>? Creators { get; set; }
    }
}
