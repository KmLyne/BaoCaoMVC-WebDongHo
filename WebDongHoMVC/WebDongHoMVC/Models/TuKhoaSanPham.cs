namespace WebDongHoMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TuKhoaSanPham")]
    public partial class TuKhoaSanPham
    {
        [Key]
        public int MaTuKhoa { get; set; }

        public int? MaSanPham { get; set; }

        [StringLength(255)]
        public string TuKhoa { get; set; }

        public virtual SanPham SanPham { get; set; }
    }
}
