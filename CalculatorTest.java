import org.junit.jupiter.api.DisplayName;
import org.junit.jupiter.api.Test;

import static org.junit.jupiter.api.Assertions.*;

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
}
