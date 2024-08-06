using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDongHoMVC.Models;

namespace WebDongHoMVC.Areas.User.Controllers
{
    public class TinTucUserController : Controller
    {
        // GET: User/TinTucUser
        private Model1 _context = new Model1();
        public ActionResult TinTuc()
        {
            var tinTucs = _context.TinTucs.ToList();
            if (tinTucs == null || !tinTucs.Any())
            {
                // Log or add a breakpoint here to check the data
                System.Diagnostics.Debug.WriteLine("No data found.");
            }
            return View(tinTucs);
        }
    }
}