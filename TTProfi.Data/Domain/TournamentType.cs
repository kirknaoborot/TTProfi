using System.ComponentModel.DataAnnotations.Schema;

namespace TTProfi.Data.Domain
{
    [Table("TOURNAMENT_TYPE")]
    public class TournamentType
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("CREATE_DATE")]
        public DateTime CreateDate { get; set; }

        [Column("MODIFY_DATE")]
        public DateTime ModifyDate { get; set; }

        public List<Tournament> Tournaments { get; set; }
    }
}
