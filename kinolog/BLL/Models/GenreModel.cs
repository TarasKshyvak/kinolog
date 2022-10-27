namespace BLL.Models
{
    public class GenreModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Guid> MoviesIds { get; set; } = null!;
    }
}
