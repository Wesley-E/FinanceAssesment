using System;
using FinanceAssessment.Models.Product;
using Xunit;

namespace FinanceAssessment.Tests.Models.Product
{
    public class ProductTests
    {
        private readonly FinanceAssessment.Models.Product.Product _sut;
        private readonly InterestRate _interestRate;

        public ProductTests()
        {
            _interestRate = new InterestRate(0.035m);
            var period = new Period(null, null, null, 2);
            var term = new Term(period);

            _sut = new FinanceAssessment.Models.Product.Product("product", _interestRate, term);
        }

        [Fact]
        public void ProductYield_ReturnsCorrectAmount_WhenPeriodsAreEqual()
        {
            const int amount = 500;
            var investmentPeriod = new Period(null, null, null, 2);
            var fromDate = new DateTime(2023, 4, 4);

            var actualYieldAmount = _sut.Yield(amount, investmentPeriod, fromDate);
            
            Assert.Equal(517.5m, actualYieldAmount);
        }
        
        [Fact]
        public void ProductYield_ReturnsInputAmount_WhenInvestmentPeriodIsLessThanProduct()
        {
            const int amount = 500;
            var investmentPeriod = new Period(null, null, null, 1);
            var fromDate = new DateTime(2023, 4, 4);

            var actualYieldAmount = _sut.Yield(amount, investmentPeriod, fromDate);
            
            Assert.Equal(500m, actualYieldAmount);
        }
        
        [Fact]
        public void ProductYield_ReturnsCorrectAmount_WhenInvestmentIsCompounded()
        {
            var period = new Period(null, null, 1, null);
            var term = new Term(period);

            var sut = new FinanceAssessment.Models.Product.Product("product", _interestRate, term);
            
            const int amount = 500;
            var investmentPeriod = new Period(null, null, null, 2);
            var fromDate = new DateTime(2023, 4, 4);
            
            var actualYieldAmount = sut.Yield(amount, investmentPeriod, fromDate);
            
            Assert.Equal(1141.66m, actualYieldAmount);
        }
    }
}