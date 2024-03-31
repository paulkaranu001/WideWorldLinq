// See https://aka.ms/new-console-template for more information
using WideWorldLinq.Scenarios;

Console.WriteLine("Hello, Kenya");
Console.WriteLine("Hello, Uganda");
var topCustomerScenario = new TopCustomersScenario();

await topCustomerScenario.RunAsync();