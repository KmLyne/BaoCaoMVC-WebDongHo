using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using WebDongHoMVC.ViewModel;

namespace WebDongHoMVC.Areas.Admin.Controllers
{
    public class DangNhapAdminController : Controller
    {
        // GET: Admin/DangNhapAdmin
        // Đăng nhập
        private Model1 db = new Model1();
        [HttpGet]
        public ActionResult DangNhapAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangNhapAdmin(DangNhapViewModel model)
        {
            if (ModelState.IsValid)
            {
                var admin = db.QuanTriAdmins
                              .FirstOrDefault(a => a.Email == model.Email && a.MatKhau == (model.MatKhau));
                if (admin != null)
                {
                    Session["Admin"] = admin;
                    return RedirectToAction("Index", "TrangChu");
                }
                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác");
            }
            return View(model);
        }

        public ActionResult DangXuatAdmin()
        {
            // Clear the session
            Session.Clear();

            // Redirect to the user login page
            return RedirectToAction("DangNhapUser", "DangNhapUser", new { area = "User" });
        }

    }
}