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
    public class MealConfigurationsController : Controller
    {
        private readonly CafeteriaContext _context;

        public MealConfigurationsController(CafeteriaContext context)
        {
            _context = context;
        }

        // GET: MealConfigurations
        public async Task<IActionResult> Index()
        {
            return View(await _context.MealConfigurations.ToListAsync());
        }

        // GET: MealConfigurations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealConfiguration = await _context.MealConfigurations
                .FirstOrDefaultAsync(m => m.MealConfigurationId == id);
            if (mealConfiguration == null)
            {
                return NotFound();
            }

            return View(mealConfiguration);
        }

        // GET: MealConfigurations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MealConfigurations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MealConfigurationId,Ingredients,Price")] MealConfiguration mealConfiguration)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mealConfiguration);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(mealConfiguration);
        }

        // GET: MealConfigurations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealConfiguration = await _context.MealConfigurations.FindAsync(id);
            if (mealConfiguration == null)
            {
                return NotFound();
            }
            return View(mealConfiguration);
        }

        // POST: MealConfigurations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MealConfigurationId,Ingredients,Price")] MealConfiguration mealConfiguration)
        {
            if (id != mealConfiguration.MealConfigurationId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mealConfiguration);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MealConfigurationExists(mealConfiguration.MealConfigurationId))
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
            return View(mealConfiguration);
        }

        // GET: MealConfigurations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mealConfiguration = await _context.MealConfigurations
                .FirstOrDefaultAsync(m => m.MealConfigurationId == id);
            if (mealConfiguration == null)
            {
                return NotFound();
            }

            return View(mealConfiguration);
        }

        // POST: MealConfigurations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mealConfiguration = await _context.MealConfigurations.FindAsync(id);
            _context.MealConfigurations.Remove(mealConfiguration);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MealConfigurationExists(int id)
        {
            return _context.MealConfigurations.Any(e => e.MealConfigurationId == id);
        }
    }
}
