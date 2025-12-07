public class Calculator {
    private static final String SPLIT_PATTERN = buildSplitPattern();

    public Calculator() {
    }

    double calculate(double a, double b, Operator operator) {
        switch (operator) {
            case PLUS:
                return a + b;
            case MINUS:
                return a - b;
            case MULTIPLY:
                return a * b;
            case DIVIDE:
                if (b != 0) return a / b;
                else {
                    System.out.println("Error: Division by zero!");
                    return 0;
                }
            case MODULO:
                if (b != 0) return a % b;
                else {
                    System.out.println("Error: Division by zero!");
                    return 0;
                }
            default:
                System.out.println("Invalid operator!");
                return 0;
        }
    }

    private static String buildSplitPattern() {
        String operatorRegex = buildOperatorRegex();
        return "(?<=" + operatorRegex + ")|(?=" + operatorRegex + ")";
    }

    private static String buildOperatorRegex() {
        StringBuilder regex = new StringBuilder("[");
        StringBuilder hyphenPart = new StringBuilder();

        for (Operator op : Operator.values()) {
            char symbol = op.getSymbol();

            // Handle hyphen specially - add it at the end to avoid range interpretation
            if (symbol == '-') {
                hyphenPart.append(symbol);
                continue;
            }

            // Escape special regex characters
            if (symbol == '+' || symbol == '*' || symbol == '?' || symbol == '.' || 
                symbol == '[' || symbol == ']' || symbol == '\\' || symbol == '^' || 
                symbol == '$' || symbol == '|' || symbol == '(' || symbol == ')') {
                regex.append('\\');
            }
            regex.append(symbol);
        }

        // Add hyphen at the end where it won't be interpreted as a range
        regex.append(hyphenPart);
        regex.append("]");
        return regex.toString();
    }

    public double evaluateExpression(String input) {
        String[] parts = input.split(SPLIT_PATTERN);

        if (parts.length < 3) {
            throw new IllegalArgumentException("Invalid expression: too few parts");
        }

        if (parts.length % 2 == 0) {
            throw new IllegalArgumentException("Invalid expression format");
        }

        double result = Double.parseDouble(parts[0].trim());
        for (int i = 1; i < parts.length - 1; i += 2) {
            char operatorChar = parts[i].trim().charAt(0);
            Operator operator = Operator.fromSymbol(operatorChar);
            double nextNumber = Double.parseDouble(parts[i + 1].trim());
            result = calculate(result, nextNumber, operator);
        }
        return result;
    }
}
