// See https://aka.ms/new-console-template for more information

using MyLibrary;
using MyServices;
using Newtonsoft.Json;
using Microsoft.Extensions.DependencyInjection;

var kalkulator = new Calculator();
int wynik_dod = kalkulator.Add(3,5);
int wynik_odej = kalkulator.Subtract(3, 5);
Console.WriteLine($"Wynik dodawania 3+5 = {wynik_dod}");
Console.WriteLine($"Wynik odemowania 3-5 = {wynik_odej}");

int sum = kalkulator.Add(5, 3);
var result = new { Operation = "Add", A = 5, B = 3, Result = sum };
string jsonResult = JsonConvert.SerializeObject(result, Formatting.Indented);
Console.WriteLine(jsonResult);

// Konfiguracja kontenera DI
var serviceProvider = new ServiceCollection()
    .AddSingleton<ILoggerService, ConsoleLogger>()
    .BuildServiceProvider();

// Uzyskanie instancji loggera
var logger = serviceProvider.GetService<ILoggerService>();
logger.Log("Aplikacja uruchomiona.");

// Przykładowe użycie kalkulatora
int sum2 = kalkulator.Add(10, 15);
logger.Log($"Wynik dodawania: {sum2}");

