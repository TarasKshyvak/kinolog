﻿namespace DAL.Entities
{
    public class User : BaseEntity
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int GenderId { get; set; }
        public DateTime BirthDate { get; set; }
        public Gender? Gender { get; set; }
        public IEnumerable<Rating>? MoviesRatings{ get; set; }
    }
}
