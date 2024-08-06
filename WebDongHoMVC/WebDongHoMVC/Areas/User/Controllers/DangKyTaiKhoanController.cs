using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class DangKyTaiKhoanController : Controller
    {
        // GET: User/DangKyTaiKhoan
        // GET: User/DangNhapUser
        private Model1 db = new Model1();
        // Đăng ký
        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(KhachHang model)
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

        private string EncryptPassword(string matkhau)
        {
            return matkhau;
        }
    }
}