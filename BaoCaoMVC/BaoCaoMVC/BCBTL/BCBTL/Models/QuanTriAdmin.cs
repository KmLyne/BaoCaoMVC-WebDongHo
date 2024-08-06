namespace BCBTL.Models
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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaAdmin { get; set; }

        [StringLength(255)]
        public string TenDangNhap { get; set; }

        [StringLength(255)]
        public string MatKhau { get; set; }

        [StringLength(255)]
        public string HoTen { get; set; }

        [StringLength(255)]
        public string Email { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime? NgayDangKy { get; set; }
    }
}
