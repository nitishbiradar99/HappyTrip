using HappyTrip.Business;
using HappyTrip.Models;
using Rotativa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Rotativa.MVC;

namespace HappyTrip.UI.MVC.Controllers
{
    public class TicketController : Controller
    {
        private ITicketManager ticketMgr = null;
        public TicketController(ITicketManager ticketMgr)
        {
            this.ticketMgr = ticketMgr;
        }
       
        public ActionResult Index()
        {
            List<Ticket> tickets = ticketMgr.AllTickets().ToList<Ticket>();
            return View(tickets);
        }
        /// <summary>
        /// It creates the pdf file fromhtmldata and allow user to download it as pdf format
        /// Added by Ankur Prashant and Praveen Kumar
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult DownloadTicket(int id)
        {
       
            
            var PdfFile = ticketMgr.GetTicket(id);
            ViewData["PDF"] = PdfFile;

          
            return View(PdfFile);

        }
        public ActionResult TicketAsPdf(int id)
        {
            return new ActionAsPdf("DownloadTicket", new { id = id });
        }
        public ActionResult Download(int id)
        {
            return new ActionAsPdf("DownloadTicket", new { id = id }) { FileName = "ticket.pdf" };

        }
    }
}


