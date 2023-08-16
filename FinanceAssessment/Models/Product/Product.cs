using System;

namespace FinanceAssessment.Models.Product
{
    public class Product
    {
        public string Name { get; }
        public InterestRate InterestRate { get; }
        public Term Term { get; }
        
        public Product(string name, InterestRate interestRate, Term term)
        {
            Name = name;
            InterestRate = interestRate;
            Term = term;
        }

        public decimal Yield(decimal amount, Period investmentPeriod, DateTime fromDate)
        {
            var numberOfTermsCompleted = Term.NumberOfCompleted(investmentPeriod, fromDate);
            for (var i = 0; i < numberOfTermsCompleted; i++)
            {
                amount *= (1 + InterestRate.Amount);
            }
            
            return Truncate(amount, 2);
        }
        
        private static decimal Truncate(decimal value, int precision)
        {
            var step = (decimal)Math.Pow(10, precision);
            var tmp = Math.Truncate(step * value);
            return tmp / step;
        }

    }
}