using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Ninja;

namespace Ninja.NUnitTest
{
    public class DemeritPointsCalculatorTests
    {
        private DemeritPointsCalculator _calculator;

        [SetUp]

        public void Setup()
        {

            _calculator = new DemeritPointsCalculator();
        }

        [Test]
        [TestCase(-1)]
        [TestCase(301)]
        public void CalculateDemeritPoints_SpeedIsNegative_ThrowArgumentOutOfRangeException(int speed)
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => _calculator.CalculateDemeritPoints(speed));
        }


        [Test]
        [TestCase(0, 0)]
        [TestCase(64, 0)]
        [TestCase(65, 0)]
        public void CalculateDemeritPoints_SpeedIsZeroOrLessThanOrEqualSpeedLimit_ReturnZero(int speed, int expectedResult)
        {

            var result = _calculator.CalculateDemeritPoints(speed);

            Assert.AreEqual(expectedResult, result);
        }


        [Test]
        [TestCase(66, 0)]
        [TestCase(75, 2)]
        [TestCase(80, 3)]
        public void CalculateDemeritPoints_SpeedGreaterThanSpeedLimit_ReturnDemeritPoint(int speed, int expectedResult)
        {
            var result = _calculator.CalculateDemeritPoints(speed);

            Assert.AreEqual(expectedResult, result);
        }

    }
}
