using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;

namespace WebDongHoMVC.Areas.Admin.Controllers
{
    public class DanhMucSanPhamController : Controller
    {
        // GET: Admin/DanhMucSanPham
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            var danhMuc = db.DanhMucs.ToList();
            return View(danhMuc);
        }

        public ActionResult ThemDanhMuc()
        {
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemDanhMuc(DanhMuc danhMuc, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra mã sản phẩm đã tồn tại
                if (db.DanhMucs.Any(dm => dm.MaDanhMuc == danhMuc.MaDanhMuc))
                {
                    ModelState.AddModelError("MaDanhMuc", "Mã danh mục đã tồn tại.");
                    return View(danhMuc);
                }

                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    HinhAnh.SaveAs(path);
                    danhMuc.HinhAnh = "" + fileName; // Thêm dấu "/" ở đầu
                }

                db.DanhMucs.Add(danhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If there's an error, reload the categories list
            return View(danhMuc);
        }

        public ActionResult SuaDanhMuc(int id)
        {
            var danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SuaDanhMuc(DanhMuc danhMuc, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                var dm = db.DanhMucs.Find(danhMuc.MaDanhMuc);
                if (dm == null)
                {
                    return HttpNotFound();
                }
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    HinhAnh.SaveAs(path);
                    danhMuc.HinhAnh = "" + fileName; // Thêm dấu "/" ở đầu
                }
                else
                {
                    danhMuc.HinhAnh = dm.HinhAnh;
                }
                db.Entry(dm).CurrentValues.SetValues(danhMuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(danhMuc);
        }

        public ActionResult XoaDanhMuc(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            if (danhMuc == null)
            {
                return HttpNotFound();
            }
            return View(danhMuc);
        }

        [HttpPost, ActionName("XoaDanhMuc")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DanhMuc danhMuc = db.DanhMucs.Find(id);
            db.DanhMucs.Remove(danhMuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}