namespace WebDongHoMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DonHang")]
    public partial class DonHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public DonHang()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
        }

        [Key]
        [Display(Name ="Mã đơn hàng")]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        public virtual KhachHang KhachHang { get; set; }
    }
}
