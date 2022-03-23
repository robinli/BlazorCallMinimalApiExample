global using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MinimalAPIs
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) 
        {

        }

        public DbSet<Syscode> Syscodes => Set<Syscode>();
    }


    [Table("SYSCODE")]
    public partial class Syscode
    {
        [Key]
        [Column("CODE_ID")]
        [StringLength(64)]
        public string? CodeId { get; set; }

        [Required]
        [Column("CKIND")]
        [StringLength(32)]
        public string Ckind { get; set; }

        [Required]
        [Column("CODE_NO")]
        [StringLength(64)]
        public string? CodeNo { get; set; }
        [Column("CODE_NAME")]
        [StringLength(64)]
        public string? CodeName { get; set; }
        //[Column("DESCTXT")]
        //[StringLength(256)]
        //public string Desctxt { get; set; }
        //[Column("ENABLED")]
        //[StringLength(1)]
        //public string Enabled { get; set; }
        //[Column("ORDERNUM")]
        //public int? Ordernum { get; set; }
        //[Column("COMP_NO")]
        //[StringLength(4)]
        //public string CompNo { get; set; }
        //[Column("DEP_NO")]
        //[StringLength(8)]
        //public string DepNo { get; set; }
        //[Column("DEL_CODE")]
        //[StringLength(1)]
        //public string DelCode { get; set; }
        //[Column("CHANGE_NUM")]
        //public int? ChangeNum { get; set; }
        //[Column("MOD_USER")]
        //[StringLength(8)]
        //public string ModUser { get; set; }
        //[Column("MOD_UTC", TypeName = "datetime")]
        //public DateTime? ModUtc { get; set; }
    }
}
