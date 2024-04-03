using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Markup;
using WideWorldLinq.Data;
using WideWorldLinq.Models;

namespace WideWorldLinq.Scenarios
{
    public class CitiesWithHighestPopulation
    {
        private readonly WideWorldImportersContext _context = new WideWorldImportersContext();
        public async Task RunAsync()
        {
            Console.WriteLine("Query city with the highest temp: ");
            var cities = await _context.Cities
                .OrderByDescending(c => c.LatestRecordedPopulation)
                .Take(50)
                .ToListAsync();

            foreach (var c in cities)
            {
                Console.WriteLine($"Code: {c.CityId}, Name:{c.CityName}, Population:{c.LatestRecordedPopulation}");
            }
        }
    }
}
