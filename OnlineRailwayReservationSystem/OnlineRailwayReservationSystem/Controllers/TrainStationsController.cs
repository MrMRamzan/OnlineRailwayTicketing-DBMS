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
    public class TrainStationsController : Controller
    {
        private Online_Railway_Reservation_SystemEntities db = new Online_Railway_Reservation_SystemEntities();

        [Authorize(Roles = "A")]
        // GET: TrainStations
        public ActionResult Index()
        {
            var trainStations = db.TrainStations.Include(t => t.Station).Include(t => t.Train);
            return View(trainStations.ToList());
        }

        // GET: TrainStations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainStation trainStation = db.TrainStations.Find(id);
            if (trainStation == null)
            {
                return HttpNotFound();
            }
            return View(trainStation);
        }

        // GET: TrainStations/Create
        public ActionResult Create()
        {
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName");
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName");
            return View();
        }

        // POST: TrainStations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TrainID,StationID")] TrainStation trainStation)
        {
            if (ModelState.IsValid)
            {
                db.TrainStations.Add(trainStation);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", trainStation.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", trainStation.TrainID);
            return View(trainStation);
        }

        // GET: TrainStations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainStation trainStation = db.TrainStations.Find(id);
            if (trainStation == null)
            {
                return HttpNotFound();
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", trainStation.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", trainStation.TrainID);
            return View(trainStation);
        }

        // POST: TrainStations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TrainID,StationID")] TrainStation trainStation)
        {
            if (ModelState.IsValid)
            {
                db.Entry(trainStation).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.StationID = new SelectList(db.Stations, "StationID", "StationName", trainStation.StationID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", trainStation.TrainID);
            return View(trainStation);
        }

        // GET: TrainStations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TrainStation trainStation = db.TrainStations.Find(id);
            if (trainStation == null)
            {
                return HttpNotFound();
            }
            return View(trainStation);
        }

        // POST: TrainStations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TrainStation trainStation = db.TrainStations.Find(id);
            db.TrainStations.Remove(trainStation);
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
