namespace BLL.Models
{
    /// <summary>
    /// Created to be used as an object property of UserModel
    /// </summary>
    public class RatingModel
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public string Movie { get; set; } = null!;
        public double Mark { get; set; }
    }
}
