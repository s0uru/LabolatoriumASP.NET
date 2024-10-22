using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CalculatorController : Controller
    {
        // GET: CalculatorController
        public ActionResult Index()
        {
            return View();
        }
        public IActionResult Result(Calculator model)
        {
            if (!model.IsValid())
            {
                return View("Error");
            }
            return View(model);
        }
        
        public IActionResult Form()
        {
            return View();
        }
        
        
        
        public IActionResult Result(Operator? op, double? x, double? y)
        {
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

    }
}
