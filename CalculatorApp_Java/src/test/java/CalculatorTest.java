import org.junit.jupiter.api.BeforeEach;
import org.junit.jupiter.api.Test;
import org.junit.jupiter.api.DisplayName;
import static org.junit.jupiter.api.Assertions.*;

import java.io.ByteArrayOutputStream;
import java.io.PrintStream;

@DisplayName("Calculator calculate() method tests")
class CalculatorTest {
    private Calculator calculator;
    private final ByteArrayOutputStream outputStreamCaptor = new ByteArrayOutputStream();
    private final PrintStream originalOut = System.out;

    @BeforeEach
    void setUp() {
        calculator = new Calculator();
        System.setOut(new PrintStream(outputStreamCaptor));
    }

    @Test
    @DisplayName("Addition: 5 + 3 = 8")
    void testAdditionPositiveNumbers() {
        double result = calculator.calculate(5, 3, Operator.PLUS);
        assertEquals(8.0, result, 0.0001);
    }

    @Test
    @DisplayName("Addition: -5 + 3 = -2")
    void testAdditionWithNegativeNumber() {
        double result = calculator.calculate(-5, 3, Operator.PLUS);
        assertEquals(-2.0, result, 0.0001);
    }

    @Test
    @DisplayName("Addition: 5.5 + 3.2 = 8.7")
    void testAdditionWithDecimals() {
        double result = calculator.calculate(5.5, 3.2, Operator.PLUS);
        assertEquals(8.7, result, 0.0001);
    }

    @Test
    @DisplayName("Subtraction: 10 - 3 = 7")
    void testSubtractionPositiveNumbers() {
        double result = calculator.calculate(10, 3, Operator.MINUS);
        assertEquals(7.0, result, 0.0001);
    }

    @Test
    @DisplayName("Subtraction: 3 - 10 = -7")
    void testSubtractionResultingInNegative() {
        double result = calculator.calculate(3, 10, Operator.MINUS);
        assertEquals(-7.0, result, 0.0001);
    }

    @Test
    @DisplayName("Subtraction: -5 - -3 = -2")
    void testSubtractionWithNegativeNumbers() {
        double result = calculator.calculate(-5, -3, Operator.MINUS);
        assertEquals(-2.0, result, 0.0001);
    }

    @Test
    @DisplayName("Multiplication: 5 * 3 = 15")
    void testMultiplicationPositiveNumbers() {
        double result = calculator.calculate(5, 3, Operator.MULTIPLY);
        assertEquals(15.0, result, 0.0001);
    }

    @Test
    @DisplayName("Multiplication: -5 * 3 = -15")
    void testMultiplicationWithNegativeNumber() {
        double result = calculator.calculate(-5, 3, Operator.MULTIPLY);
        assertEquals(-15.0, result, 0.0001);
    }

    @Test
    @DisplayName("Multiplication: 5 * 0 = 0")
    void testMultiplicationByZero() {
        double result = calculator.calculate(5, 0, Operator.MULTIPLY);
        assertEquals(0.0, result, 0.0001);
    }

    @Test
    @DisplayName("Multiplication: 2.5 * 4 = 10")
    void testMultiplicationWithDecimals() {
        double result = calculator.calculate(2.5, 4, Operator.MULTIPLY);
        assertEquals(10.0, result, 0.0001);
    }

    @Test
    @DisplayName("Division: 10 / 2 = 5")
    void testDivisionPositiveNumbers() {
        double result = calculator.calculate(10, 2, Operator.DIVIDE);
        assertEquals(5.0, result, 0.0001);
    }

    @Test
    @DisplayName("Division: 10 / 3 = 3.333...")
    void testDivisionWithRemainder() {
        double result = calculator.calculate(10, 3, Operator.DIVIDE);
        assertEquals(3.3333, result, 0.0001);
    }

    @Test
    @DisplayName("Division: -10 / 2 = -5")
    void testDivisionWithNegativeNumber() {
        double result = calculator.calculate(-10, 2, Operator.DIVIDE);
        assertEquals(-5.0, result, 0.0001);
    }

    @Test
    @DisplayName("Division by zero returns 0 and prints error")
    void testDivisionByZero() {
        double result = calculator.calculate(10, 0, Operator.DIVIDE);
        assertEquals(0.0, result, 0.0001);
        assertTrue(outputStreamCaptor.toString().contains("Error: Division by zero!"));
    }

    @Test
    @DisplayName("Modulo: 10 % 3 = 1")
    void testModuloPositiveNumbers() {
        double result = calculator.calculate(10, 3, Operator.MODULO);
        assertEquals(1.0, result, 0.0001);
    }

    @Test
    @DisplayName("Modulo: 15 % 5 = 0")
    void testModuloWithNoRemainder() {
        double result = calculator.calculate(15, 5, Operator.MODULO);
        assertEquals(0.0, result, 0.0001);
    }

    @Test
    @DisplayName("Modulo: -10 % 3 = -1")
    void testModuloWithNegativeNumber() {
        double result = calculator.calculate(-10, 3, Operator.MODULO);
        assertEquals(-1.0, result, 0.0001);
    }

    @Test
    @DisplayName("Modulo by zero returns 0 and prints error")
    void testModuloByZero() {
        double result = calculator.calculate(10, 0, Operator.MODULO);
        assertEquals(0.0, result, 0.0001);
        assertTrue(outputStreamCaptor.toString().contains("Error: Division by zero!"));
    }

    @Test
    @DisplayName("Modulo: 5.5 % 2 = 1.5")
    void testModuloWithDecimals() {
        double result = calculator.calculate(5.5, 2, Operator.MODULO);
        assertEquals(1.5, result, 0.0001);
    }

    @org.junit.jupiter.api.AfterEach
    void tearDown() {
        System.setOut(originalOut);
    }
}
