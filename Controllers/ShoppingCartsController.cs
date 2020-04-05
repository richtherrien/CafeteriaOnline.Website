using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CafeteriaOnline.Website.Data;
using CafeteriaOnline.Website.Helpers;
using CafeteriaOnline.Website.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CafeteriaOnline.Website.Controllers
{
    public class ShoppingCartsController : Controller
    {
        private readonly CafeteriaContext _context;

        public ShoppingCartsController(CafeteriaContext context)
        {
            _context = context;
        }

        // GET: ShoppingCart
        public IActionResult Index()
        {
            var cart = SessionHelper.Get<List<OrderItem>>(HttpContext.Session, "cart");
            if (cart == default)
            {
                cart = new List<OrderItem>();
                // For testing
                OrderItem orderItem = _context.OrderItems.Include(m => m.MealConfiguration).ThenInclude(n => n.Meal).FirstOrDefault();
                cart.Add(orderItem);
                SessionHelper.Set(HttpContext.Session, "cart", cart);
            }

            ViewBag.cart = cart;
            ViewBag.total = cart.Sum(item => item.MealConfiguration.Price * item.Quantity);
            return View();
        }

        public async Task<IActionResult> AddItem(int id)
        {
            List<OrderItem> cart = GetCart();

            var mealConfiguration = await _context.MealConfigurations.FindAsync(id);
            if (mealConfiguration == null)
            {
                return NotFound();
            }
            var index = cart.FindIndex(item => item.MealConfigurationId == id);

            if (index == -1)
            {
                cart.Add(new OrderItem { MealConfiguration = mealConfiguration, Quantity = 1 });
            }
            else {
                cart[index].Quantity++;
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);

            return RedirectToAction("Index");
        }

        public IActionResult RemoveItem(int id)
        {
            List<OrderItem> cart = GetCart();

            var index = cart.FindIndex(item => item.MealConfigurationId == id);
            if (index != -1)
            {
                if(cart[index].Quantity > 1)
                    cart[index].Quantity--;
                else
                    cart.RemoveAt(index);
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteItem(int id)
        {
            List<OrderItem> cart = GetCart();

            var index = cart.FindIndex(item => item.MealConfigurationId == id);
            if (index != -1)
            {
                cart.RemoveAt(index);
            }
            SessionHelper.Set(HttpContext.Session, "cart", cart);
            return RedirectToAction("Index");
        }

        private List<OrderItem> GetCart() {
            List<OrderItem> cart = new List<OrderItem>();
            if (SessionHelper.Get<List<OrderItem>>(HttpContext.Session, "cart") != default)
            {
                cart = SessionHelper.Get<List<OrderItem>>(HttpContext.Session, "cart");
            }
            return cart;
        }
    }
}