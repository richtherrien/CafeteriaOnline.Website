using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CafeteriaOnline.Website.Data;
using CafeteriaOnline.Website.Models;
using Microsoft.AspNetCore.Authorization;
using CafeteriaOnline.Website.Helpers;
using Microsoft.AspNetCore.Identity;

namespace CafeteriaOnline.Website.Controllers
{
    [Authorize(Roles = "Employee,Organizer")]
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
        public async Task<IActionResult> Index([Bind("ForDate")] Order order)
        {
            DateTime localDate = DateTime.Now.Date;
            if (order.ForDate != null)
            {
                localDate = order.ForDate.Date;
            }
            var cart = GetCart();
            ViewBag.cart = cart;
            ViewBag.meals = await _context.Meals.Include(item => item.MealConfigurations).Where(item => item.ValidUntil > localDate).ToListAsync();
            ViewBag.count = cart.Sum(item => item.Quantity);
            return View();
        }

        public IActionResult Cart()
        {
            var cart = GetCart();
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.MealConfiguration.Price * item.Quantity);
            return View();
        }

        public IActionResult OrderThankYou()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Cart([Bind("ForDate")] Order order)
        {
            var cart = GetCart();
            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.MealConfiguration.Price * item.Quantity);
            DateTime localDate = DateTime.Now.Date;
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("ForDate", "Please enter a date");
                return View();
            }
            else if ((order.ForDate.Date - localDate).TotalDays < 3)
            {
                // make sure it is at least one day ahead
                ModelState.AddModelError("ForDate", "Date must be 3 days in advance");
                return View();
            }
            else if (cart.ToList().Count < 1)
            {
                ModelState.AddModelError("ForDate", "Please add Items to your cart");
                return View();
            }

            var user = await _userManager.GetUserAsync(HttpContext.User);
            if (user != null)
            {
                List<OrderItem> orderItems = new List<OrderItem>();
                for (int i = 0; i < cart.ToList().Count; i++)
                {
                    // make sure the item will still be valid on the date it is ordered
                    if (DateTime.Compare(cart[i].MealConfiguration.Meal.ValidUntil.Date, order.ForDate.Date) < 0)
                    {
                        ModelState.AddModelError("ForDate", "Cart items must be valid on the ForDate " + cart[i].MealConfiguration.Meal.Name.ToString());
                        return View();
                    }
                    OrderItem orderItem = new OrderItem
                    {
                        Quantity = cart[i].Quantity,
                        MealConfigurationId = cart[i].MealConfiguration.MealConfigurationId
                    };
                    orderItems.Add(orderItem);
                }

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
            }
            return RedirectToAction("OrderThankYou");
        }

        public async Task<IActionResult> Add(int id)
        {
            var result = await AddItemToCart(id);
            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("Cart");
        }

        public async Task<IActionResult> AddItem(int id)
        {
            var result = await AddItemToCart(id);

            if (!result)
            {
                return NotFound();
            }

            return RedirectToAction("Index");
        }

        public async Task<bool> AddItemToCart(int id)
        {

            List<OrderItem> cart = GetCart();

            var mealConfiguration = await _context.MealConfigurations.Include(n => n.Meal).SingleOrDefaultAsync(i => i.MealConfigurationId == id);
            if (mealConfiguration == null)
            {
                return false;
            }
            var index = cart.FindIndex(item => item.MealConfiguration.MealConfigurationId == id);

            if (index == -1)
            {
                cart.Add(new OrderItem { MealConfiguration = mealConfiguration, Quantity = 1 });
            }
            else
            {
                if (cart[index].Quantity < 25)
                    cart[index].Quantity++;
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);

            return true;
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
