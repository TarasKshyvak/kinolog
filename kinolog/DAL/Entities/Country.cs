namespace DAL.Entities
{
    public class Country : BaseEntity
    {
        public string? Name { get; set; }
        public IEnumerable<Creator>? Creators { get; set; }
    }
}
