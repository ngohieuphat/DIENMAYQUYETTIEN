using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private DmQT12Entities db = new DmQT12Entities();
        public ActionResult Index()
        {
            var bangsanphams = db.Products;
            return View(bangsanphams.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        // GET: /BangSanPham/Details/5
        public FileResult Details(string ID)
        {
            var path = Server.MapPath("~/App_Data/" + ID);
            return File(path, "img");
        }
        public ActionResult Detail(int ID)
        {
            Product model = db.Products.Find(ID);
            if (model == null)
            {
                return HttpNotFound();
            }
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ID", "ProductTypeName", model.ProductTypeID);
            return View(model);
        }

    }
}