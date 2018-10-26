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

        [Fact]
        public void FamilyAProperlyPaysTwentyDollarsPerHourAfterElevenPM()
        {
            Assert.Equal(20, RateCalculator.FamilyAAfterEleven(1));
            Assert.Equal(100, RateCalculator.FamilyAAfterEleven(5));
        }

        [Fact]
        public void FamilyBProperlyPaysTwelveDollarsPerHourBeforeTenPM()
        {
            Assert.Equal(12, RateCalculator.FamilyBBeforeTen(1));
            Assert.Equal(60, RateCalculator.FamilyBBeforeTen(5));
        }

        [Fact]
        public void FamilyBProperlyPaysEightDollarsPerHourBetweenTenPMAndTwelveAM()
        {
            Assert.Equal(8, RateCalculator.FamilyBetweenTenAndTwelve(1));
            Assert.Equal(16, RateCalculator.FamilyBetweenTenAndTwelve(2));
        }
    }
}
