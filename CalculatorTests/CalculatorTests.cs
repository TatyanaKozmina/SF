using NUnit.Framework;
using Practices;

namespace CalculatorTests
{
    [TestFixture]
    public class CalculatorTests
    {
        [Test]
        public void Additional_ReturnCorrectValue()
        {
            Calculator calculator = new Calculator();
            Assert.That(19 == calculator.Additional(6, 13));
        }

        [Test]
        public void Additional_MaxValueExceedException()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<MaxValueExceedException>(() => calculator.Additional(int.MaxValue, 1));
        }

        [Test]
        public void Additional_MinValueExceedException()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<MinValueExceedException>(() => calculator.Additional(int.MinValue, -1));
        }

        [Test]
        public void Subtraction_ReturnCorrectValue()
        {
            Calculator calculator = new Calculator();
            Assert.That(-7 == calculator.Subtraction(6, 13));
        }

        [Test]
        public void Subtraction_MaxValueExceedException()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<MaxValueExceedException>(() => calculator.Subtraction(1, int.MinValue));
        }

        [Test]
        public void Subtraction_MinValueExceedException()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<MinValueExceedException>(() => calculator.Subtraction(int.MinValue, 1));
        }

        [Test]
        public void Miltiplication_ReturnCorrectValue()
        {
            Calculator calculator = new Calculator();
            Assert.That(6 == calculator.Miltiplication(2, 3));
        }

        [Test]
        public void Miltiplication_MaxValueExceedException()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<MaxValueExceedException>(() => calculator.Miltiplication(int.MaxValue, 2));
        }

        [Test]
        public void Miltiplication_MinValueExceedException()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<MinValueExceedException>(() => calculator.Miltiplication(int.MinValue, 2));
        }

        [Test]
        public void Division_ReturnCorrectValue()
        {
            Calculator calculator = new Calculator();
            Assert.That(2 == calculator.Division(5, 2));
        }

        [Test]
        public void Division_DivideByZeroException()
        {
            Calculator calculator = new Calculator();
            Assert.Throws<DivideByZeroException>(() => calculator.Division(2, 0));
        }
    }
}