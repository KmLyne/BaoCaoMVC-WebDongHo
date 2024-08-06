using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using WebDongHoMVC.ViewModel;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class DongHoNamController : Controller
    {
        // GET: User/DongHoNam
        private Model1 _context = new Model1();

        public ActionResult DonghoNam()
        {
            var dongHoNam = (from sp in _context.SanPhams
                             join dm in _context.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc
                             where dm.MaDanhMuc == 1
                             select new DonghoNamViewModel()
                             {
                                 TenSanPham = sp.TenSanPham,
                                 Gia = sp.Gia,
                                 MoTa = sp.MoTa,
                                 MaDanhMuc = dm.MaDanhMuc,
                                 HinhAnh = sp.HinhAnh
                             }).ToList();

            return View(dongHoNam);
        }
        public ActionResult ChiTietSP(int? maSP)
        {
            var dongHoNam = (from sp in _context.SanPhams
                             join dm in _context.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc
                             where dm.MaDanhMuc == 1
                             select new DonghoNamViewModel()
                             {
                                 TenSanPham = sp.TenSanPham,
                                 Gia = sp.Gia,
                                 MoTa = sp.MoTa,
                                 MaDanhMuc = dm.MaDanhMuc,
                                 HinhAnh = sp.HinhAnh
                             }).FirstOrDefault();

            if (dongHoNam == null)
            {
                ViewBag.Message = "Sản phẩm này không tồn tại";
                return RedirectToAction("DonghoNam", "DongHoNam");
            }

            return View(dongHoNam);
        }
    }
}