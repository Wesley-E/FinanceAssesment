namespace FinanceAssessment.Models.Product
{
    public class InterestRate
    {
        public decimal Amount { get; set; }
        public decimal Percentage { get; set; }

        public InterestRate(decimal amount)
        {
            Amount = amount;
            Percentage = amount * 100;
        }
    }
}