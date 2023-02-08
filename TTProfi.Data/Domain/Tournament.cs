using System.ComponentModel.DataAnnotations.Schema;

namespace TTProfi.Data.Domain
{
    [Table("TOURNAMENT")]
    public class Tournament
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("TOURNAMENT_TYPE_ID")]
        public int TournamentTypeId { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("MAX_RATING")]
        public int MaxRaiting { get; set; }

        [Column("DATE")]
        public DateTime Date { get; set; }

        [Column("CREATE_DATE")]
        public DateTime CreateDate { get; set; }

        [Column("MODIFY_DATE")]
        public DateTime ModifyDate { get; set; }

        [Column("MAX_PLAYERS")]
        public int MaxPlayers { get; set; }

        [Column("DESCRIPTION")]
        public string Description { get; set; }

        public TournamentType TournamentType { get; set; }

        public List<Player> Players { get; set; }
    }
}
