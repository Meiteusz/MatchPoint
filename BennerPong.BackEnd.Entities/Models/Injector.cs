using AutoMapper;
using MatchPoint.BackEnd.GameAPI.Models.DTOs;
using MatchPoint.BackEnd.GameAPI.Models.Interfaces;

namespace MatchPoint.BackEnd.GameAPI.Models
{
    public sealed class Injector
    {
        private bool _injected { get; set; }

        public void Inject(IServiceCollection services)
            => InitializeDependecyInjections(services);

        private void InitializeDependecyInjections(IServiceCollection services)
        {
            if (_injected)
                return;

            InjectAutoMapper(services);

            services.AddScoped<IGame, Game>();

            SetInjected();
        }

        private void InjectAutoMapper(IServiceCollection services)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<GameDto, Game>();
                cfg.CreateMap<Game, GameDto>();
            });

            IMapper mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }

        private void SetInjected()
            => _injected = true;
    }
}
