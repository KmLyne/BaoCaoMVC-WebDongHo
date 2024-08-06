namespace WebDongHoMVC.Models
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
        [Display(Name ="Mã tin tức")]
        public int MaTinTuc { get; set; }
        [Display(Name = "Tiêu đề")]

        [Required(ErrorMessage ="Tiêu đề là bắt buộc")]
        [StringLength(255)]
        public string TieuDe { get; set; }
        [Display(Name = "Nội dung")]
        [Required(ErrorMessage ="Nội dung là bắt buộc")]
        [StringLength(255)]
        public string NoiDung { get; set; }
        [Display(Name = "Tác giả")]
        [StringLength(255)]
        public string TacGia { get; set; }
        [Display(Name = "Ngày đăng")]
        [Column(TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? NgayDangKy { get; set; }

        [Column(TypeName = "timestamp")]
        [MaxLength(8)]
        [Timestamp]
        public byte[] RowVersion { get; set; }
        [Display(Name = "Mã tin tức")]
        [StringLength(255)]
        public string HinhAnh { get; set; }
    }
}
