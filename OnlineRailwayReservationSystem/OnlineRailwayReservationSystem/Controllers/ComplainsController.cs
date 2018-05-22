using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineRailwayReservationSystem.Models;

namespace OnlineRailwayReservationSystem.Controllers
{
    public class ComplainsController : Controller
    {
        private Online_Railway_Reservation_SystemEntities db = new Online_Railway_Reservation_SystemEntities();

        [Authorize]
        // GET: Complains
        public ActionResult Index()
        {
            var complains = db.Complains.Include(c => c.AdminUser);
            return View(complains.ToList());
        }

        // GET: Complains/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        [Authorize]
        // GET: Complains/Create
        public ActionResult Create()
        {
            ViewBag.UserID = new SelectList(db.AdminUsers, "UserID", "UserCNIC");
            return View();
        }

        [Authorize]
        // POST: Complains/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ComplainID,UserID,ComplainType,ComplainDescription")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Complains.Add(complain);
                db.SaveChanges();
                return RedirectToAction("../Home");
            }

            ViewBag.UserID = new SelectList(db.AdminUsers, "UserID", "UserCNIC", complain.UserID);
            return View(complain);
        }

        // GET: Complains/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserID = new SelectList(db.AdminUsers, "UserID", "UserCNIC", complain.UserID);
            return View(complain);
        }

        // POST: Complains/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ComplainID,UserID,ComplainType,ComplainDescription")] Complain complain)
        {
            if (ModelState.IsValid)
            {
                db.Entry(complain).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserID = new SelectList(db.AdminUsers, "UserID", "UserCNIC", complain.UserID);
            return View(complain);
        }

        // GET: Complains/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Complain complain = db.Complains.Find(id);
            if (complain == null)
            {
                return HttpNotFound();
            }
            return View(complain);
        }

        // POST: Complains/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Complain complain = db.Complains.Find(id);
            db.Complains.Remove(complain);
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
