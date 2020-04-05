using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public DateTime ForDate { get; set; }
        public PaidStatus PaidStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
