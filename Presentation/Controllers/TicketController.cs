using Bussiness.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;
using System.Collections.Generic;

namespace Presentation.Controllers
{

    public class TicketController : Controller
    {
        private readonly ITicketService _ticketService;
        private readonly IVoyageService _voyageService;
        private readonly IGenericService<Location> _locationService;
        private readonly IGenericService<Bus> _busService;

        public TicketController(ITicketService ticketService, IVoyageService voyageService, IGenericService<Location> locationService, IGenericService<Bus> busService)
        {
            _ticketService = ticketService;
            _voyageService = voyageService;
            _locationService = locationService;
            _busService = busService;
        }


        [Authorize(Roles = "Member")]
        public IActionResult Index(int id)
        {
            var voyage = _voyageService.GetById(id);
            var location = _locationService.GetById(voyage.LocationId);
            var ticketCount = _ticketService.GetCount(id);

            var tickets = _ticketService.GetTicketsByVoyageId(id);

            decimal ticketPrice = (decimal)location.StandartPrice;
    
            if(ticketCount>=5 )
            {
                ticketPrice += ticketPrice * 0.1m;
            }
            if (ticketCount >= 10 )
            {
                ticketPrice += ticketPrice * 0.1m;
            }
            if (ticketCount >= 15)
            {
                ticketPrice += ticketPrice * 0.1m;
            }

            List<TicketListModel> list = new List<TicketListModel>();
            foreach (var item in tickets)
            {
                TicketListModel model = new TicketListModel();
                model.Price = ticketPrice;
                model.Name = item.Name;
                model.Surname = item.Surname;
                model.SeatNumber = item.SeatNumber;
                model.Bus = _busService.GetById(voyage.BusId);
                model.Location = location;
                model.VoyageId = voyage.Id;

                list.Add(model);
            }

            ViewBag.VoyageId = voyage.Id;
            ViewBag.LastPrice = ticketPrice;

           
          
            return View(list);
        }


        [Authorize(Roles = "Member")]

        public IActionResult Buy(int voyageId, decimal price, int seatNumber)
        {
            return View(new BuyTicketModel { 
            Price=price,
            SeatNumber=seatNumber,
            VoyageId=voyageId
            });
        }


        [Authorize(Roles = "Member")]
        [HttpPost]
        public IActionResult Buy(BuyTicketModel model)
        {
            if (ModelState.IsValid)
            {
                _ticketService.Create(new Ticket
                {
                    Name = model.Name,
                    Price = model.Price,
                    SeatNumber = model.SeatNumber,
                    Surname = model.Surname,
                    VoyageId = model.VoyageId
                });
                return View("Thanks");
            }
            return View(model);
        }
    }
}
