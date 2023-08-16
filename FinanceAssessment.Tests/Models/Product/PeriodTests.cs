using System;
using FinanceAssessment.Models.Product;
using Xunit;
using Assert = Xunit.Assert;

namespace FinanceAssessment.Tests.Models.Product
{
    public class PeriodTests
    {
        private readonly Period _sut;
        private const int Days = 1;
        private const int Weeks = 2;
        private const int Months = 3;
        private const int Years = 4;

        public PeriodTests()
        {
            _sut = new Period(Days, Weeks, Months, Years);
        }

        [Fact]
        public void PeriodInit_Sets_PeriodParameters()
        {
            Assert.Equal(Days, _sut.Days);
            Assert.Equal(Weeks, _sut.Weeks);
            Assert.Equal(Months, _sut.Months);
            Assert.Equal(Years, _sut.Years);
        }

        [Fact]
        public void PeriodCompletionDayIndex_ReturnsCorrectDayIndex_FromDateTime()
        {
            var inputDateTime = new DateTime(2023, 4, 4);
            
            var dayIndex = _sut.CompletionDayIndex(inputDateTime);

            const int expectedDayIndex = 21018;
            
            Assert.Equal(expectedDayIndex, dayIndex);
        }

        [Fact]
        public void PeriodAddPeriod_AddsPeriodCorrectly_FromPeriod()
        {
            const int days = 1;
            const int weeks = 2;
            const int months = 3;
            const int years = 4;
            
            var period = new Period(1, 2, 3, 4);
            
            _sut.AddPeriod(period);
            
            Assert.Equal(Days + days, _sut.Days);
            Assert.Equal(Weeks + weeks, _sut.Weeks);
            Assert.Equal(Months + months, _sut.Months);
            Assert.Equal(Years + years, _sut.Years);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void PeriodAddPeriod_IncrementsPeriod_ByGivenPeriod(int adjustment)
        {
            var period = new Period(adjustment, adjustment, adjustment, adjustment);

            for (var i = 0; i < 10*adjustment; i+=adjustment)
            {
                _sut.AddPeriod(period);

                var increment = i + adjustment;
                
                Assert.Equal(Days + increment, _sut.Days);
                Assert.Equal(Weeks + increment, _sut.Weeks);
                Assert.Equal(Months + increment, _sut.Months);
                Assert.Equal(Years + increment, _sut.Years);
            }
        }
    }
}