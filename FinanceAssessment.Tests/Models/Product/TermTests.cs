using System;
using System.Collections;
using System.Collections.Generic;
using FinanceAssessment.Models.Product;
using Xunit;

namespace FinanceAssessment.Tests.Models.Product
{
    public class TermTests
    {
        private readonly Term _sut;
        private readonly Period _period = new Period(null, null, null, 2);
        
        public TermTests()
        {
            _sut = new Term(_period);
        }

        [Fact]
        public void TermNumberOfCompleted_ReturnsOneCompletedPeriods_WhenPeriodLengthsEqual()
        {
            var investmentPeriod = new Period(null, null, null, 2);
            var dateFrom = new DateTime(2023, 4, 4);
            
            var totalCompletedPeriods = _sut.NumberOfCompleted(investmentPeriod, dateFrom);
            
            Assert.Equal(1, totalCompletedPeriods);
        }

        private class NumberOfCompletedTermsData : TheoryData<Period, DateTime, int>
        {
            public NumberOfCompletedTermsData()
            {
                Add(new Period(1, null, null, null),
                    new DateTime(2023, 4, 4),
                    0);
                Add(new Period(null, 1, null, null),
                    new DateTime(2023, 4, 4),
                    0);
                Add(new Period(null, null, 1, null),
                    new DateTime(2023, 4, 4),
                    0);
                Add(new Period(null, null, null, 2),
                    new DateTime(2023, 4, 4),
                    1);
                Add(new Period(null, null, null, 4),
                    new DateTime(2023, 4, 4),
                    2);
                Add(new Period(3, 1, 6, 4),
                    new DateTime(2023, 4, 4),
                    2);
            }
        }

        [Theory]
        [ClassData(typeof(NumberOfCompletedTermsData))]
        public void TermNumberOfCompleted_ReturnsCorrectCompletedPeriods_FromPeriod(
            Period investmentPeriod,
            DateTime fromDate,
            int expectedPeriods)
        {
            var actualPeriods = _sut.NumberOfCompleted(investmentPeriod, fromDate);
            
            Assert.Equal(expectedPeriods, actualPeriods);
        }

    }
    
    public class TheoryData<T1, T2, T3> : TheoryData
    {
        protected void Add(T1 p1, T2 p2, T3 p3)
        {
            AddRow(p1, p2, p3);
        }
    }

    public abstract class TheoryData : IEnumerable<object[]>
    {
        private readonly List<object[]> _data = new List<object[]>();

        protected void AddRow(params object[] values)
        {
            _data.Add(values);
        }
        public IEnumerator<object[]> GetEnumerator()
        {
            return _data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}