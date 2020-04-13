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
using Microsoft.AspNetCore.Identity;

namespace CafeteriaOnline.Website.Controllers
{
    [Authorize(Roles = "Employee,Organizer")]
    public class UserOrdersController : Controller
    {
        private readonly CafeteriaContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public UserOrdersController(CafeteriaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: UserOrders
        public async Task<IActionResult> Index()
        {
            Employee employee = (Employee)await _userManager.GetUserAsync(HttpContext.User);
            if (employee.Orders != null) {
                var orders = employee.Orders.ToList();
                return View(orders);
            }
            return View();
        }

        // GET: UserOrders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _context.Orders
                .Include(o => o.Employee)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            var user = await _userManager.GetUserAsync(HttpContext.User);

            if (order == null || order.EmployeeId != user.Id)
            {
                return NotFound();
            }

            return View(order);
        }

        // GET: UserOrders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var order = await _context.Orders.FindAsync(id);
            if (order == null || order.EmployeeId != user.Id)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", order.EmployeeId);
            return View(order);
        }

        // POST: UserOrders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,  Order newOrder)
        {
            DateTime localDate = DateTime.Now.Date;

            if (id != newOrder.OrderId)
            {
                return NotFound();
            }
            else if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ForDate", "Date must be 3 days in advance");
                return View(newOrder);
            }
            else if ((newOrder.ForDate.Date - localDate).TotalDays < 3)
            {
                // make sure it is at least one day ahead
                var prevOrder = await _context.Orders.FindAsync(id);
                ModelState.AddModelError("ForDate", "Date must be 3 days in advance");
                return View(prevOrder);
            }

            Employee user = (Employee)await _userManager.GetUserAsync(HttpContext.User);
            var order = user.Orders.FirstOrDefault(item => item.OrderId == id);
            if (order == null)
            {
                return NotFound();
            }

            for (int i = 0; i < newOrder.OrderItems.Count; i++)
            {
                if (DateTime.Compare(newOrder.OrderItems[i].MealConfiguration.Meal.ValidUntil.Date, order.ForDate.Date) < 0)
                {
                    ModelState.AddModelError("ForDate", "Meal is no longer valid on that date");
                    return View(newOrder);
                }
            }

            for (int i = 0; i < newOrder.OrderItems.Count; i++)
            {
                // if quantity is set to 0 delete
                if (newOrder.OrderItems[i].Quantity <= 0)
                {
                    newOrder.OrderItems.RemoveAt(i);
                    order.OrderItems.RemoveAt(i);

                }
            }

            for (int i = 0; i < newOrder.OrderItems.Count; i++)
            {
                order.OrderItems[i].Quantity = newOrder.OrderItems[i].Quantity;
            }
              
            order.ForDate = newOrder.ForDate;
            order.ModifiedDate = DateTime.Now.Date;
            _context.Update(order);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        // GET: UserOrders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var order = await _context.Orders
                .Include(o => o.Employee)
                .FirstOrDefaultAsync(m => m.OrderId == id);
            // make sure the order belongs to user
            if (order == null || order.EmployeeId != user.Id)
            {
                return NotFound();
            }

            return View(order);
        }

        // POST: UserOrders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var order = await _context.Orders.FindAsync(id);
            // can delete if the 
            if (order.EmployeeId != user.Id)
                return NotFound();
            else if (DateTime.Compare(order.ForDate.Date, DateTime.Now.Date) < 0)
                return RedirectToAction(nameof(Index));
            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrderExists(int id)
        {
            return _context.Orders.Any(e => e.OrderId == id);
        }
    }
}
