using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineRailwayReservationSystem.Models;
using Microsoft.AspNet.Identity;

namespace OnlineRailwayReservationSystem.Controllers
{
    public class HomeController : Controller
    {
        public Online_Railway_Reservation_SystemEntities db = new Online_Railway_Reservation_SystemEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "A")]
        public ActionResult Dashboard()
        {
            ViewBag.Message = "Your contact page.";

            return View("Dashboard", "_DashLayout");
        }

        [Authorize]
        public ActionResult BookTicket()
        {
            ViewBag.CustomerID = new SelectList(db.AdminUsers, "UserID", "UserCNIC");
            ViewBag.CustomerID = new SelectList(db.Passengers, "PassengerID", "PassengerCNIC");
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TicketID,CustomerID,SrcStation,DstStation,Fare,AllocatedSeat,AllocatedBirth,TrainID")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Tickets.Add(ticket);
                return RedirectToAction("../Accounts/Create");
            }

            ViewBag.CustomerID = new SelectList(db.AdminUsers, "UserID", "UserCNIC", ticket.CustomerID);
            ViewBag.CustomerID = new SelectList(db.Passengers, "PassengerID", "PassengerCNIC", ticket.CustomerID);
            ViewBag.TrainID = new SelectList(db.Trains, "TrainID", "TrainName", ticket.TrainID);
            return View(ticket);
        }
        public ActionResult Timing(string searchString)
        {
            ViewBag.user = User.Identity.GetUserName();

            ViewBag.Train = db.Trains.ToList();
            var train = from m in db.Trains
                        select m;
            if (!String.IsNullOrEmpty(searchString))
            {
                train = train.Where(s => s.TrainName.Contains(searchString));
            }
            ViewBag.searchedTrain = train;

            ViewBag.Route = db.Routes.ToList();
            ViewBag.Station = db.Stations.ToList();

            return View();
        }
    }
}