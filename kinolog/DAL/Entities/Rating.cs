namespace DAL.Entities
{
    public  class Rating : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public double Mark { get; set; }
    }
}
