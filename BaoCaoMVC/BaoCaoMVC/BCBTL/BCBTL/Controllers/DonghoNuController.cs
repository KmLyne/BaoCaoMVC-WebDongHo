using BCBTL.Models;
using BCBTL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BCBTL.Controllers
{
    public class DonghoNuController : Controller
    {
        // GET: DonghoNu
        private Model1 _context = new Model1();
        public ActionResult DonghoNu()
        {
            var dongHoNu = (from sp in _context.SanPham
                            join dm in _context.DanhMuc on sp.MaDanhMuc equals dm.MaDanhMuc
                            where dm.MaDanhMuc == 2
                            select new DonghoNamViewModel()
                            {
                                TenSanPham = sp.TenSanPham,
                                Gia = sp.Gia,
                                MoTa = sp.MoTa,
                                MaDanhMuc = dm.MaDanhMuc,
                                HinhAnh = sp.HinhAnh
                            }).ToList();

            return View(dongHoNu);
        }
        public ActionResult ChiTietNu(int? maSP)
        {
            var dongHoNu = (from sp in _context.SanPham
                            join dm in _context.DanhMuc on sp.MaDanhMuc equals dm.MaDanhMuc
                            where dm.MaDanhMuc == 2
                            select new DonghoNamViewModel()
                            {
                                TenSanPham = sp.TenSanPham,
                                Gia = sp.Gia,
                                MoTa = sp.MoTa,
                                MaDanhMuc = dm.MaDanhMuc,
                                HinhAnh = sp.HinhAnh
                            }).FirstOrDefault();

            if (dongHoNu == null)
            {
                ViewBag.Message = "Sản phẩm này không tồn tại";
                return RedirectToAction("DonghoNam", "DonghoNam");
            }

            return View(dongHoNu);
        }
    }
}