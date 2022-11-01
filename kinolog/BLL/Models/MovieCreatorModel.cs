namespace BLL.Models
{
    public class MovieCreatorModel
    {
        public Guid Id { get; set; }
        public Guid MovieId { get; set; }
        public Guid CreatorId { get; set; }
        public int PositionId { get; set; }
        public string Movie { get; set; } = null!;
        public string Creator { get; set; } = null!;
        public string Position { get; set; } = null!;
    }
}
