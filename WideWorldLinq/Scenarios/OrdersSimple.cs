using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WideWorldLinq.Data;

namespace WideWorldLinq.Scenarios
{
    public class OrdersSimple
    {
        private readonly WideWorldImportersContext _context = new WideWorldImportersContext();

        public async Task RunAsync()
        {
            Console.WriteLine( "Waiting to fetch Orders....");
            var RecentOrders = await _context.Orders
                .OrderByDescending(r => r.OrderDate)
                .Take(10)
                .ToListAsync();

            foreach (var order in RecentOrders)
            {
                Console.WriteLine($"Order ID: {order.OrderId}, Customer: {order.CustomerId}, Order Date:  {order.OrderDate}");

            }
            //await
        }
    }
}
