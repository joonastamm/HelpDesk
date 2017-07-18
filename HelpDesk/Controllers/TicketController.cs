using HelpDesk.Models;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace HelpDesk.Controllers
{
    public class TicketController : Controller
    {
        public ActionResult Index()
        {
            return View(Tickets.Where(x => !x.isSolved()).ToList());
        }

        public ActionResult All(int? page)
        {
            ViewData["totalTicketCount"] = Tickets.Count();
            return View(Tickets.ToPagedList(page ?? 1, 10));
        }

        public static readonly List<Ticket> Tickets = new List<Ticket>();

        [HttpPost]
        public ActionResult Add(string description, DateTime? duedate)
        {
            var ticketItem = new Ticket(description, duedate);
            Tickets.Add(ticketItem);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult MarkSolved(string id)
        {

            var ticketItem = Tickets.Single(x => x.getId() == id);
            ticketItem.markSolved();
            return RedirectToAction("Index");

        }

        //RANDOM DATA GENERATION

        [HttpPost]
        public ActionResult GenerateData(int count)
        {

            for(int i=0; i<count; i++)
            {
                var description = RandomString(50);
                var duedate = RandomDate();
                var ticketItem = new Ticket(description, duedate);
                Tickets.Add(ticketItem);
            }
            return RedirectToAction("Index");

        }

        static readonly Random random = new Random();

        private string RandomString(int size)
        {
            StringBuilder builder = new StringBuilder();            
            char ch;
            for (int j = 0; j < size; j++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            return builder.ToString();
        }

        private static DateTime RandomDate()
        {
            DateTime fromDate = DateTime.Now.AddDays(-10);
            var range = DateTime.Now.AddDays(100) - fromDate;
            var randTimeSpan = new TimeSpan((long)(random.NextDouble() * range.Ticks));
            return fromDate + randTimeSpan;
        }



    }

}