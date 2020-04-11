using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CafeteriaOnline.Website.Models
{
    public enum PaidStatus
    {
        Unpaid, Cash, Credit, Account
    }

    public enum OrderStatus
    {
        Pending, Complete, Cancelled
    }
    public class Order
    {
        public int OrderId { get; set; }
        public string EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        [Required]
        public DateTime ForDate { get; set; }
        public PaidStatus PaidStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public virtual ICollection<OrderItem> OrderItems { get; set; }

        public decimal GetTotalPrice()
        {
            return OrderItems.Sum(item => item.MealConfiguration.Price * item.Quantity);
        }
    }
}
