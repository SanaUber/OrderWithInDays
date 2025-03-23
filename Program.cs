using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace zajel


{



    public class Order
    {
        public int Id { get; set; }
        public DateTime DeliveryDate { get; set; }
    }
    internal class Program
    {
        public static List<Order> GetRecentOrders(List<Order> orders)
        {
            DateTime sevenDaysAgo = DateTime.Now.AddDays(-7);
            return orders.Where(order => order.DeliveryDate >= sevenDaysAgo).ToList();
        }
        static void Main(string[] args)
        {
            List<Order> orders = new List<Order>
        {
            new Order { Id = 1, DeliveryDate = DateTime.Now.AddDays(-2) }, // Should be included
            new Order { Id = 2, DeliveryDate = DateTime.Now.AddDays(-10) }, // Should be excluded
            new Order { Id = 3, DeliveryDate = DateTime.Now.AddDays(-5) }, // Should be included
        };

            List<Order> recentOrders = GetRecentOrders(orders);


            Console.WriteLine("Recent Orders (Last 7 Days):");
            foreach (var order in recentOrders)
            {
                Console.WriteLine($"Order ID: {order.Id}, Delivery Date: {order.DeliveryDate}");
            }
            Console.ReadLine();
        }
    }
}
