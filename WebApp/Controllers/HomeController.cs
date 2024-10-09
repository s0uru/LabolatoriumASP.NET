using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }
    
    /*
     * Zadanie 1
     * Utwórz metode Calculator oraz widok, w nim wyswietl tylko napis kalkulatora
     * Dodaj link nawigayjny aplikacji do metody Calculator
     * Wykonaj commin i wyslij kod do repozytorium - push
     *
     * Zadanie domowe
     * Napisz metodę Age, która przyjmuje parametr z datą urodzin i wyświetla wiek
     * w latach, miesiącach i dniach.
     */

    public IActionResult Index()
    {
        return View();
    }

    //zadaniedomowe
    public IActionResult Age(DateTime birthDate)
    {
        var today = DateTime.Today;
        int years = today.Year - birthDate.Year;
        int months = today.Month - birthDate.Month; 
        int days = today.Day - birthDate.Day;

        if (days < 0)
        {
            months--;
            days += DateTime.DaysInMonth(today.Year, today.Month == 1 ? 12 : today.Month - 1);    
        }

        if (months < 0)
        {
            years--;
            months += 12;
        }
        ViewBag.Years = years;
        ViewBag.Months = months;
        ViewBag.Days = days;    
        
        return View();  
    }
    
    public IActionResult About()
    {
        return View();
    }
    
    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Calculator(Operator? op, double? x, double? y)
    {
        //https://localhost:7271/Home/Calculator?op=add&x=4&y=1,5
        //var op =Request.Query["op"];
        //var x = double.Parse(Request.Query["x"]);
        //var y = double.Parse(Request.Query["y"]);
        if (x is null || y is null)
        {
            ViewBag.ErrorMessage = "Niepoprawny format liczby x lub y lub brak tych parametrów!";
            return View("CalculatorError");
        }

        if (op is null)
        {
            ViewBag.ErrorMessage = "Nieznany operator";
            return View("CalculatorError");
        }
        
        double? result = 0.0d;
        switch (op)
        {
            case Operator.Add:
                result = x + y;
                ViewBag.Operator = "+";
                break;
            case Operator.Sub:
                result = x - y;
                ViewBag.Operator = "-";
                break;
            case Operator.Nul:
                result = x * y;
                ViewBag.Operator = "*";
                break;
            case Operator.Div:
                result = x / y;
                ViewBag.Operator = "/";
                break;
        }

        ViewBag.Result = result;
        ViewBag.X = x;
        ViewBag.Y = y;
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

public enum Operator
{
    Add, Sub, Nul, Div,
}
