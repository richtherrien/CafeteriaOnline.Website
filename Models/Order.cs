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
        public int OrderID { get; set; }
        public int EmployeeID { get; set; }
        public Employee Employee { get; set; }
        public int MealConfigurationID { get; set; }
        public MealConfiguration MealConfiguration { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public DateTime ForDate { get; set; }
        public int Quantity { get; set; }
        public PaidStatus PaidStatus { get; set; }
        public OrderStatus OrderStatus { get; set; }
    }
}
