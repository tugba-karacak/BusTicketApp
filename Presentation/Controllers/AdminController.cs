using Bussiness.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class AdminController : Controller
    {
        private readonly ITicketService _ticketService;

        public AdminController(ITicketService ticketService)
        {
            _ticketService = ticketService;
        }

        [Authorize(Roles ="Admin")]
        public IActionResult Index()
        {
            var tickets = _ticketService.GetAll();
            List<TicketListModel> list = new List<TicketListModel>();
            foreach (var item in tickets)
            {
                TicketListModel model = new TicketListModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Price = item.Price;
                model.SeatNumber = item.SeatNumber;
                model.Surname = item.Surname;
                model.VoyageId = item.VoyageId;

                list.Add(model);
            }
            return View(list);
        }


        [Authorize(Roles = "Admin")]
        public IActionResult CancelTicket(int id)
        {
            var deletedTicket = _ticketService.GetById(id);
            _ticketService.Remove(deletedTicket);
            return RedirectToAction("Index");
        }
    }
}
