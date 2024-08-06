namespace TimeLess.Models
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

        [StringLength(50)]
        public string DaThanhToan { get; set; }

        public int? TinhTrangGiao { get; set; }

        public int? MaKH { get; set; }

        public virtual CTDonHang CTDonHang { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
