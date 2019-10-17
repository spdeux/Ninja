using NUnit.Framework;

namespace Ninja.NUnitTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void GetOutput_InputIsDivisableBy3And5_ReturnFizzBuzz()
        {

            var result = FizzBuzz.GetOutput(15);

            //Assert.That(result, Does.StartWith("Fizz").IgnoreCase);
            //Assert.That(result, Does.EndWith("Buzz").IgnoreCase);
            Assert.That(result, Is.EqualTo("FizzBuzz").IgnoreCase);

        }
        [Test]
        public void GetOutput_InputIsDivisableBy3_ReturnFizz()
        {

            var result = FizzBuzz.GetOutput(3);

            Assert.That(result, Is.EqualTo("Fizz").IgnoreCase);
        }
        [Test]
        public void GetOutput_InputIsDivisableBy5_ReturnBuzz()
        {

            var result = FizzBuzz.GetOutput(5);

            Assert.That(result, Is.EqualTo("Buzz").IgnoreCase);
        }
        [Test]
        public void GetOutput_InputIsNotDivisableBy3And5_ReturnBuzz()
        {

            var result = FizzBuzz.GetOutput(7);

            Assert.That(result, Is.EqualTo("7"));
        }
    }

}