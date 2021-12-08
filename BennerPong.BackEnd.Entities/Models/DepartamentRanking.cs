using System.ComponentModel.DataAnnotations;

namespace MatchPoint.BackEnd.Entities.Models
{
    public class DepartamentRanking
    {
        [Key]
        public int Id { get; set; }
        public List<PlayersRanking>? PlayersRanking { get; set; }
    }
}
