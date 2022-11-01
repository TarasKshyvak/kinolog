namespace DAL.Entities
{
    public class Creator : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Guid CountryId { get; set; }
        public Country Country { get; set; } = null!;
        public IEnumerable<Movie> Movies { get; set; } = null!;
        public IEnumerable<MovieCreator> MovieCreators { get; set; } = null!;
        public string GetFullName()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
