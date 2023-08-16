namespace FinanceAssessment.Models.Controls
{
    public class Product
    {
        #region Computed Properties
        public string ProductName { get; set; } = "";
        public string Interest { get; set; } = "";
        public string InvestmentReturn { get; set; } = "";
        #endregion

        #region Constructors
        public Product()
        {
        }

        public Product(string product, string interest, string investmentReturn)
        {
            ProductName = product;
            Interest = interest;
            InvestmentReturn = investmentReturn;
        }
        
        #endregion
    }
}