using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using WebDongHoMVC.ViewModel;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class GioHangController : Controller
    {
        // GET: User/GioHang
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            var gh = Session["GioHang"] as List<GioHang>;
            return View(gh);
        }
        //sửa chỗ này
        //[HttpPost]
        //public ActionResult ThemVaoGio(int id)
        //{
        //    var sp = db.SanPhams.Find(id);
        //    if (sp == null)
        //    {
        //        return HttpNotFound();
        //    }

        //    var gh = Session["GioHang"] as List<GioHang>;
        //    if (gh == null)
        //    {
        //        gh = new List<GioHang>();
        //    }

        //    var gioHang = gh.SingleOrDefault(p => p.MaSanPham == id);
        //    if (gioHang != null)
        //    {
        //        gioHang.SoLuong++;
        //    }
        //    else
        //    {
        //        gh.Add(new GioHang
        //        {
        //            MaSanPham = sp.MaSanPham,
        //            HinhAnh = sp.HinhAnh,
        //            TenSanPham = sp.TenSanPham,
        //            Gia = sp.Gia.HasValue ? sp.Gia.Value : 0,
        //            SoLuong = 1
        //        });
        //    }

        //    Session["GioHang"] = gh;
        //    return Json(new { success = true });
        //}
        public ActionResult ThemVaoGio(int id)
        {
            var sp = db.SanPhams.Find(id);
            if (sp == null)
            {
                return HttpNotFound();
            }

            var gh = Session["GioHang"] as List<GioHang>;
            if (gh == null)
            {
                gh = new List<GioHang>();
            }

            var gioHang = gh.SingleOrDefault(p => p.MaSanPham == id);
            if (gioHang != null)
            {
                gioHang.SoLuong++;
            }
            else
            {
                gh.Add(new GioHang
                {
                    MaSanPham = sp.MaSanPham,
                    HinhAnh = sp.HinhAnh,
                    TenSanPham = sp.TenSanPham,
                    Gia = sp.Gia.HasValue ? sp.Gia.Value : 0,
                    SoLuong = 1
                });
            }

            Session["GioHang"] = gh;
            return Json(new { success = true });
        }
        [HttpPost]
        public ActionResult CapNhatGioHang(int id, int soluong)
        {
            var gh = Session["GioHang"] as List<GioHang>;
            var gioHang = gh.SingleOrDefault(p => p.MaSanPham == id);
            if (gioHang != null)
            {
                gioHang.SoLuong = soluong;
            }
            Session["GioHang"] = gh;
            return Json(new { success = true });
        }
        //[HttpPost]
        //public ActionResult CapNhatGioHang(int id, int soluong)
        //{
        //    var gh = Session["GioHang"] as List<GioHang>;
        //    var gioHang = gh.SingleOrDefault(p => p.MaSanPham == id);
        //    if (gioHang != null)
        //    {
        //        var sp = db.SanPhams.Find(id);
        //        if (sp == null || soluong > sp.SoLuong) // Kiểm tra số lượng tồn
        //        {
        //            return Json(new { success = false, message = "Số lượng yêu cầu vượt quá số lượng tồn." });
        //        }

        //        gioHang.SoLuong = soluong;
        //        Session["GioHang"] = gh;
        //    }
        //    return Json(new { success = true });
        //}

        [HttpPost]
        public ActionResult XoaGioHang(int id)
        {
            var cart = Session["GioHang"] as List<GioHang> ?? new List<GioHang>();
            var itemToRemove = cart.FirstOrDefault(c => c.MaSanPham == id);
            if (itemToRemove != null)
            {
                cart.Remove(itemToRemove);
            }
            Session["GioHang"] = cart;
            return RedirectToAction("Index", "GioHang");
        }



        [HttpPost]
        public ActionResult XoaTatCa()
        {
            Session["GioHang"] = null;
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult ThanhToan()
        {
            var cart = Session["GioHang"] as List<GioHang>;
            var khachHang = Session["User"] as KhachHang; // Assumes customer info is stored in session

            if (khachHang == null)
            {
                // Redirect to login page if customer is not logged in
                return RedirectToAction("DangNhapUser", "DangNhapUser");
            }

            if (cart == null || !cart.Any())
            {
                // Redirect to cart page if cart is empty
                return RedirectToAction("Index", "GioHang");
            }

            var donHang = new WebDongHoMVC.Models.DonHang
            {
                MaKhachHang = khachHang.MaKhachHang,
                NgayDangKy = DateTime.Now,
                TongTien = cart.Sum(item => item.ThanhTien),
                TrangThai = "Chờ xử lý"
            };

            db.DonHangs.Add(donHang);
            db.SaveChanges();

            // Add order details
            foreach (var item in cart)
            {
                var chiTietDonHang = new WebDongHoMVC.Models.ChiTietDonHang
                {
                    MaDonHang = donHang.MaDonHang,
                    MaSanPham = item.MaSanPham,
                    SoLuong = item.SoLuong,
                    Gia = item.Gia
                };

                db.ChiTietDonHangs.Add(chiTietDonHang);
            }

            db.SaveChanges();

            // Clear the cart after successful payment
            Session["GioHang"] = null;

            // Redirect to a success page or order summary
            return RedirectToAction("Success");
        }
        //[HttpPost]
        //public ActionResult ThanhToan()
        //{
        //    var cart = Session["GioHang"] as List<GioHang>;
        //    var khachHang = Session["User"] as KhachHang; // Assumes customer info is stored in session

        //    if (khachHang == null)
        //    {
        //        // Redirect to login page if customer is not logged in
        //        return RedirectToAction("DangNhapUser", "DangNhapUser");
        //    }

        //    if (cart == null || !cart.Any())
        //    {
        //        // Redirect to cart page if cart is empty
        //        return RedirectToAction("Index", "GioHang");
        //    }

        //    var donHang = new WebDongHoMVC.Models.DonHang
        //    {
        //        MaKhachHang = khachHang.MaKhachHang,
        //        NgayDangKy = DateTime.Now,
        //        TongTien = cart.Sum(item => item.ThanhTien),
        //        TrangThai = "Chờ xử lý"
        //    };

        //    db.DonHangs.Add(donHang);
        //    db.SaveChanges();

        //    // Add order details and update stock
        //    foreach (var item in cart)
        //    {
        //        var chiTietDonHang = new WebDongHoMVC.Models.ChiTietDonHang
        //        {
        //            MaDonHang = donHang.MaDonHang,
        //            MaSanPham = item.MaSanPham,
        //            SoLuong = item.SoLuong,
        //            Gia = item.Gia
        //        };

        //        db.ChiTietDonHangs.Add(chiTietDonHang);

        //        var sp = db.SanPhams.Find(item.MaSanPham);
        //        if (sp != null)
        //        {
        //            sp.SoLuong -= item.SoLuong; // Cập nhật số lượng tồn
        //        }
        //    }

        //    db.SaveChanges();

        //    // Clear the cart after successful payment
        //    Session["GioHang"] = null;

        //    // Redirect to a success page or order summary
        //    return RedirectToAction("Success");
        //}


        public ActionResult Success()
        {
            return View();
        }

    }
}
