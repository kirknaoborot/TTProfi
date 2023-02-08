using TTProfi.Core.Models.Tournament;
using TTProfi.Service.InputModels;

namespace TTProfi.Service.Interfaces
{
    public interface ITournamentService
    {
        Task Create(CreateTournamentInputModel model);

        Task RegisterPlayers(RegisterPlayersInputModel model);

        Task<IReadOnlyCollection<TournamentModel>> GetTournaments();

        Task CreateTypeTournament(string name);

        Task<IReadOnlyCollection<TypeTournamentModel>> GetTypeTournaments();
    }
}
