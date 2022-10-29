namespace DAL.Entities
{
    public class Creator : BaseEntity
    {
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Guid CountryId { get; set; }
        public IEnumerable<Movie> Movies { get; set; } = null!;
        public Country Country { get; set; } = null!;
        public string GetFullName()
        {
            return $"{this.FirstName} {this.LastName}";
        }
    }
}
