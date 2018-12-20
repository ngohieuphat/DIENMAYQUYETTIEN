using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web.Models;

namespace Web.Controllers
{
    public class InstallmentBillDetailsController : Controller
    {
        private DmQT12Entities db = new DmQT12Entities();

        // GET: InstallmentBillDetails
        public ActionResult Index()
        {
            var installmentBillDetails = db.InstallmentBillDetails.Include(i => i.InstallmentBill).Include(i => i.Product);
            return View(installmentBillDetails.ToList());
        }

        // GET: InstallmentBillDetails/Details/5
        public ActionResult Details(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstallmentBillDetail installmentBillDetail = db.InstallmentBillDetails.Find(ID);
            if (installmentBillDetail == null)
            {
                return HttpNotFound();
            }
            return View(installmentBillDetail);
        }

        // GET: InstallmentBillDetails/Create
        public ActionResult Create()
        {
            ViewBag.BillID = new SelectList(db.InstallmentBills, "ID", "BillCode");
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode");
            return View();
        }

        // POST: InstallmentBillDetails/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,BillID,ProductID,Quantity,InstallmentPrice")] InstallmentBillDetail installmentBillDetail)
        {
            if (ModelState.IsValid)
            {
                db.InstallmentBillDetails.Add(installmentBillDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BillID = new SelectList(db.InstallmentBills, "ID", "BillCode", installmentBillDetail.BillID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode", installmentBillDetail.ProductID);
            return View(installmentBillDetail);
        }

        // GET: InstallmentBillDetails/Edit/5
        public ActionResult Edit(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstallmentBillDetail installmentBillDetail = db.InstallmentBillDetails.Find(ID);
            if (installmentBillDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.BillID = new SelectList(db.InstallmentBills, "ID", "BillCode", installmentBillDetail.BillID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode", installmentBillDetail.ProductID);
            return View(installmentBillDetail);
        }

        // POST: InstallmentBillDetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,BillID,ProductID,Quantity,InstallmentPrice")] InstallmentBillDetail installmentBillDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(installmentBillDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BillID = new SelectList(db.InstallmentBills, "ID", "BillCode", installmentBillDetail.BillID);
            ViewBag.ProductID = new SelectList(db.Products, "ID", "ProductCode", installmentBillDetail.ProductID);
            return View(installmentBillDetail);
        }

        // GET: InstallmentBillDetails/Delete/5
        public ActionResult Delete(int? ID)
        {
            if (ID == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            InstallmentBillDetail installmentBillDetail = db.InstallmentBillDetails.Find(ID);
            if (installmentBillDetail == null)
            {
                return HttpNotFound();
            }
            return View(installmentBillDetail);
        }

        // POST: InstallmentBillDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int ID)
        {
            InstallmentBillDetail installmentBillDetail = db.InstallmentBillDetails.Find(ID);
            db.InstallmentBillDetails.Remove(installmentBillDetail);
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
