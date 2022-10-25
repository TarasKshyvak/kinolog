namespace DAL.Entities
{
    public class Creator : BaseEntity
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Guid CountryId { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }
        public Country? Country { get; set; }
    }
}
