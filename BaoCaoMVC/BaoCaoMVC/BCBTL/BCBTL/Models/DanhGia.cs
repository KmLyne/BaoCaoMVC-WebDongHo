namespace BCBTL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanhGia")]
    public partial class DanhGia
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaDanhGia { get; set; }

        public int? MaSanPham { get; set; }

        public int? MaKhachHang { get; set; }

        [StringLength(255)]
        public string NoiDung { get; set; }

        public int? Diem { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayDangKy { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
