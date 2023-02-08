using TTProfi.Data;
using TTProfi.Service.InputModels;
using TTProfi.Service.Interfaces;
using TTProfi.Data.Domain;
using Microsoft.EntityFrameworkCore;
using TTProfi.Core.Models.Tournament;

namespace TTProfi.Service.Services
{
    internal class TournamentService : ITournamentService
    {
        private readonly TTContext _context;

        public TournamentService(TTContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Метод получения списка турниров
        /// </summary>
        /// <returns></returns>
        public async Task<IReadOnlyCollection<TournamentModel>> GetTournaments()
        {
            var tournaments = await _context.Tournaments
                .Where(_ => _.Date > DateTime.Now)
                .Include(_ => _.Players)
                .OrderBy(_ => _.Date)
                .ToListAsync();

            var result = tournaments
                .Select(_ => new TournamentModel
                {
                    Date = _.Date,
                    Description = _.Description,
                    Id = _.Id,
                    MaxPlayers = _.MaxPlayers,
                    Name = _.Name,
                    TournamentTypeId = _.TournamentTypeId,
                    Players = _.Players is null ? new List<PlayerModel>() : _.Players.Select(_ => new PlayerModel
                    {
                        FullName = _.FullName,
                        Raiting = _.Raiting
                    }).ToList()
                }).ToList();

            return result;
        }

        /// <summary>
        /// Метод создания турнира
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task Create(CreateTournamentInputModel model)
        {
            var tournament = new Tournament
            {
                CreateDate = DateTime.Now,
                ModifyDate= DateTime.Now,
                TournamentTypeId = model.TournamentTypeId,
                Name = model.Name,
                Description= model.Description,
                Date = model.Date,
                MaxPlayers= model.MaxPlayers,
                MaxRaiting = model.MaxRaiting
            };

            await _context.Tournaments.AddAsync(tournament);
            await _context.SaveChangesAsync();
        }

        /// <summary>
        /// Регистрация  игроков на турнир
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public async Task RegisterPlayers(RegisterPlayersInputModel model)
        {
            if (model.Players is null || model.Players.Count > 2 || model.Players.Count < 1)
            {
                throw new InvalidOperationException("Не верное кол-во участников на турнир");
            }

            var teamId = Guid.NewGuid();

            var tournament = await _context.Tournaments
                .Include(_ => _.Players)
                .FirstOrDefaultAsync(_ => _.Id == model.TournamentId);

            if (tournament == null)
            {
                throw new InvalidOperationException("Турнир не найден");
            }

            if (tournament.Players is null)
            {
                tournament.Players = new List<Player>();
            }

            foreach (var item in model.Players)
            {
                var player = new Player
                {
                    CreateDate = DateTime.Now,
                    FullName = item.FullName,
                    Phone = item.Phone,
                    Raiting = 0,
                    TeamId = teamId
                };

                tournament.Players.Add(player);
            }

            await _context.SaveChangesAsync();
        }

        public async Task CreateTypeTournament(string name)
        {
            var typeTournament = new TournamentType
            {
                CreateDate = DateTime.Now,
                ModifyDate = DateTime.Now,
                Name = name,
            };

            await _context.TournamentTypes.AddAsync(typeTournament);

            await _context.SaveChangesAsync();
        }

        public async Task<IReadOnlyCollection<TypeTournamentModel>> GetTypeTournaments()
        {
            var types = await _context.TournamentTypes.ToListAsync();

            var result = types
                .Select(_ => new TypeTournamentModel
                {
                    Id = _.Id,
                    Name = _.Name
                })
                .ToList();

            return result;
        }
    }
}
