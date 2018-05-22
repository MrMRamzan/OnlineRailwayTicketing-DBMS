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
    public class TicketsController : Controller
    {
        private Online_Railway_Reservation_SystemEntities db = new Online_Railway_Reservation_SystemEntities();

        // GET: Tickets
        public ActionResult Index()
        {
            var tickets = db.Tickets.Include(t => t.AdminUser).Include(t => t.Passenger).Include(t => t.Train);
            return View(tickets.ToList());
        }

        // GET: Tickets/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            ViewBag.CustomerID = new SelectList(db.AdminUsers, "UserID", "UserCNIC");
            ViewBag.CustomerID = new SelectList(db.Passengers, "PassengerID", "PassengerCNIC");
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName");
            return View();
        }

        // POST: Tickets/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,CustomerID,SrcStation,DstStation,Fare,AllocatedSeat,AllocatedBirth,TrainID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerID = new SelectList(db.AdminUsers, "UserID", "UserCNIC", ticket.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Passengers, "PassengerID", "PassengerCNIC", ticket.CustomerID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", ticket.TrainID);
            return View(ticket);
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerID = new SelectList(db.AdminUsers, "UserID", "UserCNIC", ticket.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Passengers, "PassengerID", "PassengerCNIC", ticket.CustomerID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", ticket.TrainID);
            return View(ticket);
        }

        // POST: Tickets/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TicketID,CustomerID,SrcStation,DstStation,Fare,AllocatedSeat,AllocatedBirth,TrainID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerID = new SelectList(db.AdminUsers, "UserID", "UserCNIC", ticket.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Passengers, "PassengerID", "PassengerCNIC", ticket.CustomerID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", ticket.TrainID);
            return View(ticket);
        }

        // GET: Tickets/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = db.Tickets.Find(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

        // POST: Tickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ticket ticket = db.Tickets.Find(id);
            db.Tickets.Remove(ticket);
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
