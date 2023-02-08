using System.ComponentModel.DataAnnotations.Schema;

namespace TTProfi.Core.Models.Tournament
{
    public class TournamentModel
    {
        /// <summary>
        /// Идентификатор турнира
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Идентификатор типа турнира
        /// </summary>
        public int TournamentTypeId { get; set; }

        /// <summary>
        /// Название турнира
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Дата проведения турнира
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Максимальное кол-во игроков 
        /// </summary>
        public int MaxPlayers { get; set; }

        /// <summary>
        /// Описание турнира
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Список игроков
        /// </summary>
        public List<PlayerModel> Players { get; set; }
    }
}
