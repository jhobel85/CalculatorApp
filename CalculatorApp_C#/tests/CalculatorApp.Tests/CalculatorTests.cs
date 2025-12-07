using NUnit.Framework;
using System;

namespace CalculatorApp.Tests
{
    public class CalculatorTests
    {
        private Calculator calculator;

        [SetUp]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [Test]
        public void Add_TwoPositiveNumbers_ReturnsCorrectSum()
        {
            var result = calculator.Add(2, 3);
            Assert.That(result, Is.EqualTo(5));
        }

        [Test]
        public void Subtract_TwoPositiveNumbers_ReturnsCorrectDifference()
        {
            var result = calculator.Subtract(5, 3);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Multiply_TwoPositiveNumbers_ReturnsCorrectProduct()
        {
            var result = calculator.Multiply(2, 3);
            Assert.That(result, Is.EqualTo(6));
        }

        [Test]
        public void Divide_TwoPositiveNumbers_ReturnsCorrectQuotient()
        {
            var result = calculator.Divide(6, 3);
            Assert.That(result, Is.EqualTo(2));
        }

        [Test]
        public void Divide_ByZero_ThrowsDivideByZeroException()
        {
            Assert.Throws<DivideByZeroException>(() => calculator.Divide(6, 0));
        }
    }
}