// filepath: CalculatorWebApp/Pages/Calculator.cshtml.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CalculatorModel(double number2) : PageModel
{
    private readonly Calculator calculator = new();

    [BindProperty]
    public double Number1 { get; set; }

    [BindProperty]
    public double Number2 { get; set; } = number2;

    [BindProperty]
    public required string Operation { get; set; }

    public double? Result { get; set; }

    public void OnPost()
    {
        try
        {
            switch (Operation)
            {
                case "Add":
                    Result = calculator.Add(Number1, Number2);
                    break;
                case "Subtract":
                    Result = calculator.Subtract(Number1, Number2);
                    break;
                case "Multiply":
                    Result = calculator.Multiply(Number1, Number2);
                    break;
                case "Divide":
                    Result = calculator.Divide(Number1, Number2);
                    break;
            }
        }
        catch (System.DivideByZeroException ex)
        {
            ModelState.AddModelError("", ex.Message);
        }
    }
}