using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CalculatorWebApp.Pages
{
    public class RealCalculatorModel : PageModel
    {
        [BindProperty]
        public string Display { get; set; } = "0";

        [BindProperty]
        public string Button { get; set; }

        public string[] Buttons { get; } = new string[]
        {
            "7", "8", "9", "/",
            "4", "5", "6", "*",
            "1", "2", "3", "-",
            "C", "0", "=", "+"
        };

        private double? _currentValue;
        private static string _operation;

        public void OnPost()
        {
            // Handle Clear (C) button
            if (Button == "C")
            {
                Display = "0";
                _currentValue = null;
                _operation = null;
                return;
            }

            // Handle Equals (=) button
            if (Button == "=")
            {                
                    double secondValue = double.Parse(Display);
                    PerformOperation(secondValue);
                    _operation = null; // Clear the operation after calculation                
                return;
            }

            // Handle Operators (+, -, *, /)
            if ("+-*/".Contains(Button))
            {
                if (_currentValue.HasValue)
                {
                    double secondValue = double.Parse(Display);
                    PerformOperation(secondValue);
                }
                else
                {
                    _currentValue = double.Parse(Display);
                }

                _operation = Button; // Store the current operation
                Display = "0"; // Clear the display for the next input
                return;
            }

            // Handle Numbers (0-9)
            if (Display == "0")
            {
                Display = Button;
            }
            else
            {
                Display += Button;
            }
        }

        private void PerformOperation(double secondValue)
        {
            switch (_operation)
            {
                case "+":
                    _currentValue += secondValue;
                    break;
                case "-":
                    _currentValue -= secondValue;
                    break;
                case "*":
                    _currentValue *= secondValue;
                    break;
                case "/":
                    _currentValue = secondValue != 0 ? _currentValue / secondValue : double.NaN;
                    break;
            }

            Display = _currentValue.ToString();
        }
    }
}