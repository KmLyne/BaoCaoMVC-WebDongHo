namespace TimeLess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDonHang { get; set; }

        public DateTime? NgayGiao { get; set; }

        public DateTime? NgayDat { get; set; }

        [MaxLength(50)]
        public byte[] DaThanhToan { get; set; }

        public int? TinhTrangGiao { get; set; }

        [StringLength(10)]
        public string MaKH { get; set; }
    }
}
