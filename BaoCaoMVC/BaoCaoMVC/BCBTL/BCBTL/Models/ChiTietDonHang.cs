namespace BCBTL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietDonHang")]
    public partial class ChiTietDonHang
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChiTietDonHang { get; set; }

        public int? MaDonHang { get; set; }

        public int? MaSanPham { get; set; }

        public int? SoLuong { get; set; }

        public int? Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }

        public virtual DonHang DonHang1 { get; set; }

        public virtual SanPham SanPham1 { get; set; }
    }
}
