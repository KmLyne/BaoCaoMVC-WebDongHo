namespace WebDongHoMVC.Models
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
        [Display(Name ="Mã chi tiết đơn hàng")]
        public int MaChiTietDonHang { get; set; }
        [Display(Name = "Mã đơn hàng")]
        public int? MaDonHang { get; set; }
        [Display(Name = "Mã sản phẩm")]
        public int? MaSanPham { get; set; }
        [Display(Name = "Số lượng")]
        public int? SoLuong { get; set; }
        [Display(Name = "Giá")]
        public int? Gia { get; set; }

        public virtual DonHang DonHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
