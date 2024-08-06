namespace TimeLess
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ThuongHieu")]
    public partial class ThuongHieu
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int MaThuongHieu { get; set; }

        [StringLength(100)]
        public string TenThuongHieu { get; set; }
    }
}
