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
using Event99.DataAccess.Repository.IRepository;
using Event99.DataAccess.Repository;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;

namespace Event99.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Category
        public async Task<IActionResult> Index()
        {
            List<Category> objCategoryList = await _unitOfWork.Category.GetAllAsync();
            return View(objCategoryList);
        }

        // GET: Admin/Category/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _unitOfWork.Category == null)
            {
                return NotFound();
            }
            var category = await _unitOfWork.Category.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: Admin/Category/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Category/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                await _unitOfWork.Category.AddAsync(category);
                _unitOfWork.Save();
                TempData["Success"] = "Category Added Successfully!";
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Admin/Category/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _unitOfWork.Category == null)
            {
                return NotFound();
            }
            var category = await _unitOfWork.Category.GetAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Admin/Category/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Name,Id")] Category category)
        {
            if (category == null || _unitOfWork.Category == null)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    await _unitOfWork.Category.UpdateAsync(category);
                    _unitOfWork.Save();
                    TempData["Success"] = "Category information updated successfully!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await CategoryExists(category.Id))
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
            return View(category);
        }

        // GET: Admin/Category/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _unitOfWork.Category == null)
            {
                return NotFound();
            }

            var categoryDelete = await _unitOfWork.Category.GetAsync(id);
            if (categoryDelete == null)
            {
                return NotFound();
            }

            return View(categoryDelete);
        }

        // POST: Admin/Category/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_unitOfWork.Category == null)
            {
                return Problem("Category does't exists!");
            }
            var company = await _unitOfWork.Category.GetAsync(id);
            if (company != null)
            {
                await _unitOfWork.Category.DeleteAsync(id);
            }

            _unitOfWork.Save();
            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> CategoryExists(Guid id)
        {
            return await _unitOfWork.Category.Exists(id);
        }


    }
}
