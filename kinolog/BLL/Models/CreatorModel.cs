namespace BLL.Models
{
    public class CreatorModel
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public Guid CountryId { get; set; }
        public string Country { get; set; } = null!;
        public IEnumerable<MovieModel> Movies { get; set; } = null!;
    }
}
