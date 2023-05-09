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
using Event99.DataAccess.Repository;

namespace Event99.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CityController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CityController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/City
        public async Task<IActionResult> Index()
        {
            List<City> objCityList = await _unitOfWork.City.GetAllAsync();
            return View(objCityList);
        }

        // GET: Admin/City/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _unitOfWork.City == null)
            {
                return NotFound();
            }
            var city = await _unitOfWork.City.GetAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // GET: Admin/City/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/City/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(City city)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.City.AddAsync(city);
                _unitOfWork.Save();
                TempData["Success"] = "City Added Successfully!";
                return RedirectToAction("Index");
            }
            return View(city);
        }

        // GET: Admin/City/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _unitOfWork.City == null)
            {
                return NotFound();
            }
            var city = await _unitOfWork.City.GetAsync(id);
            if (city == null)
            {
                return NotFound();
            }
            return View(city);
        }

        // POST: Admin/City/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] City city)
        {
            if (city == null || _unitOfWork.City == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.City.UpdateAsync(city);
                    _unitOfWork.Save();
                    TempData["Success"] = "City information updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await CityExists(city.Id))
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
            return View(city);
        }

        // GET: Admin/City/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _unitOfWork.City == null)
            {
                return NotFound();
            }

            var cityDelete = await _unitOfWork.City.GetAsync(id);
            if (cityDelete == null)
            {
                return NotFound();
            }

            return View(cityDelete);
        }

        // POST: Admin/City/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_unitOfWork.City == null)
            {
                return Problem("City doesn't exists!");
            }
            var city = await _unitOfWork.City.GetAsync(id);
            if (city != null)
            {
                await _unitOfWork.City.DeleteAsync(id);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CityExists(Guid id)
        {
            return await _unitOfWork.City.Exists(id);
        }
    }
}
