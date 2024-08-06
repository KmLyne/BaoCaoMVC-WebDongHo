using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using PagedList;
using System.Net;

namespace WebDongHoMVC.Areas.Admin.Controllers
{
    public class KhachHangController : Controller
    {
        // GET: Admin/KhachHang
        private Model1 db = new Model1();
        public ActionResult Index(string timkiem, int? page)
        {
            var khachHang = from k in db.KhachHangs
                            select k;
            //tìm kiếm
            if(!String.IsNullOrEmpty(timkiem))
            {
                khachHang = khachHang.Where(k => k.HoTen.Contains(timkiem) ||
                    k.Email.Contains(timkiem));
            }
            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(khachHang.OrderBy(k => k.MaKhachHang).ToPagedList(pageNumber, pageSize));
        }

        public ActionResult ThemKhachHang()
        {
            var khachHang = new KhachHang { 
                NgayDangKy = DateTime.Now,
            };
            return View(khachHang);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemKhachHang([Bind(Include ="HoTen, Email, MatKhau, DiaChi, SoDienThoai, NgayDangKy")] KhachHang khachHang)
        {
            if(ModelState.IsValid)
            {
                db.KhachHangs.Add(khachHang);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(khachHang);
        }

        public ActionResult SuaKhachHang(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            KhachHang khachHang = db.KhachHangs.Find(id);

            if (khachHang == null)
            {
                return HttpNotFound();
            }

            return View(khachHang);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SuaKhachHang([Bind(Include = "MaKhachHang,HoTen,Email,MatKhau,DiaChi,SoDienThoai,NgayDangKy")] KhachHang khachHang)
        {
            if (ModelState.IsValid)
            {
                db.Entry(khachHang).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(khachHang);
        }

        public ActionResult XoaKhachHang(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KhachHang khachHang = db.KhachHangs.Find(id);
            if (khachHang == null)
            {
                return HttpNotFound();
            }
            return View(khachHang);
        }

        [HttpPost, ActionName("XoaKhachHang")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KhachHang khachHang = db.KhachHangs.Find(id);
            db.KhachHangs.Remove(khachHang);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}