// See https://aka.ms/new-console-template for more information
using WideWorldLinq.Scenarios;

Console.WriteLine("Hello, Kenya");
Console.WriteLine("Hello, Uganda");
//var topCustomerScenario = new TopCustomersScenario();

//await topCustomerScenario.RunAsync();

var ordersSimple = new OrdersSimple();
await ordersSimple.RunAsync();
var highestTemp = new HighestTemp();
await highestTemp.RunAsync();
var cities = new CitiesWithHighestPopulation();
await cities.RunAsync();