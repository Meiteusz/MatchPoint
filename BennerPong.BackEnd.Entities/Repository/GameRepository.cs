using MatchPoint.BackEnd.Entities.Repository.Interfaces;
using MatchPoint.BackEnd.GameAPI.Models.DTOs;
using AutoMapper;
using MatchPoint.BackEnd.GameAPI.DbContext;
using MatchPoint.BackEnd.GameAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace MatchPoint.BackEnd.Entities.Repository
{
    public class GameRepository : IGameRepository
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _db;

        public GameRepository(IMapper mapper, ApplicationDbContext db)
        {
            _mapper = mapper;
            _db = db;
        }

        public async Task<GameDto> CreateUpdateGame(GameDto gameDto)
        {
            var game = _mapper.Map<GameDto, Game>(gameDto);
            if (game.Id > 0)
            {
                _db.Games.Update(game);
            }
            else
            {
                _db.Games.Add(game);
            }

            await _db.SaveChangesAsync();
            return _mapper.Map<Game, GameDto>(game);
        }

        public async Task<bool> DeleteGame(int id)
        {
            try
            {
                var game = _db.Games.FirstOrDefault(w => w.Id == id);
                if (game != null)
                {
                    _db.Games.Remove(game);
                    await _db.SaveChangesAsync();
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<GameDto> GetGameById(int id)
        {
            var game = await _db.Games.Where(w => w.Id == id).FirstOrDefaultAsync();
            return _mapper.Map<GameDto>(game);
        }

        public async Task<IEnumerable<GameDto>> GetGames()
        {
            var games = await _db.Games.ToListAsync();
            return _mapper.Map<List<GameDto>>(games);
        }
    }
}
