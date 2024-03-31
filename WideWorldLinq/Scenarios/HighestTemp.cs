using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WideWorldLinq.Data;
using WideWorldLinq.Models;

namespace WideWorldLinq.Scenarios
{
    public class HighestTemp
    {
        private readonly WideWorldImportersContext _context = new();
        public async Task RunAsync() 
        {
            Console.WriteLine("Getting the highest Temp");
            var temps = await _context.ColdRoomTemperatures
                .OrderByDescending(c => c.RecordedWhen)
                .Take(10)
                .ToListAsync();

            foreach (var temp in temps)

            {
                Console.WriteLine($"ColdRoomTemperature: {temp.ColdRoomTemperatureId}, Day:{temp.RecordedWhen}, Temp :{temp.Temperature}");
            }

        }
    }
}
