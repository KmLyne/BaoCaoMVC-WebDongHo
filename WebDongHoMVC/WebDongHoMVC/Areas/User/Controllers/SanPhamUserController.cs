using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using WebDongHoMVC.ViewModel;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class SanPhamUserController : Controller
    {
            private Model1 _context = new Model1();

            // GET: SanPham
            public ActionResult SanPhamUser()
            {
                var products = _context.SanPhams
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
                var product = _context.SanPhams
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
                    return RedirectToAction("SanPhamUser", "SanPhamUser");
                }

                return View(product);
            }

            [HttpPost]
            public ActionResult Search(string keyword)
            {
                var products = _context.SanPhams
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

                return View("SanPhamUser", products); // Hiển thị kết quả tìm kiếm trên view SanPham
            }
        }
    
}