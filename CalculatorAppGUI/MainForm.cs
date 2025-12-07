using System;
using System.Windows.Forms;

    public partial class MainForm : Form
    {
        private TextBox display;
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;

        public MainForm()
        {
            Text = "Calculator";
            Width = 400;
            Height = 500;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Display TextBox
            display = new TextBox
            {
                Text = "0",
                Dock = DockStyle.Top,
                Font = new System.Drawing.Font("Arial", 24),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true
            };
            Controls.Add(display);

            // Buttons Panel
            var panel = new TableLayoutPanel
            {
                RowCount = 5,
                ColumnCount = 4,
                Dock = DockStyle.Fill
            };
            Controls.Add(panel);

            // Buttons
            string[] buttonLabels = {
                "7", "8", "9", "/",
                "4", "5", "6", "*",
                "1", "2", "3", "-",
                "C", "0", "=", "+"
            };

            foreach (var label in buttonLabels)
            {
                var button = new Button
                {
                    Text = label,
                    Dock = DockStyle.Fill,
                    Font = new System.Drawing.Font("Arial", 18)
                };
                button.Click += Button_Click;
                panel.Controls.Add(button);
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            var button = sender as Button;

            if (button.Text == "C")
            {
                display.Text = "0";
                result = 0;
                operation = "";
                isOperationPerformed = false;
                return;
            }

            if (button.Text == "=")
            {
                PerformCalculation();
                operation = "";
                return;
            }

            if ("+-*/".Contains(button.Text))
            {
                if (!isOperationPerformed)
                {
                    result = double.Parse(display.Text);
                    isOperationPerformed = true;
                }
                operation = button.Text;
                display.Text = "0";
                return;
            }

            if (display.Text == "0" || isOperationPerformed)
            {
                display.Text = button.Text;
                isOperationPerformed = false;
            }
            else
            {
                display.Text += button.Text;
            }
        }

        private void PerformCalculation()
        {
            double currentValue = double.Parse(display.Text);

            switch (operation)
            {
                case "+":
                    result += currentValue;
                    break;
                case "-":
                    result -= currentValue;
                    break;
                case "*":
                    result *= currentValue;
                    break;
                case "/":
                    if (currentValue != 0)
                        result /= currentValue;
                    else
                        MessageBox.Show("Cannot divide by zero!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }

            display.Text = result.ToString();
        }
    }
