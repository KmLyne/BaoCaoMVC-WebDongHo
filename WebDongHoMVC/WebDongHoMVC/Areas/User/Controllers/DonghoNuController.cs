using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using WebDongHoMVC.ViewModel;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class DonghoNuController : Controller
    {
        // GET: User/DonghoNu
        private Model1 _context = new Model1();
        public ActionResult DonghoNu()
        {
            var dongHoNu = (from sp in _context.SanPhams
                            join dm in _context.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc
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
            var dongHoNu = (from sp in _context.SanPhams
                            join dm in _context.DanhMucs on sp.MaDanhMuc equals dm.MaDanhMuc
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
                return RedirectToAction("DonghoNam", "DongHoNam");
            }

            return View(dongHoNu);
        }
    }
}