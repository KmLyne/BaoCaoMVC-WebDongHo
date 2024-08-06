using BCBTL.Models;
using BCBTL.ViewModel;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BCBTL.Controllers
{
    public class DonghoNamController : Controller
    {
        // GET: DonghoNam
        private Model1 _context = new Model1();

        public ActionResult DonghoNam()
        {
            var dongHoNam = (from sp in _context.SanPham
                             join dm in _context.DanhMuc on sp.MaDanhMuc equals dm.MaDanhMuc
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
            var dongHoNam = (from sp in _context.SanPham
                             join dm in _context.DanhMuc on sp.MaDanhMuc equals dm.MaDanhMuc
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
                return RedirectToAction("DonghoNam", "DonghoNam");
            }

            return View(dongHoNam);
        }
    }
}
