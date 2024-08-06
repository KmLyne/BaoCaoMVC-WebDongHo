using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using System.Data.Entity;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class DonHangUserController : Controller
    {
        // GET: User/DonHangUser
        private Model1 db = new Model1();

        // Hiển thị danh sách đơn hàng của người dùng
        public ActionResult DonHang()
        {
            // Lấy ID người dùng từ Session
            var userId = Session["UserId"] as int?;

            if (userId == null)
            {
                return RedirectToAction("DangNhapUser", "DangNhapUser"); // Chuyển hướng tới trang đăng nhập nếu chưa đăng nhập
            }

            var donHangs = db.DonHangs.Where(d => d.KhachHang.MaKhachHang == userId)
                .Include(d => d.KhachHang)
                .Include(d => d.ChiTietDonHangs.Select(c => c.SanPham))
                .ToList();

            return View(donHangs);
        }

        // Hiển thị chi tiết đơn hàng của người dùng
        public ActionResult DonHangDetails(int id)
        {
            // Lấy ID người dùng từ Session
            var userId = Session["UserId"] as int?;

            if (userId == null)
            {
                return RedirectToAction("DangNhapUser", "DangNhapUser"); // Chuyển hướng tới trang đăng nhập nếu chưa đăng nhập
            }

            var donHang = db.DonHangs.Include(d => d.KhachHang)
                .Include(d => d.ChiTietDonHangs.Select(c => c.SanPham))
                .FirstOrDefault(d => d.MaDonHang == id && d.KhachHang.MaKhachHang == userId);

            if (donHang == null)
            {
                return HttpNotFound();
            }

            return View(donHang);
        }
    }
}