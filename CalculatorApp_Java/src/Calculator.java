import java.util.Scanner;

public class Calculator {
    private final Scanner scanner;
    private double result;

    public Calculator() {
        scanner = new Scanner(System.in);
        result = 0;
    }

    private double calculate(double a, double b, char operator) {
        switch (operator) {
            case '+':
                return a + b;
            case '-':
                return a - b;
            case '*':
                return a * b;
            case '/':
                if (b != 0) return a / b;
                else {
                    System.out.println("Error: Division by zero!");
                    return 0;
                }
            default:
                System.out.println("Invalid operator!");
                return 0;
        }
    }

    private double evaluateExpression(String[] parts) {
        if (parts.length < 3) return 0;
        double result = Double.parseDouble(parts[0].trim());
        for (int i = 1; i < parts.length - 1; i += 2) {
            char operator = parts[i].trim().charAt(0);
            double nextNumber = Double.parseDouble(parts[i + 1].trim());
            result = calculate(result, nextNumber, operator);
        }
        return result;
    }

    private void showMenu() {
        System.out.println("\nCalculator Menu:");
        System.out.println("Enter an expression (e.g., 5 + 3)");
        System.out.println("Or type 'exit' to quit");
    }

    public void run() {
        while (true) {
            showMenu();
            String input = scanner.nextLine().trim();

            if (input.equalsIgnoreCase("exit")) {
                break;
            }

            // Split by one or more operators (+, -, *, /), keeping the operator as a delimiter?
            // Better approach: Split by operator, but we need to know which operator it was.
            // Or just normalize the string first by adding spaces around operators.

            // This regex splits by whitespace (optional) followed by an operator followed by whitespace (optional),
            // But simpler is to just replace operators with " operator " and then split by space

            // Let's look for the operator character first
            char operator;
            char[] operators = {'+', '-', '*', '/'};

            for (char op : operators) {
                int index = input.indexOf(op);
                // handle negative numbers? The simplistic calculator seems to assume "number operator number"
                // If we assume standard binary operation.
                // Let's assume the first found operator is not at index 0 (to allow negative first number, though the current logic is simple)
                // Actually, the current logic `parts[1].charAt(0)` implies the operator is the middle element.

                // Let's stick to the user request: "trim any white space characters before and after operator"
                // We can do this by splitting with a regex that consumes surrounding spaces.

                if (index != -1) {
                    // If multiple operators exist, this simple logic might pick the first one found based on array order or string position.
                    // Let's find the first operator in the string that makes sense.
                    // Actually, a simpler way to support "5+3" is to split by the operator characters
                    // and trim the results.

                    // Let's try to locate the operator position.
                    // We need to handle the case where the first number is negative (starts with -).
                    // So we look for an operator after the first character.
                    // We found an operator, let's verify if we should stop (e.g., first valid operator)
                    // But wait, indexOf returns the first occurrence.
                    // If input is "5+3", index of + is 1.
                    // If input is "-5+3", the index of - is 0. We want the second one.
                    if (index > 0) break; // Found a likely operator
                }
            }

            // However, a cleaner way given the current structure is to regex split
            // "5 + 3" -> ["5", "+", "3"] (if we keep delimiters)
            // or just parse manually.

            // Regex approach: split by optional space, operator, optional space
            // String[] parts = input.split("(?<=[-+*/])|(?=[-+*/])");
            // This splits around operators but keeps them.
            // Then we trim parts.

            // Let's replace the naive split(" ") with a regex split that handles the operator
            // regex: "((?<=[\\+\\-\\*\\/])|(?=[\\+\\-\\*\\/]))"
            // This splits before and after the operator.
            // input: "5+3" -> "5", "+", "3"
            // input: "5 + 3" -> "5 ", "+", " 3"

            // However, the existing code expects parts.length == 3 after split(" ").
            // "5 + 3" split(" ") -> "5", "+", "3".

            // If I use the regex:
            // String[] parts = input.split("(?<=[-+*/])|(?=[-+*/])");
            // "5+3" -> ["5", "+", "3"]
            // "5 + 3" -> ["5 ", "+", " 3"] -> trim elements -> ["5", "+", "3"]

            String[] rawParts = input.split("(?<=[-+*/])|(?=[-+*/])");
            if (rawParts.length >= 3 && rawParts.length % 2 == 1) {
                try {
                    result = evaluateExpression(rawParts);
                    System.out.println("Result: " + result);
                } catch (NumberFormatException e) {
                    System.out.println("Invalid number format!");
                }
            } else {
                System.out.println("Invalid input format! Use: number operator number [operator number]...");
            }
        }
        scanner.close();
    }
}
