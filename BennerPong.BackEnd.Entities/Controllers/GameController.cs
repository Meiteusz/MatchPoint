using AutoMapper;
using MatchPoint.BackEnd.Entities.Models.DTOs;
using MatchPoint.BackEnd.Entities.Repository;
using MatchPoint.BackEnd.Entities.Repository.Interfaces;
using MatchPoint.BackEnd.GameAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace MatchPoint.BackEnd.Entities.Controllers
{
    [Route("api/games")]
    public class GameController : Controller
    {
        private ResponseDto _response { get; set; }
        private IGameRepository _gameRepository { get; set; }

        public GameController(IGameRepository gameRepository)
        {
            _response = new ResponseDto();
            _gameRepository = gameRepository;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<GameDto> games = await _gameRepository.GetGames();
                _response.Result = games;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }
            
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                GameDto game = await _gameRepository.GetGameById(id);
                _response.Result = game;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages = new List<string>() { ex.ToString() };
            }

            return _response;
        }
    }
}