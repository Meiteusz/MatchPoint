using MatchPoint.BackEnd.GameAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace MatchPoint.BackEnd.Entities.Models
{
    public class PlayersRanking
    {
        [Key]
        public int Id { get; set; }
        public List<Player>? ListRanking { get; set; }
    }
}
