using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebDongHoMVC.ViewModel
{
    public class GioHang
    {
        public int MaSanPham {  get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh {  get; set; }
        public int Gia {  get; set; }
        public int SoLuong {  get; set; }
        public int ThanhTien => SoLuong * Gia;

    }
    public class DonHang
    {
        [Display(Name = "Mã đơn hàng")]
        public int MaDonHang { get; set; }

        [Display(Name = "Mã khách hàng")]
        public int? MaKhachHang { get; set; }

        [Display(Name = "Ngày đặt")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        public DateTime? NgayDangKy { get; set; }

        [Display(Name = "Tổng tiền")]
        public int? TongTien { get; set; }

        [Display(Name = "Trạng thái")]
        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }
    }

    public class ChiTietDonHang
    {
        [Display(Name = "Mã chi tiết đơn hàng")]
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
    }

}