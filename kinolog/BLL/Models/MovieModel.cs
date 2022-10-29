namespace BLL.Models
{
    public class MovieModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public int Year { get; set; }
        public Guid RatingId { get; set; }
        public double Rating { get; set; }
        public IEnumerable<Guid> RatingsIds { get; set; } = null!;
        public IEnumerable<GenreNameModel> Genres { get; set; } = null!;
        public IEnumerable<CreatorNameModel> Creators { get; set; } = null!;
    }
}
