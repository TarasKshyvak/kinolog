namespace DAL.Entities
{
    public class Gender
    {
        public int Id { get; set; }
        public string? Name{ get; set; }
        public IEnumerable<User>? Users{ get; set; }
    }
}
