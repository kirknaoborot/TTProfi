using Microsoft.EntityFrameworkCore.Internal;

namespace TTProfi.Service.InputModels
{
    public class RegisterPlayersInputModel
    {
        /// <summary>
        /// Идентификатор турнира
        /// </summary>
        public int TournamentId { get; set; }

        /// <summary>
        /// Идентификатор типа турнира
        /// </summary>
        public int TournamentTypeId { get; set; }

        /// <summary>
        /// Список игроков
        /// </summary>
        public List<PlayerInputModel> Players { get; set; }
    }
}
