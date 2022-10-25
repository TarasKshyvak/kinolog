namespace DAL.Entities
{
    public  class Rating : BaseEntity
    {
        public Guid UserId { get; set; }
        public Guid MovieId { get; set; }
        public double Mark { get; set; }   
        
        public User? User { get; set; }
        public IEnumerable<Movie>? Movies { get; set; }
    }
}
