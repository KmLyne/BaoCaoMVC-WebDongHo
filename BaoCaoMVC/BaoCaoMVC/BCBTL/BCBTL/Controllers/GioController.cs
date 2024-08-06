using BCBTL.Models;
using BCBTL.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BCBTL.Controllers
{
    public class GioController : Controller
    {
        private Model1 _context = new Model1();

        // GET: Gio
        public ActionResult Gio()
        {
            // Khôi phục giỏ hàng từ Session hoặc tạo mới nếu không có
            var gioHang = Session["cart"] as List<GioViewModel> ?? new List<GioViewModel>();
            return View(gioHang);
        }

        [HttpPost]
        public ActionResult AddToCart(int maSP, int quantity)
        {
            // Khôi phục giỏ hàng từ Session hoặc tạo mới nếu không có
            var cart = Session["cart"] as List<GioViewModel> ?? new List<GioViewModel>();

            // Tìm sản phẩm từ cơ sở dữ liệu
            var product = _context.SanPham.Find(maSP);

            if (product != null)
            {
                // Kiểm tra sản phẩm đã tồn tại trong giỏ hàng chưa
                var existingProduct = cart.FirstOrDefault(p => p.MaSanPham == maSP);
                if (existingProduct != null)
                {
                    // Cập nhật số lượng của sản phẩm nếu đã tồn tại
                    existingProduct.SoLuong += quantity;
                }
                else
                {
                    // Thêm sản phẩm mới vào giỏ hàng
                    cart.Add(new GioViewModel
                    {
                        MaSanPham = product.MaSanPham,
                        TenSanPham = product.TenSanPham,
                        HinhAnh = product.HinhAnh,
                        SoLuong = quantity,
                        Gia = product.Gia
                    });
                }

                // Lưu giỏ hàng vào Session
                Session["cart"] = cart;
            }

            // Chuyển hướng về trang giỏ hàng
            return RedirectToAction("Gio");
        }

        [HttpPost]
        public ActionResult RemoveFromCart(int maSP)
        {
            var cart = Session["cart"] as List<GioViewModel> ?? new List<GioViewModel>();
            var product = cart.FirstOrDefault(p => p.MaSanPham == maSP);
            if (product != null)
            {
                cart.Remove(product);
                Session["cart"] = cart;
            }
            return RedirectToAction("Gio");
        }

        [HttpPost]
        public ActionResult UpdateQuantity(int maSP, int quantity)
        {
            var cart = Session["cart"] as List<GioViewModel> ?? new List<GioViewModel>();
            var product = cart.FirstOrDefault(p => p.MaSanPham == maSP);
            if (product != null)
            {
                product.SoLuong = quantity;
                Session["cart"] = cart;
            }
            return RedirectToAction("Gio");
        }
    }
}
