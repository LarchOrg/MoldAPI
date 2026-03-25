using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MoldApi.Entities
{
    [Table("lerp_mould_mst")]
    public class Mold
    {
        [Key]
        [Column("mld_iId")]
        public int MoldId { get; set; }
        [Column("mld_vCode")]
        public string MoldName { get; set; }

        [Column("mld_vStatus")]
        public string? Status { get; set; }

    }
}
