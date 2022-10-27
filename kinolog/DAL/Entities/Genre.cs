namespace DAL.Entities
{
    public class Genre : BaseEntity
    {
        public string Name{ get; set; } = null!;
        public IEnumerable<Movie> Movies { get; set; } = null!;
    }
}
