namespace DAL.Entities
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IEnumerable<Creator>? Creators { get; set; }
    }
}
