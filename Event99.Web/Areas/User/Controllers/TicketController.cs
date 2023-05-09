using Event99.DataAccess.Repository.IRepository;
using Event99.Models.Entities;
using Event99.Models.ViewModels.Ticket;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Security.Claims;


namespace Event99.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Admin, Individual")]

    public class TicketController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        

        public TicketController(IUnitOfWork unitOfWork, UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            List<Ticket> objTicketList = _unitOfWork.Ticket.GetAll(e => e.ApplicationUserId == claim.Value).ToList();

            
            List<TicketViewModel> ticketViewModels = new List<TicketViewModel>();
            foreach (var ticket in objTicketList)
            {
                var eventName = _unitOfWork.Event.GetAll(e => e.Id == ticket.EventId).FirstOrDefault()?.Name;
                ticketViewModels.Add(new TicketViewModel
                {
                    Ticket = ticket,
                    EventName = eventName
                });
                
            }

            return View(ticketViewModels);
        }


    }
}
