using System;
using System.Windows.Forms;
    public partial class MainForm : Form
    {
        private TextBox display = null!;
        private double result = 0;
        private string operation = "";
        private bool isOperationPerformed = false;
        private readonly Calculator calculator = new();

        public MainForm()
        {
            Text = "Calculator";
            Width = 400;
            Height = 750;
            AutoScaleMode = AutoScaleMode.Font;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;

            InitializeComponents();
        }

        private void InitializeComponents()
        {
            // Display TextBox
            display = new TextBox
            {
                Text = "0",
                Location = new System.Drawing.Point(5, 5),
                Size = new System.Drawing.Size(380, 70),
                Font = new System.Drawing.Font("Arial", 26),
                TextAlign = HorizontalAlignment.Right,
                ReadOnly = true,
                BorderStyle = BorderStyle.FixedSingle,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right,
                Padding = new Padding(5, 0, 5, 0)
            };
            Controls.Add(display);

            // Buttons Panel
            var panel = new TableLayoutPanel
            {
                RowCount = 5,
                ColumnCount = 4,
                Location = new System.Drawing.Point(5, 85),
                Size = new System.Drawing.Size(390, 660),
                AutoSize = false,
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };
            
            // Set uniform row and column sizes
            for (int i = 0; i < 5; i++)
                panel.RowStyles.Add(new RowStyle(SizeType.Percent, 20f));
            for (int i = 0; i < 4; i++)
                panel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25f));
            
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
                    Font = new System.Drawing.Font("Arial", 18),
                    Margin = new Padding(2)
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

            try
            {
                switch (operation)
                {
                    case "+":
                        result = calculator.Add(result, currentValue);
                        break;
                    case "-":
                        result = calculator.Subtract(result, currentValue);
                        break;
                    case "*":
                        result = calculator.Multiply(result, currentValue);
                        break;
                    case "/":
                        result = calculator.Divide(result, currentValue);
                        break;
                }

                display.Text = result.ToString();
            }
            catch (System.DivideByZeroException ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                display.Text = "0";
                result = 0;
            }
        }
    }