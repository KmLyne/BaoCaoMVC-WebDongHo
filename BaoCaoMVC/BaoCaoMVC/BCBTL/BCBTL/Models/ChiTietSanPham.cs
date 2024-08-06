namespace BCBTL.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChiTietSanPham")]
    public partial class ChiTietSanPham
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaChiTiet { get; set; }

        public int? MaSanPham { get; set; }

        [StringLength(50)]
        public string DuongKinh { get; set; }

        [StringLength(50)]
        public string ChongNuoc { get; set; }

        [StringLength(255)]
        public string ChatLieu { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
