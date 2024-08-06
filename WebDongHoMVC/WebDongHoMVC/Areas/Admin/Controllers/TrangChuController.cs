using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;

namespace WebDongHoMVC.Areas.Admin.Controllers
{
    public class TrangChuController : Controller
    {
        // GET: Admin/TrangChu
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            // Lấy dữ liệu cho các thẻ tổng quan
            var doanhThu = db.ChiTietDonHangs.Sum(x => x.Gia * x.SoLuong) ?? 0;
            var tongDon = db.DonHangs.Count();
            var tongKhach = db.KhachHangs.Count();

            // Lưu dữ liệu vào ViewBag để truyền đến View
            ViewBag.DoanhThu = doanhThu;
            ViewBag.TongDon = tongDon;
            ViewBag.TongKhach = tongKhach;

            // Dữ liệu biểu đồ doanh thu
            var doanhThuTheoThang = db.ChiTietDonHangs
                .GroupBy(x => x.DonHang.NgayDangKy.HasValue)
                .Select(g => new { Thang = g.Key, DoanhThu = g.Sum(x => x.Gia * x.SoLuong) })
                .ToList();

            // Dữ liệu biểu đồ đơn hàng
            var donHangTheoThang = db.DonHangs
                .GroupBy(x => x.NgayDangKy.HasValue)
                .Select(g => new { Thang = g.Key, SoLuong = g.Count() })
                .ToList();

            // Dữ liệu biểu đồ khách hàng
            var khachHangTheoThang = db.KhachHangs
                .GroupBy(x => x.NgayDangKy.HasValue)
                .Select(g => new { Thang = g.Key, SoLuong = g.Count() })
                .ToList();

            // Truyền dữ liệu vào ViewBag
            ViewBag.DoanhThuTheoThang = doanhThuTheoThang;
            ViewBag.DonHangTheoThang = donHangTheoThang;
            ViewBag.KhachHangTheoThang = khachHangTheoThang;
            return View();
        }
    }
}