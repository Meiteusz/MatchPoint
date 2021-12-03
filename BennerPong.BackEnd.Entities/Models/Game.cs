using MatchPoint.BackEnd.GameAPI.Models.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MatchPoint.BackEnd.GameAPI.Models
{
    public class Game : IGame
    {
        [Key]
        public int Id { get; set; }
        public Player? PlayerOne { get; set; }
        public Player? PlayerOneId { get; set; }
        public Player? PlayerTwo { get; set; }
        public Player? PlayerTwoId { get; set; }
        public Score Score { get; set; }

        public bool IsOneVersusOneGame()
            => PlayerOne != null && PlayerTwo != null;
    }
}
