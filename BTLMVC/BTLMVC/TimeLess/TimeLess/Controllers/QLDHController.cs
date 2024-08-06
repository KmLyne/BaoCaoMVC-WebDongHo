using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using TimeLess.Models;
using TimeLess.ViewModel;

namespace TimeLess.Controllers
{
    public class QLDHController : Controller
    {
        // GET: QLDH
        private DataTimeLess _content = new DataTimeLess();
        public ActionResult Index(int? page)
        {
            //số sp trên trang
            int pageSize = 8;
            // số trang
            int pageNumber = (page ?? 1);
            var lstDH = (from dongho in _content.SanPham
                            
                            orderby dongho.GiaBan descending
                            select dongho
                           ).ToPagedList(pageNumber,pageSize);

            int sluong = lstDH.Count;
            ViewBag.soluong = sluong;
            return View(lstDH);
            
        }
        public ActionResult PartalThuongHieu()
        {
            var lstTH = _content.ThuongHieu.Take(10).ToList();
            return PartialView(lstTH);

        }
        public ActionResult GetThuongHieu(int maTH)
        {
            var lstBooks = _content.SanPham.Where(x => x.MaThuongHieu == maTH).OrderByDescending(propa => propa.GiaBan).ToList();
            ViewBag.soluong = lstBooks.Count();
            return View();
        }
        public ActionResult ChiTiet(int maDH)
        {
            var book = (from dh in _content.SanPham
                        join th in _content.ThuongHieu on dh.MaThuongHieu equals th.MaThuongHieu
                        
                        where dh.MaThuongHieu == maDH
                        select new SPViewModel()
                        {
                            TenSP = dh.TenSP,
                            GiaBan = dh.GiaBan,
                            MoTa = dh.MoTa,
                            SoLuong = dh.Soluong,
                            NgayNhap = dh.NgayNhap,
                            Anh = dh.Anh,
                            ThuongHieu = th.TenThuongHieu,
                           
                        }).FirstOrDefault();

  
            if (book == null)
            {
                ViewBag.message = "Sán phẩm đã tồn tại";
                return RedirectToAction("Index", "QLDH");
            }
            return View();
        }
    }
}