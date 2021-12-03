using MatchPoint.BackEnd.GameAPI.Models.Enums;

namespace MatchPoint.BackEnd.GameAPI.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public EDepartment Department { get; set; }
    }
}
