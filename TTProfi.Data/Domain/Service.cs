using System.ComponentModel.DataAnnotations.Schema;

namespace TTProfi.Data.Domain
{
    [Table("SERVICE")]
    public class Service
    {
        [Column("ID")]
        public int Id { get; set; }

        [Column("NAME")]
        public string Name { get; set; }

        [Column("PRICE")]
        public decimal Price { get; set; }

        [Column("ICON")]
        public byte[] Icon { get; set; }
    }
}
