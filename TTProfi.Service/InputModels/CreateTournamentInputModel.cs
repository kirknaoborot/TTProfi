namespace TTProfi.Service.InputModels
{
    public class CreateTournamentInputModel
    {
        /// <summary>
        /// Идентификатор турнира
        /// </summary>
        public int TournamentTypeId { get; set; }

        /// <summary>
        /// Название турнира
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Максимальный рейтинг участников
        /// </summary>
        public int MaxRaiting { get; set; }

        /// <summary>
        /// Дата проведения турнира
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Максимальное кол-во игороков
        /// </summary>
        public int MaxPlayers { get; set; }

        /// <summary>
        /// Описание турнира
        /// </summary>
        public string Description { get; set; }
    }
}
