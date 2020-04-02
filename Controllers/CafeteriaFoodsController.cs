using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CafeteriaOnline.Website.Data;
using CafeteriaOnline.Website.Models;
using Microsoft.AspNetCore.Authorization;

namespace CafeteriaOnline.Website.Controllers
{
    [Authorize(Roles = "Caterer")]
    public class CafeteriaFoodsController : Controller
    {
        private readonly CafeteriaContext _context;

        public CafeteriaFoodsController(CafeteriaContext context)
        {
            _context = context;
        }

        // GET: CafeteriaFoods
        public async Task<IActionResult> Index()
        {
            var cafeteriaContext = _context.CafeteriaFoods.Include(c => c.CafeteriaAddress);
            return View(await cafeteriaContext.ToListAsync());
        }

        // GET: CafeteriaFoods/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeteriaFood = await _context.CafeteriaFoods
                .Include(c => c.CafeteriaAddress)
                .FirstOrDefaultAsync(m => m.CafeteriaFoodId == id);
            if (cafeteriaFood == null)
            {
                return NotFound();
            }

            return View(cafeteriaFood);
        }

        // GET: CafeteriaFoods/Create
        public IActionResult Create()
        {
            ViewData["CafeteriaAddressId"] = new SelectList(_context.CafeteriaAddresses, "CafeteriaAddressId", "CafeteriaAddressId");
            return View();
        }

        // POST: CafeteriaFoods/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CafeteriaFoodId,Name,MealType,Price,CafeteriaAddressId")] CafeteriaFood cafeteriaFood)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cafeteriaFood);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CafeteriaAddressId"] = new SelectList(_context.CafeteriaAddresses, "CafeteriaAddressId", "CafeteriaAddressId", cafeteriaFood.CafeteriaAddressId);
            return View(cafeteriaFood);
        }

        // GET: CafeteriaFoods/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeteriaFood = await _context.CafeteriaFoods.FindAsync(id);
            if (cafeteriaFood == null)
            {
                return NotFound();
            }
            ViewData["CafeteriaAddressId"] = new SelectList(_context.CafeteriaAddresses, "CafeteriaAddressId", "CafeteriaAddressId", cafeteriaFood.CafeteriaAddressId);
            return View(cafeteriaFood);
        }

        // POST: CafeteriaFoods/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CafeteriaFoodId,Name,MealType,Price,CafeteriaAddressId")] CafeteriaFood cafeteriaFood)
        {
            if (id != cafeteriaFood.CafeteriaFoodId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cafeteriaFood);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CafeteriaFoodExists(cafeteriaFood.CafeteriaFoodId))
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
            ViewData["CafeteriaAddressId"] = new SelectList(_context.CafeteriaAddresses, "CafeteriaAddressId", "CafeteriaAddressId", cafeteriaFood.CafeteriaAddressId);
            return View(cafeteriaFood);
        }

        // GET: CafeteriaFoods/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cafeteriaFood = await _context.CafeteriaFoods
                .Include(c => c.CafeteriaAddress)
                .FirstOrDefaultAsync(m => m.CafeteriaFoodId == id);
            if (cafeteriaFood == null)
            {
                return NotFound();
            }

            return View(cafeteriaFood);
        }

        // POST: CafeteriaFoods/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cafeteriaFood = await _context.CafeteriaFoods.FindAsync(id);
            _context.CafeteriaFoods.Remove(cafeteriaFood);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CafeteriaFoodExists(int id)
        {
            return _context.CafeteriaFoods.Any(e => e.CafeteriaFoodId == id);
        }
    }
}
