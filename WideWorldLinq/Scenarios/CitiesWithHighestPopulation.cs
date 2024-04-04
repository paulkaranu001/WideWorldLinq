namespace WideWorldLinq.Scenarios
{
    public class CitiesWithHighestPopulation
    {
        private readonly WideWorldImportersContext _context = new WideWorldImportersContext();
        public async Task RunAsync()
        {
            Console.WriteLine("Query city with the highest Population: ");
            var cities = await _context.Cities
                .OrderByDescending(c => c.LatestRecordedPopulation)
                .Take(50)
                .ToListAsync();

            // Create a table
            var table = new ConsoleTable("Code", "Name", "Population");

            foreach (var c in cities)
            {
                // Add row to the table
                table.AddRow(c.CityId, c.CityName, c.LatestRecordedPopulation);
            }

            // Print the table
            table.Write();
        }
    }
}
