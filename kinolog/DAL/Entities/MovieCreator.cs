namespace DAL.Entities
{
    public class MovieCreator : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Guid CreatorId{ get; set; }
        public int PositionId { get; set; }
        public Movie Movie { get; set; } = null!;
        public Creator Creator { get; set; } = null!;
        public Position Position { get; set; } = null!;
    }
}
