namespace BLL.Models
{
    public class CountryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public IEnumerable<Guid>? CreatorsIds { get; set; } = null!;
    }
}
