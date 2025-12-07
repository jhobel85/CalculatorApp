import java.util.Scanner;

public class Main {
    public static void main(String[] args) {
        Calculator calculator = new Calculator();
        Scanner scanner = new Scanner(System.in);

        System.out.println("Welcome to the Calculator!");

        while (true) {
            showMenu();
            String input = scanner.nextLine().trim();

            if (input.equalsIgnoreCase("exit")) {
                System.out.println("Goodbye!");
                break;
            }

            try {
                double result = calculator.evaluateExpression(input);
                System.out.println("Result: " + result);
            } catch (NumberFormatException e) {
                System.out.println("Invalid number format! Please enter valid numbers.");
            } catch (IllegalArgumentException e) {
                System.out.println("Error: " + e.getMessage());
                System.out.println("Please use format: number operator number [operator number]...");
            }
        }

        scanner.close();
    }

    private static void showMenu() {
        System.out.println("\nCalculator Menu:");
        System.out.println("Enter an expression (e.g., 5 + 3 * 2)");
        System.out.println("Supported operators: +, -, *, /, %");
        System.out.println("Or type 'exit' to quit");
        System.out.print("> ");
    }
}
