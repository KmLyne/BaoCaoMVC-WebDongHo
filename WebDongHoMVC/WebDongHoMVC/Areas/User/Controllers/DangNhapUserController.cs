using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using WebDongHoMVC.ViewModel;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class DangNhapUserController : Controller
    {
        // GET: User/DangNhapUser
        private Model1 db = new Model1();
        // Đăng ký
        [HttpGet]
        public ActionResult DangKyUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKyUser(KhachHang model)
        {
            if (ModelState.IsValid)
            {
                // Mã hóa mật khẩu trước khi lưu
                model.MatKhau = EncryptPassword(model.MatKhau);
                model.NgayDangKy = DateTime.Now;
                db.KhachHangs.Add(model);
                db.SaveChanges();
                return RedirectToAction("DangNhapUser");
            }
            return View(model);
        }

        [HttpGet]
        public ActionResult DangNhapUser()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhapUser(DangNhapViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Lấy người dùng từ cơ sở dữ liệu dựa trên email
                var user = db.KhachHangs
                             .FirstOrDefault(u => u.Email == model.Email);

                // So sánh mật khẩu của người dùng với mật khẩu lưu trong cơ sở dữ liệu
                if (user != null && user.MatKhau == model.MatKhau)
                {
                    Session["User"] = user;
                    Session["UserId"] = user.MaKhachHang;
                    return RedirectToAction("TrangChuUser", "TrangChuUser");
                }

                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác");
            }

            return View(model);
        }


        private string EncryptPassword(string matkhau)
        {
            return matkhau;
        }
    }

}