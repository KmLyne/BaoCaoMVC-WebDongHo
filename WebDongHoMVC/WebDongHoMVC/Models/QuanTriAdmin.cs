namespace WebDongHoMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuanTriAdmin")]
    public partial class QuanTriAdmin
    {
        [Key]
        [Display(Name ="Mã admin")]
        public int MaAdmin { get; set; }
        [Display(Name = "Tên đăng nhập")]
        [Required(ErrorMessage ="Tên đăng nhập là bắt buộc")]
        [StringLength(255)]
        public string TenDangNhap { get; set; }
        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage ="Mật khẩu là bắt buộc")]
        [DataType(DataType.Password)]
        [StringLength(255)]
        public string MatKhau { get; set; }
        [Display(Name = "Họ tên")]
        [StringLength(255)]
        public string HoTen { get; set; }
        [Display(Name = "Email")]
        [StringLength(255)]
        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }
        [Display(Name = "Ngày đăng ký")]
        [DataType(DataType.DateTime)]
        [Column(TypeName = "datetime2")]
        public DateTime? NgayDangKy { get; set; }
    }
}
