using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BCBTL.ViewModel
{
    public class GioViewModel
    {
        public int? MaSanPham {  get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int? SoLuong { get; set; }
        public decimal? Gia {  get; set; }
        
    }
}