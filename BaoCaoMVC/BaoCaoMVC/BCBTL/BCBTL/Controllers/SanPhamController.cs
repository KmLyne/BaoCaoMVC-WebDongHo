using BCBTL.Models;
using BCBTL.ViewModel;
using System.Linq;
using System.Web.Mvc;

namespace BCBTL.Controllers
{
    public class SanPhamController : Controller
    {
        private Model1 _context = new Model1();

        // GET: SanPham
        public ActionResult SanPham()
        {
            var products = _context.SanPham
                .Select(s => new DonghoNamViewModel
                {
                    TenSanPham = s.TenSanPham,
                    Gia = s.Gia,
                    MoTa = s.MoTa,
                    Soluongton = s.SoLuong,
                    HinhAnh = s.HinhAnh,
                    MaSanPham = s.MaSanPham
                })
                .ToList();

            return View(products);
        }

        public ActionResult ChiTiet(int maSP)
        {
            var product = _context.SanPham
                .Where(s => s.MaSanPham == maSP)
                .Select(s => new DonghoNamViewModel
                {
                    TenSanPham = s.TenSanPham,
                    Gia = s.Gia,
                    MoTa = s.MoTa,
                    Soluongton = s.SoLuong,
                    HinhAnh = s.HinhAnh,
                    MaSanPham = s.MaSanPham
                }).FirstOrDefault();

            if (product == null)
            {
                ViewBag.Message = "Sản phẩm này không tồn tại";
                return RedirectToAction("SanPham", "SanPham");
            }

            return View(product);
        }

        [HttpPost]
        public ActionResult Search(string keyword)
        {
            var products = _context.SanPham
                .Where(s => s.TenSanPham.Contains(keyword))
                .Select(s => new DonghoNamViewModel
                {
                    TenSanPham = s.TenSanPham,
                    Gia = s.Gia,
                    MoTa = s.MoTa,
                    Soluongton = s.SoLuong,
                    HinhAnh = s.HinhAnh,
                    MaSanPham = s.MaSanPham
                })
                .ToList();

            return View("SanPham", products); // Hiển thị kết quả tìm kiếm trên view SanPham
        }
    }
}
