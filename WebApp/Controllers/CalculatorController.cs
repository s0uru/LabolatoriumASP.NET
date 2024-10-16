using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers;

public class CalculatorController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
    
    public IActionResult Form()
    {
        return View();
    }
    

    public IActionResult Result(Operator? op, double? a, double? b)
    {
        //https://localhost:7271/Home/Calculator?op=add&x=4&y=1,5
        //var op =Request.Query["op"];
        //var x = double.Parse(Request.Query["x"]);
        //var y = double.Parse(Request.Query["y"]);
        if (a is null || b is null)
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
                result = a + b;
                ViewBag.Operator = "+";
                break;
            case Operator.Sub:
                result = a - b;
                ViewBag.Operator = "-";
                break;
            case Operator.Nul:
                result = a * b;
                ViewBag.Operator = "*";
                break;
            case Operator.Div:
                result = a / b;
                ViewBag.Operator = "/";
                break;
        }

        ViewBag.Result = result;
        ViewBag.X = a;
        ViewBag.Y = b;
        return View();
    }
     
    public enum Operator
    {
        Add, Sub, Nul, Div
    }
}