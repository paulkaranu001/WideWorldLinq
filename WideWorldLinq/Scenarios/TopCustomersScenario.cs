using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WideWorldLinq.Data;

namespace WideWorldLinq.Scenarios
{
    public class TopCustomersScenario
    {
        private readonly WideWorldImportersContext _dbContext = new();

        public async Task RunAsync()
        {
            Console.WriteLine("Executing Top Customers Scenario...");

            // Start stopwatch
            Stopwatch stopwatch = Stopwatch.StartNew();

            // Query database asynchronously to get top 10 customers with highest order totals
            var topCustomers = await _dbContext.Invoices
                .GroupBy(i => i.CustomerId)
                .Select(g => new
                {
                    Customerid = g.Key,
                    TotalOrderAmount = g.Sum(i => i.TotalChillerItems + i.TotalDryItems)
                })
                .OrderByDescending(c => c.TotalOrderAmount)
                .Take(10)
                .ToListAsync();

            // Stop stopwatch
            stopwatch.Stop();

            // Get customer names
            var customerIds = topCustomers.Select(c => c.Customerid).ToList();
            var customers = await _dbContext.Customers
                .Where(c => customerIds.Contains(c.CustomerId))
                .ToDictionaryAsync(c => c.CustomerId);

            // Print results
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("Top 10 Customers with Highest Order Totals:");
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine("{0,-20} {1,-15}", "Customer Name", "Total Order Amount");
            Console.WriteLine("--------------------------------------------------------");
            foreach (var customer in topCustomers)
            {
                if (customers.TryGetValue(customer.Customerid, out var customerInfo))
                {
                    Console.WriteLine("{0,-20} {1,-15:C2}", customerInfo.CustomerName, customer.TotalOrderAmount);
                }
            }
            Console.WriteLine("--------------------------------------------------------");

            // Print execution time
            Console.WriteLine($"Execution Time: {stopwatch.Elapsed.TotalSeconds} seconds");
        }
    }
}
