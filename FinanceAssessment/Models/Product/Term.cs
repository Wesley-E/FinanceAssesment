using System;

namespace FinanceAssessment.Models.Product
{
    public class Term
    {
        public Period Period { get; }
        
        public Term(Period period)
        {
            Period = period;
        }

        public int NumberOfCompleted(Period investmentPeriod, DateTime fromDate)
        {
            var originalPeriod = new Period((int)Period.Days, (int)Period.Weeks, Period.Months, Period.Years);
            var totalCompletedPeriods = 0;
            while (originalPeriod.CompletionDayIndex(fromDate) <= investmentPeriod.CompletionDayIndex(fromDate))
            {
                originalPeriod.AddPeriod(Period);
                totalCompletedPeriods += 1;
            }

            return totalCompletedPeriods;
        }
    }
}