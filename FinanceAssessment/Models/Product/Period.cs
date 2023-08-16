using System;

namespace FinanceAssessment.Models.Product
{
    public class Period
    {
        private readonly DateTime _epoch = new DateTime(1970, 1, 1);
        public double Days { get; private set; }
        public double Weeks { get; private set; }
        public int Months { get; private set; }
        public int Years { get; private set; }

        public Period(int? days, int? weeks, int? months, int? years)
        {
            if (days != null) Days = (double) days;
            if (weeks != null) Weeks = (double) weeks;
            if (months != null) Months = (int) months;
            if (years != null) Years = (int) years;
        }

        public int CompletionDayIndex(DateTime dateTime)
        {
            return (dateTime.AddDays(Days).AddDays(Weeks * 7).AddMonths(Months).AddYears(Years) - _epoch).Days;
        }

        public void AddPeriod(Period period)
        {
            Days += period.Days;
            Weeks += period.Weeks;
            Months += period.Months;
            Years += period.Years;
        }
    }
}