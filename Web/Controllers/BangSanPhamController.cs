using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;
using System.Transactions;
using System.Threading.Tasks;

namespace Web.Controllers
{
    [Authorize]
    public class BangSanPhamController : Controller
    {
        private DmQT12Entities db = new DmQT12Entities();
        private object ActionContent;


        // GET: /BangSanPham/
        public ActionResult Index()
        {
            var bangsanphams = db.Products.Include(b => b.ProductType);
            return View(bangsanphams.ToList());
        }

        // GET: /BangSanPham/Details/5
        public FileResult Details(string ID)
        {
            var path = Server.MapPath("~/App_Data/" + ID);
            return File(path, "img");
        }



        // GET: /BangSanPham/Create
        public ActionResult Create()
        {
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ID", "ProductTypeCode" , "ProductTypeName");
            return View();
        }

        // POST: /BangSanPham/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Product model)
        {
            CheckBangSanPham(model);
            if (ModelState.IsValid) {
                using (var scope = new TransactionScope()) {
                    db.Products.Add(model);
                    db.SaveChanges();

                    var path = Server.MapPath("~/App_Data");
                    path = path + "/" + model.ID;
                    if (Request.Files["Avatar"] != null &&
                        Request.Files["Avatar"].ContentLength > 0) {
                            Request.Files["Avatar"].SaveAs(path);

                        scope.Complete(); // approve for transaction
                        return RedirectToAction("Index");
                    }
                    else
                        ModelState.AddModelError("Avatar", "Chưa có hình sản phẩm!");
                }

            }

            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ID", "ProductTypeName", model.ProductTypeID);
            return View(model);
        }
        private void CheckBangSanPham(Product model)
        {
            if (model.OriginPrice < 0)
                ModelState.AddModelError("GiaGoc", "Gia Goc Lon Hon 0");
            if (model.SalePrice < model.OriginPrice)
                ModelState.AddModelError("GiBan", "");
            if (model.InstallmentPrice < model.InstallmentPrice)
                ModelState.AddModelError("GiaGop", "Gia Gop Nho Hon Gia Goc");
        }

        // GET: /BangSanPham/Edit/5
        public ActionResult Edit(int ID)
        {
            Product model = db.Products.Find(ID);
            if (model == null) {
                return HttpNotFound();
            }
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ID", "ProductTypeName", model.ProductTypeID);
            return View(model);
        }

        // POST: /BangSanPham/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model) {
            CheckBangSanPham(model);
            if (ModelState.IsValid) {
                using (var scope = new TransactionScope()) {
                    db.Entry(model).State = EntityState.Modified;
                    db.SaveChanges();

                    var path = Server.MapPath("~/App_Data");
                    path = path + "/" + model.ID;
                    if (Request.Files["Avatar"] != null &&
                        Request.Files["Avatar"].ContentLength > 0) {
                        Request.Files["Avatar"].SaveAs(path);
                    }

                    scope.Complete(); // approve for transaction
                    return RedirectToAction("Index");
                }
            }
            ViewBag.ProductTypeID = new SelectList(db.ProductTypes, "ID", "ProductTypeName", model.ProductTypeID);
            return View(model);
        }
        // GET: /BangSanPham/Delete/5
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(ID);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: /BangSanPham/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ID)
        {
            Product product = db.Products.Find(ID);
            db.Products.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
     

    }
}
