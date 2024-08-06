namespace TimeLess.Models
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
            CTDonHang = new HashSet<CTDonHang>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaSP { get; set; }

        [StringLength(100)]
        public string TenSP { get; set; }

        public decimal? GiaBan { get; set; }

        public string MoTa { get; set; }

        public DateTime? NgayNhap { get; set; }

        [StringLength(50)]
        public string Anh { get; set; }

        public int? Soluong { get; set; }

        public int? MaThuongHieu { get; set; }

        public int? Moi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CTDonHang> CTDonHang { get; set; }

        public virtual ThuongHieu ThuongHieu { get; set; }
    }
}
