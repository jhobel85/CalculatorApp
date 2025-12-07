// filepath: CalculatorWebApp/Pages/Calculator.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CalculatorModel : PageModel
{
    [BindProperty]
    public double Number1 { get; set; }

    [BindProperty]
    public double Number2 { get; set; }

    [BindProperty]
    public string Operation { get; set; }

    public double? Result { get; set; }

    public void OnPost()
    {
        switch (Operation)
        {
            case "Add":
                Result = Number1 + Number2;
                break;
            case "Subtract":
                Result = Number1 - Number2;
                break;
            case "Multiply":
                Result = Number1 * Number2;
                break;
            case "Divide":
                if (Number2 != 0)
                    Result = Number1 / Number2;
                else
                    ModelState.AddModelError("", "Cannot divide by zero.");
                break;
        }
    }
}