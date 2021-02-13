using Bussiness.Interfaces;
using Entities.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    public class VoyageController : Controller
    {
       private readonly  IVoyageService _voyageService;
        private readonly IGenericService<Location> _locationService;
        private readonly IGenericService<Bus> _busService;
        private readonly ITicketService _ticketService;
        public VoyageController(IVoyageService voyageService, IGenericService<Location> locationService, IGenericService<Bus> busService, ITicketService ticketService)
        {
            _voyageService = voyageService;
            _locationService = locationService;
            _busService = busService;
            _ticketService = ticketService;
        }

        [Authorize(Roles ="Member")]

        public IActionResult Index()
        {
            var locations = _locationService.GetAll();

            List<LocationListModel> locationList = new List<LocationListModel>();
            foreach (var item in locations)
            {
                locationList.Add(new LocationListModel
                {
                    Id = item.Id,
                    Name = item.Source + " - " + item.Target
                });
            }

           ViewBag.LocationList =  new SelectList(locationList,"Id","Name");

            return View();
        }


        public IActionResult GetVoyages(DateTime time, int LocationId)
        {
            var voyages = _voyageService.GetVoyages(time, LocationId);
            if (voyages?.Count > 0)
            {
                foreach (var item in voyages)
                {
                    var bus = _busService.GetById(item.BusId);
                    item.Bus = bus;
                    var location= _locationService.GetById(item.LocationId);
                    item.Location = location;
                    item.FreeSeatCount = _ticketService.GetCount(item.Id);
                }
            }
            return Json(voyages);
        }
    }
}
