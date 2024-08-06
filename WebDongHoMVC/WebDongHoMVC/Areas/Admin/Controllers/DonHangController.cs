using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using System.Data.Entity;
using System.Net;
using PagedList;
using System.Web.UI;

namespace WebDongHoMVC.Areas.Admin.Controllers
{
    public class DonHangController : Controller
    {
        // GET: Admin/DonHang
        private Model1 db = new Model1();
        public ActionResult Index(string searchString, int? page)
        {
            //var donHang = db.DonHangs.Include(d => d.KhachHang).ToList();
            //return View(donHang);
            var donHangs = db.DonHangs.Include(d => d.KhachHang).AsQueryable();

            if (!String.IsNullOrEmpty(searchString))
            {
                donHangs = donHangs.Where(d => d.KhachHang.HoTen.Contains(searchString) ||
                                                d.KhachHang.Email.Contains(searchString));
            }

            int pageSize = 10; // Số lượng đơn hàng hiển thị trên mỗi trang
            int pageNumber = (page ?? 1);

            return View(donHangs.OrderBy(d => d.MaDonHang).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThemDonHang()
        {
            return View();
        }
        public ActionResult XemDonHang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Include(d => d.KhachHang)
                .Include(d => d.ChiTietDonHangs.Select(c => c.SanPham))
                .FirstOrDefault(d => d.MaDonHang == id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            ViewBag.TrangThaiList = new SelectList(new List<string> { "Chưa xử lý", "Đang xử lý", "Hoàn thành", "Hủy" }, donHang.TrangThai);
            return View(donHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult XemDonHang(int id, string trangThai)
        {
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            donHang.TrangThai = trangThai;
            db.SaveChanges();
            return RedirectToAction("Index", new {id = id});

        }

        public ActionResult XoaDonHang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang == null)
            {
                return HttpNotFound();
            }
            return View(donHang);
        }

        [HttpPost, ActionName("XoaDonHang")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DonHang donHang = db.DonHangs.Find(id);
            if (donHang != null)
            {
                var ctdonhang = db.ChiTietDonHangs.Where(c => c.MaDonHang == id).ToList();
                foreach (var chiTiet in ctdonhang)
                {
                    db.ChiTietDonHangs.Remove(chiTiet);
                }
                db.DonHangs.Remove(donHang);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }


    }
}