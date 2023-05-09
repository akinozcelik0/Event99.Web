using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Event99.DataAccess.Contexts;
using Event99.Models.Entities;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Event99.DataAccess.Repository.IRepository;
using Event99.Models.ViewModels.Event;
using System.Security.Claims;
using System.Net.Sockets;

namespace Event99.Web.Areas.User.Controllers
{
    [Area("User")]
    [Authorize(Roles = "Admin, Individual")]
    public class EventController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public EventController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: User/Event
        public async Task<IActionResult> Index()
        {
            List<Event> objEventList = await _unitOfWork.Event.GetAllAsync();
            return View(objEventList);
        }

        // GET: User/Event/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _unitOfWork.Event == null)
            {
                return NotFound();
            }
            var objEvent = await _unitOfWork.Event.GetAsync(id);
            if (objEvent == null)
            {
                return NotFound();
            }
            return View(objEvent);
        }

        // GET: User/Event/Create
        public IActionResult Create()
        {

            EventViewModel eventViewModel = new()
            {
                Event = new(),
                Location = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CityList = _unitOfWork.City.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })

            };
            return View(eventViewModel);
        }

        // POST: User/Event/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(EventViewModel eventViewModel)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (ModelState.IsValid)
            {
                eventViewModel.Event.ApplicationUserId = claim.Value;
                await _unitOfWork.Location.AddAsync(eventViewModel.Location);
                var location = eventViewModel.Location;
                if (location != null)
                {
                    eventViewModel.Event.LocationId = location.Id;
                }
                await _unitOfWork.Event.AddAsync(eventViewModel.Event);
                _unitOfWork.Save();
                TempData["Success"] = "Event created successfully!";
                return RedirectToAction("Index");
            }
            return View(eventViewModel);
        }

        public async Task<IActionResult> CreateTicket(Guid? id)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);

            if (id == null || _unitOfWork.Event == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                Ticket ticket = new Ticket()
                {
                    ApplicationUserId = claim.Value,
                    EventId = id,
                };
                await _unitOfWork.Ticket.AddAsync(ticket);
                _unitOfWork.Save();
                TempData["Success"] = "Ticket created successfully!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Details");
        }

        // GET: User/Event/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _unitOfWork.Event == null)
            {
                return NotFound();
            }

            EventViewModel eventViewModel = new()
            {
                Event = new(),
                Location = new(),
                CategoryList = _unitOfWork.Category.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                }),
                CityList = _unitOfWork.City.GetAll().Select(i => new SelectListItem
                {
                    Text = i.Name,
                    Value = i.Id.ToString()
                })

            };

            eventViewModel.Event = _unitOfWork.Event.GetFirstOrDefault(i => i.Id == id);

            if (eventViewModel == null)
            {
                return NotFound();
            }

            return View(eventViewModel);
        }

        // POST: User/Event/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, EventViewModel objEvent)
        {
            var claimsIdentity = (ClaimsIdentity)User.Identity;
            var claim = claimsIdentity.FindFirst(ClaimTypes.NameIdentifier);


            if (objEvent == null || _unitOfWork.Event == null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Location.UpdateAsync(objEvent.Location);
                    var location = objEvent.Location;
                    if (location != null)
                    {
                        objEvent.Event.LocationId = location.Id;
                    }
                    await _unitOfWork.Event.UpdateAsync(objEvent.Event);
                    objEvent.Event.ApplicationUserId = claim.Value;
                    _unitOfWork.Save();
                    TempData["Success"] = "Event information updated successfully!";
                    return RedirectToAction("Index");
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await EventExists(objEvent.Event.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            
            return View(objEvent);
        }

        // GET: User/Event/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _unitOfWork.Event == null)
            {
                return NotFound();
            }

            var eventDelete = await _unitOfWork.Event.GetAsync(id);
            if (eventDelete == null)
            {
                return NotFound();
            }

            return View(eventDelete);
        }

        // POST: User/Event/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_unitOfWork.Event == null)
            {
                return Problem("Event doesn't exists!");
            }
            var objEvent = await _unitOfWork.Event.GetAsync(id);
            if (objEvent != null)
            {
                await _unitOfWork.Event.DeleteAsync(id);
            }
            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> EventExists(Guid id)
        {
            return await _unitOfWork.Event.Exists(id);
        }

    }
}
