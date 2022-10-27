namespace BLL.Models
{
    public class RatingModel
    {
        public Guid Id { get; set; }
        public string Movie { get; set; } = null!;
        public double Mark { get; set; }
    }
}
