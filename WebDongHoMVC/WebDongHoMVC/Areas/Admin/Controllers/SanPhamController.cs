using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;
using PagedList;
using System.Data.SqlClient;


namespace WebDongHoMVC.Areas.Admin.Controllers
{
    public class SanPhamController : Controller
    {
        // GET: Admin/SanPham
        private Model1 db = new Model1();
        public ActionResult Index(string searchString ,int? page, string sapxep)
        {
            ViewBag.CurrentFilter = searchString;
            ViewBag.CurrentSort = sapxep;

            var sanPhams = from s in db.SanPhams
                           select s;
            //tìm kiếm
            if (!String.IsNullOrEmpty(searchString))
            {
                sanPhams = sanPhams.Where(s => s.TenSanPham.Contains(searchString));
            }
            //sắp xếp
            switch (sapxep)
            {
                case "gia_giam":
                    sanPhams = sanPhams.OrderByDescending(s => s.Gia);
                    break;
                case "gia_tang":
                    sanPhams = sanPhams.OrderBy(s => s.Gia);
                    break;
                case "ten_giam":
                    sanPhams = sanPhams.OrderByDescending(s => s.TenSanPham);
                    break;
                default:
                    sanPhams = sanPhams.OrderBy(s => s.TenSanPham);
                    break;
            }


            int pageSize = 10;
            int pageNumber = (page ?? 1);
            return View(sanPhams.OrderBy(s => s.MaSanPham).ToPagedList(pageNumber, pageSize));
        }
        public ActionResult ThemSanPham()
        {
            var danhMuc = db.DanhMucs.ToList();
            ViewBag.MaDanhMuc = new SelectList(danhMuc, "MaDanhMuc", "TenDanhMuc");
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult ThemSanPham(SanPham sanPham, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                // Kiểm tra mã sản phẩm đã tồn tại
                if (db.SanPhams.Any(sp => sp.MaSanPham == sanPham.MaSanPham))
                {
                    ViewBag.dmuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
                    return View(sanPham);
                }

                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    HinhAnh.SaveAs(path);
                    sanPham.HinhAnh = "" + fileName; // Thêm dấu "/" ở đầu
                }

                db.SanPhams.Add(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            // If there's an error, reload the categories list
            ViewBag.dmuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        public ActionResult SuaSanPham(int id)
        {
            var sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            ViewBag.dmuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SuaSanPham(SanPham sanPham, HttpPostedFileBase HinhAnh)
        {
            if(ModelState.IsValid)
            {
                var sp = db.SanPhams.Find(sanPham.MaSanPham);
                if (sp == null)
                {
                    return HttpNotFound();
                }
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    HinhAnh.SaveAs(path);
                    sanPham.HinhAnh = "" + fileName; // Thêm dấu "/" ở đầu
                }
                else
                {
                    sanPham.HinhAnh = sp.HinhAnh;
                }
                db.Entry(sp).CurrentValues.SetValues(sanPham);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.dmuc = new SelectList(db.DanhMucs, "MaDanhMuc", "TenDanhMuc", sanPham.MaDanhMuc);
            return View(sanPham);
        }

        public ActionResult XoaSanPham(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SanPham sanPham = db.SanPhams.Find(id);
            if (sanPham == null)
            {
                return HttpNotFound();
            }
            return View(sanPham);
        }

        [HttpPost, ActionName("XoaSanPham")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id) {
            SanPham sanPham = db.SanPhams.Find(id);
            db.SanPhams.Remove(sanPham);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    } 
}