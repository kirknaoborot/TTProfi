using System.ComponentModel.DataAnnotations.Schema;

namespace TTProfi.Data.Domain
{
    [Table("PLAYERS")]
    public class Player
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("FULL_NAME")]
        public string FullName { get; set; }

        [Column("RAITING")]
        public int Raiting { get; set; }

        [Column("TEAM_ID")]
        public Guid TeamId { get; set; }

        [Column("CREATE_DATE")]
        public DateTime CreateDate { get; set; }

        [Column("PHONE")]
        public string Phone { get; set; }

        public List<Tournament> Tournaments { get; set; }
    }
}
