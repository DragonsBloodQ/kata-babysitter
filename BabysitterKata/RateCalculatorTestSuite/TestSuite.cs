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
            Assert.Equal("12:00", testProgram.HandleRawStartTime("12:00 AM"));
        }

        [Fact]
        public void EndTimeErrorHandlingMethodProperlyHandlesEndTimeThatIsTooLate()
        {
            Assert.Equal("End time is too late", testProgram.HandleRawEndTime("5:00 AM"));
            Assert.Equal("End time is too late", testProgram.HandleRawEndTime("3:00 PM"));
        }

        [Fact]
        public void EndTimeErrorHandlingMethodProperlyReturnsValidEndTime()
        {
            Assert.Equal("8:00", testProgram.HandleRawEndTime("8:00 PM"));
            Assert.Equal("12:00", testProgram.HandleRawEndTime("12:00 AM"));
            Assert.Equal("3:48", testProgram.HandleRawEndTime("3:48 AM"));
        }

        [Fact]
        public void EndBeforeStartReturnsFalseWhenCheckedForCompatibility()
        {
            Assert.False(testProgram.StartAreAndEndCompatible("3:00 AM", "11:00 PM"));
            Assert.False(testProgram.StartAreAndEndCompatible("12:00 AM", "6:00 PM"));
            Assert.False(testProgram.StartAreAndEndCompatible("1:00 AM", "6:28 PM"));
        }

        [Fact]
        public void WrapperFunctionReturnsResultIfPossible()
        {
            Assert.Equal("110", testProgram.ParseAndCalculate("9:00 PM", "3:00 AM", "A"));
            Assert.Equal("36", testProgram.ParseAndCalculate("5:00 PM", "8:00 PM", "B"));
        }

        [Fact]
        public void WrapperFunctionReturnsErrorIfInputIsIncorrect()
        {
            Assert.Equal("Error: End Time occurs before Start Time. Please correct your start and end time",
                testProgram.ParseAndCalculate("11:00 AM", "6:00 PM", "A"));

            Assert.Equal("Error: Invalid input for start time.",
                testProgram.ParseAndCalculate("hamburger", "12:00 AM", "B"));

            // NOTE TO READER:
            // After some deliberation, I've decided that this is unnecessary. Given the range
            // of allowable start and end times, and the way I've chosen to work under those
            // constraints, I don't see a reason to distinguish between "end before start"
            // scenarios and "start too early"/"end too late" scenarios. I believe this aligns
            // with Pillar's stated goal to provide the minimum viable product, and scale it
            // in the future.

            // If the customer were to request that these be split up, that is something that
            // could be considered at a later date. In addition, in a real-life scenario such
            // as this one, I would defer to my partner (in pair programming), or the lead
            // for the project to figure out the right way around this issue.

            // Unnecessary test provided for reader context.
            //     Assert.Equal("Error: Start Time is too early.", testProgram.ParseAndCalculate("3:00 PM", "11:00 PM", "B"));
        }
    }
}
