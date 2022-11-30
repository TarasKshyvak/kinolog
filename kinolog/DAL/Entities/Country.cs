namespace DAL.Entities
{
    public class Country : BaseEntity
    {
        public string Name { get; set; } = null!;
        public IEnumerable<Creator>? Creators { get; set; } = null!;
    }
}
