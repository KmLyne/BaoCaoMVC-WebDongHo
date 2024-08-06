namespace BCBTL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TinTuc")]
    public partial class TinTuc
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaTinTuc { get; set; }

        [StringLength(255)]
        public string TieuDe { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        [StringLength(255)]
        public string TacGia { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayDangKy { get; set; }
    }
}
