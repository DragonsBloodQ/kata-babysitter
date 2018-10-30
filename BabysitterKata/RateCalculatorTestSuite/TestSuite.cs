using System;
using Xunit;
using BabysitterKata;
using System.Collections.Generic;

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
            Assert.Equal("Start time is too early", Program.HandleRawStartTime("4:00 PM"));
            Assert.Equal("Start time is too early", Program.HandleRawStartTime("10:00 AM"));
        }

        [Fact]
        public void StartTimeErrorHandlingMethodProperlyReturnsValidStartTime()
        {
            Assert.Equal("5:00", Program.HandleRawStartTime("5:00 PM"));
            Assert.Equal("11:00", Program.HandleRawStartTime("11:00 PM"));
            Assert.Equal("3:00", Program.HandleRawStartTime("3:00 AM"));
            Assert.Equal("12:00", Program.HandleRawStartTime("12:00 AM"));
        }

        [Fact]
        public void EndTimeErrorHandlingMethodProperlyHandlesEndTimeThatIsTooLate()
        {
            Assert.Equal("End time is too late", Program.HandleRawEndTime("5:00 AM"));
            Assert.Equal("End time is too late", Program.HandleRawEndTime("3:00 PM"));
        }

        [Fact]
        public void EndTimeErrorHandlingMethodProperlyReturnsValidEndTime()
        {
            Assert.Equal("8:00", Program.HandleRawEndTime("8:00 PM"));
            Assert.Equal("12:00", Program.HandleRawEndTime("12:00 AM"));
            Assert.Equal("3:48", Program.HandleRawEndTime("3:48 AM"));
        }

        [Fact]
        public void EndBeforeStartReturnsFalseWhenCheckedForCompatibility()
        {
            Assert.False(Program.StartAreAndEndCompatible("3:00 AM", "11:00 PM"));
            Assert.False(Program.StartAreAndEndCompatible("12:00 AM", "6:00 PM"));
            Assert.False(Program.StartAreAndEndCompatible("1:00 AM", "6:28 PM"));
        }

        [Fact]
        public void WrapperFunctionReturnsResultIfPossible()
        {
            Assert.Equal("110", Program.ParseAndCalculate("9:00 PM", "3:00 AM", "A"));
            Assert.Equal("36", Program.ParseAndCalculate("5:00 PM", "8:00 PM", "B"));
        }

        [Fact]
        public void WrapperFunctionReturnsErrorIfInputIsIncorrect()
        {
            // It occurred to me that this test might be trying to do too much. I decided
            // to cover all possible errors in one test because I am already checking the
            // individual error states separately above.
            Assert.Equal("Error: End Time occurs before Start Time. Please correct your start and end time",
                Program.ParseAndCalculate("11:00 AM", "6:00 PM", "A"));

            Assert.Equal("Error: Start time is too early.",
                Program.ParseAndCalculate("8:00 AM", "4:00 AM", "C"));

            Assert.Equal("Error: Invalid input for start time. Time entry must contain a time value and an AM/PM indicator.",
                Program.ParseAndCalculate("hamburger", "12:00 AM", "B"));

            Assert.Equal("Error: Invalid input for start time. Time value must follow the following format: h:mm. (Hour can be" +
                "1 or 2 digits).",
                Program.ParseAndCalculate("6;00 PM", "12:00 AM", "B"));

            Assert.Equal("Error: Invalid input for start time. Time value must follow the following format: h:mm. (Hour can be" +
                "1 or 2 digits).",
                Program.ParseAndCalculate("6;00 PM", "12:00 AM", "B"));

            Assert.Equal("Error: Invalid entry for family indicator. Please enter A, B, or C.",
                Program.ParseAndCalculate("5:00 PM", "8:00 PM", "$"));
        }
    }
}
