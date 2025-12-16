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

        private double? CurrentValue
        {
            get {
                var sessionValue = HttpContext.Session.GetString("CurrentValue");
                return !string.IsNullOrEmpty(sessionValue) ? double.Parse(sessionValue) : null;
            }
            set {
                if (value.HasValue)
                    HttpContext.Session.SetString("CurrentValue", value.ToString());
                else
                    HttpContext.Session.Remove("CurrentValue");
            }
        }

        private string Operation
        {
            get => HttpContext.Session.GetString("Operation");
            set {
                if (!string.IsNullOrEmpty(value))
                    HttpContext.Session.SetString("Operation", value);
                else
                    HttpContext.Session.Remove("Operation");
            }
        }

        public void OnPost()
        {
            // Handle Clear (C) button
            if (Button == "C")
            {
                Display = "0";
                CurrentValue = null;
                Operation = null;
                return;
            }

            // Handle Equals (=) button
            if (Button == "=")
            {                
                if (CurrentValue.HasValue && !string.IsNullOrEmpty(Operation))
                {
                    double secondValue = double.Parse(Display);
                    PerformOperation(secondValue);
                    Operation = null; // Clear the operation after calculation
                }
                return;
            }

            // Handle Operators (+, -, *, /)
            if ("+-*/".Contains(Button))
            {
                if (CurrentValue.HasValue && !string.IsNullOrEmpty(Operation))
                {
                    double secondValue = double.Parse(Display);
                    PerformOperation(secondValue);
                }
                else
                {
                    CurrentValue = double.Parse(Display);
                }

                Operation = Button; // Store the current operation
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
            switch (Operation)
            {
                case "+":
                    CurrentValue += secondValue;
                    break;
                case "-":
                    CurrentValue -= secondValue;
                    break;
                case "*":
                    CurrentValue *= secondValue;
                    break;
                case "/":
                    CurrentValue = secondValue != 0 ? CurrentValue / secondValue : double.NaN;
                    break;
            }

            Display = CurrentValue.ToString();
        }
    }
}