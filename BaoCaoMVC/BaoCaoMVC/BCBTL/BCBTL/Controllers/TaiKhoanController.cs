using BCBTL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCBTL.Controllers
{
    public class TaiKhoanController : Controller
    {
        // GET: TaiKhoan
        public ActionResult DangNhap()
        {
            // Trả về view để hiển thị form đăng nhập
            return View();
        }

        [HttpPost]
        public ActionResult DangNhap(DN model)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện logic đăng nhập ở đây, ví dụ: xác thực người dùng
                // Nếu thành công, chuyển hướng đến trang khác
                // Ngược lại, trả về view với thông báo lỗi

                // Cho mục đích minh họa, giả sử đăng nhập thành công
                return RedirectToAction("Taikhoan", "DangNhap");
            }

            // Nếu tới đây, nghĩa là có lỗi, hiển thị lại form
            ViewBag.LoginError = "Đăng nhập không hợp lệ.";
            return View("DangNhap", model);
        }

        // POST: Account/Register
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DangKy(DK model)
        {
            if (ModelState.IsValid)
            {
                // Thực hiện logic đăng ký ở đây, ví dụ: tạo người dùng
                // Nếu thành công, chuyển hướng đến trang đăng nhập
                // Ngược lại, trả về view với thông báo lỗi

                // Cho mục đích minh họa, giả sử đăng ký thành công
                return RedirectToAction("SanPham");
            }

            // Nếu tới đây, nghĩa là có lỗi, hiển thị lại form
            ViewBag.RegisterError = "Đăng ký không hợp lệ.";
            return View("SanPham", model);
        }
    }
}
    
