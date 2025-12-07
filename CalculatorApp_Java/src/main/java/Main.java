void main() {
    Calculator calculator = new Calculator();
    Scanner scanner = new Scanner(System.in);

    IO.println("Welcome to the Calculator!");

    while (true) {
        showMenu();
        String input = scanner.nextLine().trim();

        if (input.equalsIgnoreCase("exit")) {
            IO.println("Goodbye!");
            break;
        }

        try {
            double result = calculator.evaluateExpression(input);
            IO.println("Result: " + result);
        } catch (NumberFormatException e) {
            IO.println("Invalid number format! Please enter valid numbers.");
        } catch (IllegalArgumentException e) {
            IO.println("Error: " + e.getMessage());
            IO.println("Please use format: number operator number [operator number]...");
        }
    }

    scanner.close();
}

private static void showMenu() {
    IO.println("\nCalculator Menu:");
    IO.println("Enter an expression (e.g., 5 + 3 * 2)");
    IO.println("Supported operators: +, -, *, /, %");
    IO.println("Or type 'exit' to quit");
    IO.print("> ");
}
