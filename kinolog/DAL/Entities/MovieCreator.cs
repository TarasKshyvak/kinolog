namespace DAL.Entities
{
    public class MovieCreator : BaseEntity
    {
        public Guid MovieId { get; set; }
        public Guid CreatorId{ get; set; }
        public int PositionId { get; set; }
    }
}
