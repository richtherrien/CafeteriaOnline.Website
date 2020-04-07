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
using CafeteriaOnline.Website.Helpers;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace CafeteriaOnline.Website.Controllers
{
    [Authorize]
    public class ShopController : Controller
    {
        private readonly CafeteriaContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShopController(CafeteriaContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context; 
            _userManager = userManager;
        }

        // GET: Shop
        public async Task<IActionResult> Index()
        {
            DateTime localDate = DateTime.Now;
            var cart = GetCart();
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.MealConfiguration.Price * item.Quantity);
            ViewBag.meals = await _context.Meals.Include(item => item.MealConfigurations).Where(item => item.ValidUntil > localDate).ToListAsync();
            ViewBag.count = cart.Sum(item => item.Quantity);

            return View();
        }

        public async Task<IActionResult> Cart()
        {
            DateTime localDate = DateTime.Now;
            var cart = GetCart();
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.MealConfiguration.Price * item.Quantity);
            ViewBag.meals = await _context.Meals.Include(item => item.MealConfigurations).Where(item => item.ValidUntil > localDate).ToListAsync();
            ViewBag.count = cart.Sum(item => item.Quantity);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cart([Bind("ForDate")] Order order)
        {
            var cart = GetCart();

            DateTime localDate = DateTime.Now.Date;
            if (ModelState.IsValid)
            {
                // make sure it is at least one day ahead
                if (order.ForDate.Date > localDate.Date)
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    if (user != null) {
                        List<OrderItem> orderItems = new List<OrderItem>();
                        cart.ForEach(item =>
                        {
                            OrderItem orderItem = new OrderItem {
                                Quantity = item.Quantity,
                                MealConfigurationId = item.MealConfiguration.MealConfigurationId
                            };
                            orderItems.Add(orderItem);
                        });

                        Order newOrder = new Order
                        {
                            EmployeeId = user.Id,
                            OrderDate = localDate.Date,
                            ModifiedDate = localDate,
                            ForDate = order.ForDate.Date,
                            PaidStatus = PaidStatus.Unpaid,
                            OrderStatus = OrderStatus.Pending,
                            OrderItems = orderItems,
                        };
                        _context.Add(newOrder);
                        await _context.SaveChangesAsync();

                        // clear cart
                        SessionHelper.Set(HttpContext.Session, "cart", new List<OrderItem>());
                        return RedirectToAction("Index");
                    }

                }
                ModelState.AddModelError("ForDate", "Date must be in advance");
            }
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.MealConfiguration.Price * item.Quantity);
            ViewBag.meals = await _context.Meals.Include(item => item.MealConfigurations).Where(item => item.ValidUntil > localDate).ToListAsync();
            ViewBag.count = cart.Sum(item => item.Quantity);
            return View();
        }
        public async Task<IActionResult> Add(int id)
        {
            List<OrderItem> cart = GetCart();

            var mealConfiguration = await _context.MealConfigurations.Include(n => n.Meal).SingleOrDefaultAsync(i => i.MealConfigurationId == id);
            if (mealConfiguration == null)
            {
                return NotFound();
            }
            var index = cart.FindIndex(item => item.MealConfiguration.MealConfigurationId == id);
            Console.WriteLine(mealConfiguration.MealConfigurationId + " " + index);
            cart.ForEach(item =>
            {
                Console.WriteLine("cart item " + item.MealConfiguration.MealConfigurationId);
            });

            if (index == -1)
            {
                cart.Add(new OrderItem { MealConfiguration = mealConfiguration, Quantity = 1 });
            }
            else
            {
                cart[index].Quantity++;
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);

            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> AddItem(int id)
        {
            List<OrderItem> cart = GetCart();
            var meal = await _context.Meals.Include(n => n.MealConfigurations).ThenInclude(m => m.Meal).SingleOrDefaultAsync(i => i.MealId == id);

            if (meal == null)
            {
                return NotFound();
            }
            var mealConfig = meal.MealConfigurations.FirstOrDefault();
            var index = cart.FindIndex(item => item.MealConfiguration.MealConfigurationId == mealConfig.MealConfigurationId);

            Console.WriteLine(mealConfig.MealConfigurationId + " " + index);
            cart.ForEach(item =>
            {
                Console.WriteLine("cart item " + item.MealConfiguration.MealConfigurationId);
            });
            if (index == -1)
            {
                cart.Add(new OrderItem { MealConfiguration = mealConfig, Quantity = 1 });
            }
            else
            {
                cart[index].Quantity++;
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult Remove(int id)
        {
            List<OrderItem> cart = GetCart();

            var index = cart.FindIndex(item => item.MealConfiguration.MealConfigurationId == id);
            if (index != -1)
            {
                if (cart[index].Quantity > 1)
                    cart[index].Quantity--;
                else
                    cart.RemoveAt(index);
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Cart");
        }

        public IActionResult Delete(int id)
        {
            List<OrderItem> cart = GetCart();

            var index = cart.FindIndex(item => item.MealConfiguration.MealConfigurationId == id);
            if (index != -1)
            {
                cart.RemoveAt(index);
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Cart");
        }

        private List<OrderItem> GetCart()
        {
            List<OrderItem> cart = new List<OrderItem>();
            if (SessionHelper.Get<List<OrderItem>>(HttpContext.Session, "cart") != default)
            {
                cart = SessionHelper.Get<List<OrderItem>>(HttpContext.Session, "cart");
            }
            return cart;
        }
    }
}