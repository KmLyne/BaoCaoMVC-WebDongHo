using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebDongHoMVC.ViewModel
{
    public class DonghoNamViewModel
    {
        public int? MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string MoTa { get; set; }
        public decimal? Gia { get; set; }
        public int? Soluongton { get; set; }
        public int? MaDanhMuc { get; set; }
        public string HinhAnh { get; set; }
    }
}