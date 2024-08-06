using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Management;
using System.Web.Mvc;
using WebDongHoMVC.Models;

namespace WebDongHoMVC.Areas.Admin.Controllers
{
    public class TinTucController : Controller
    {
        // GET: Admin/TinTuc
        private Model1 db = new Model1();
        public ActionResult Index()
        {
            var tintuc = db.TinTucs.ToList();
            return View(tintuc);
        }

        public ActionResult ThemTinTuc()
        {
            var tintuc = new TinTuc()
            {
                NgayDangKy = DateTime.Now,
            };

            return View(tintuc);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ThemTinTuc([Bind(Include = "TieuDe,NoiDung,TacGia,NgayDangKy")] TinTuc tintuc, HttpPostedFileBase HinhAnh)
        {
            if(ModelState.IsValid)
            {
                if(tintuc == null)
                {
                    return View(tintuc);
                }
                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    HinhAnh.SaveAs(path);
                    tintuc.HinhAnh = "" + fileName; // Thêm dấu "/" ở đầu
                }
                db.TinTucs.Add(tintuc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tintuc);
        }
        public ActionResult SuaTinTuc(int id)
        {
            var tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ValidateInput(false)]
        public ActionResult SuaTinTuc(TinTuc tintuc, HttpPostedFileBase HinhAnh)
        {
            if (ModelState.IsValid)
            {
                var tt = db.TinTucs.Find(tintuc.MaTinTuc);
                if (tt == null)
                {
                    return HttpNotFound();
                }

                if (HinhAnh != null && HinhAnh.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(HinhAnh.FileName);
                    var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);
                    HinhAnh.SaveAs(path);
                    tintuc.HinhAnh = "" + fileName; // Đặt tên tệp hình ảnh
                }
                else
                {
                    tintuc.HinhAnh = tt.HinhAnh; // Giữ tên cũ nếu không có hình ảnh mới
                }

                // Cập nhật các giá trị khác
                db.Entry(tt).CurrentValues.SetValues(tintuc);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(tintuc);
        }

        public ActionResult XoaTinTuc(int? id)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest); 
            }
            TinTuc tintuc = db.TinTucs.Find(id);
            if (tintuc == null)
            {
                return HttpNotFound();
            }
            return View(tintuc);
        }
        [HttpPost, ActionName("XoaTinTuc")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfimed(int id)
        {
            TinTuc tinTuc = db.TinTucs.Find(id);
            db.TinTucs.Remove(tinTuc);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //public ActionResult SuaTinTuc(int id)
        //{
        //    var tintuc = db.TinTucs.Find(id);
        //    if(tintuc == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tintuc);
        //}
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //[ValidateInput(false)]
        //public ActionResult SuaTinTuc([Bind(Include = "MaTinTuc,TieuDe,NoiDung,TacGia,NgayDangKy")] TinTuc tintuc, HttpPostedFileBase HinhAnh)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var tt = db.TinTucs.Find(tintuc.MaTinTuc);
        //        if (tt == null)
        //        {
        //            return HttpNotFound();
        //        }

        //        // Xử lý file hình ảnh
        //        if (HinhAnh != null && HinhAnh.ContentLength > 0)
        //        {
        //            var fileName = Path.GetFileName(HinhAnh.FileName);
        //            var path = Path.Combine(Server.MapPath("~/HinhAnh"), fileName);

        //            // Xóa hình ảnh cũ nếu cần thiết (nếu bạn muốn giữ thư mục sạch sẽ)
        //            var oldFilePath = Path.Combine(Server.MapPath("~/HinhAnh"), tt.HinhAnh);
        //            if (System.IO.File.Exists(oldFilePath))
        //            {
        //                System.IO.File.Delete(oldFilePath);
        //            }

        //            HinhAnh.SaveAs(path);
        //            tintuc.HinhAnh = fileName; // Lưu tên file mới
        //        }
        //        else
        //        {
        //            tintuc.HinhAnh = tt.HinhAnh; // Giữ nguyên hình ảnh cũ nếu không có ảnh mới
        //        }

        //        // Cập nhật dữ liệu
        //        db.Entry(tt).CurrentValues.SetValues(tintuc);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }
        //    return View(tintuc);
        //}

    }
}