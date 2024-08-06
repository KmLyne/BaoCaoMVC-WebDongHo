namespace WebDongHoMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SanPham")]
    public partial class SanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SanPham()
        {
            ChiTietDonHangs = new HashSet<ChiTietDonHang>();
            ChiTietSanPhams = new HashSet<ChiTietSanPham>();
            DanhGias = new HashSet<DanhGia>();
            TuKhoaSanPhams = new HashSet<TuKhoaSanPham>();
        }

        [Key]
        [Display(Name ="Mã sản phẩm")]
        public int MaSanPham { get; set; }
        [Display(Name = "Tên sản phẩm")]
        [Required(ErrorMessage ="Tên sản phẩm là bắt buộc")]
        [StringLength(100, ErrorMessage ="Tên sản phẩm không được vượt quá 100 kí tự!")]
        public string TenSanPham { get; set; }
        [Display(Name = "Mô tả")]
        [Required(ErrorMessage = "Mô tả là bắt buộc")]
        public string MoTa { get; set; }
        [Display(Name = "Giá")]
        [Range(0, double.MaxValue, ErrorMessage = "Giá phải là một số dương")]
        [Required(ErrorMessage = "Giá là bắt buộc")]
        public int? Gia { get; set; }
        [Display(Name = "Số lượng")]
        [Required(ErrorMessage = "Số lượng là bắt buộc")]
        [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải là một số nguyên không âm")]
        public int? SoLuong { get; set; }
        [Display(Name = "Danh mục")]
       
        public int? MaDanhMuc { get; set; }
        [Display(Name = "Hình ảnh")]
        [Required(ErrorMessage = "Hình ảnh là bắt buộc")]
        [StringLength(50)]
        public string HinhAnh { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietDonHang> ChiTietDonHangs { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ChiTietSanPham> ChiTietSanPhams { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DanhGia> DanhGias { get; set; }

        public virtual DanhMuc DanhMuc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TuKhoaSanPham> TuKhoaSanPhams { get; set; }
    }
}
