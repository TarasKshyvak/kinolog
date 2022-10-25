namespace DAL.Entities
{
    public class Country
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Creator>? Creators { get; set; }
    }
}
