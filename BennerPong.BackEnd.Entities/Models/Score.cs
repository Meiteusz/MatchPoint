using System.ComponentModel.DataAnnotations;

namespace MatchPoint.BackEnd.GameAPI.Models
{
    public class Score
    {
        [Key]
        public int Id { get; set; }
        public int PointsOne { get; set; }
        public int PointsTwo { get; set; }
        public int MaxPoints { get; set; } = 5;
        public int GameId { get; set; }
        public Game Game { get; set; }
    }
}
