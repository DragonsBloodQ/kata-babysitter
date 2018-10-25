using System;
using Xunit;
using BabysitterKata;

namespace RateCalculatorTestSuite
{
    public class TestSuite
    {
        [Fact]
        public void FamilyAProperlyPaysFifteenDollarsPerHourBeforeElevenPM()
        {
            // Usage of the constant as the first argument is idiomatic for the xUnit Test Framework
            // and is enforced by Visual Studio (Code xUnit2000).
            Assert.Equal(15, RateCalculator.FamilyABefore11(1));
            Assert.Equal(75, RateCalculator.FamilyABefore11(5));
        }
    }
}
