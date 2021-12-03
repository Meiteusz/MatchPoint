using MatchPoint.BackEnd.GameAPI.Models.DTOs;

namespace MatchPoint.BackEnd.Entities.Repository.Interfaces
{
    public interface IGameRepository
    {
        Task<IEnumerable<GameDto>> GetGames();
        Task<GameDto> GetGameById(int id);
        Task<GameDto> CreateUpdateGame(GameDto gameDto);
        Task<bool> DeleteGame(int id);
    }
}
