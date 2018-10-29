using System;
using Xunit;
using BabysitterKata;
using System.Collections.Generic;

namespace RateCalculatorTestSuite
{
    public class TestSuite
    {
        // Test level instance of Program object.
        Program testProgram = new Program();

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
            Assert.Equal(8, RateCalculator.FamilyBBetweenTenAndTwelve(1));
            Assert.Equal(16, RateCalculator.FamilyBBetweenTenAndTwelve(2));
        }

        [Fact]
        public void FamilyBProperlyPaysSixteenDollarsPerHourAfterTwelveAM()
        {
            Assert.Equal(16, RateCalculator.FamilyBAfterTwelve(1));
            Assert.Equal(64, RateCalculator.FamilyBAfterTwelve(4));
        }

        [Fact]
        public void FamilyCProperlyPaysTwentyOneDollarsPerHourBeforeNinePM()
        {
            Assert.Equal(21, RateCalculator.FamilyCBeforeNine(1));
            Assert.Equal(84, RateCalculator.FamilyCBeforeNine(4));
        }

        [Fact]
        public void FamilyCProperlyPaysFifteenDollarsPerHourAfterNinePM()
        {
            Assert.Equal(15, RateCalculator.FamilyCAfterNine(1));
            Assert.Equal(105, RateCalculator.FamilyCAfterNine(7));
        }

        [Fact]
        public void CorrectNumberOfHoursInEachRateDivisionReturnedWhenGivenStartAndEndTimes()
        {
            Assert.Equal(new[] { 6, 1 }, RateCalculator.GetHoursSplit("5:00", "12:00", "A"));
            Assert.Equal(new[] { 5, 2, 1 }, RateCalculator.GetHoursSplit("5:00", "1:00", "B"));
            Assert.Equal(new[] { 1, 6 }, RateCalculator.GetHoursSplit("8:00", "3:00", "C"));
        }

        [Fact]
        public void CorrectTotalReturnedWhenCallingGetRateForNightMethodWithStartTimeEndTimeAndFamily()
        {
            Assert.Equal(84, RateCalculator.GetRateForNight("7:00", "2:00", "B"));
            Assert.Equal(30, RateCalculator.GetRateForNight("5:00", "7:08", "A"));
            Assert.Equal(138, RateCalculator.GetRateForNight("6:00", "2:00", "C"));
        }

        [Fact]
        public void StartTimeErrorHandlingMethodProperlyHandlesStartTimeThatIsTooEarly()
        {
            Assert.Equal("Start time is too early", testProgram.HandleRawStartTime("4:00 PM"));
            Assert.Equal("Start time is too early", testProgram.HandleRawStartTime("10:00 AM"));
        }

        [Fact]
        public void StartTimeErrorHandlingMethodProperlyReturnsValidStartTime()
        {
            Assert.Equal("5:00", testProgram.HandleRawStartTime("5:00 PM"));
            Assert.Equal("11:00", testProgram.HandleRawStartTime("11:00 PM"));
            Assert.Equal("3:00", testProgram.HandleRawStartTime("3:00 AM"));
        }
    }
}
