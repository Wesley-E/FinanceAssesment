using System.Collections.Generic;
using FinanceAssessment.Models;
using FinanceAssessment.Models.Product;
using FinanceAssessment.Models.Repository;

namespace FinanceAssessment.Services
{
    public interface IProductService
    {
        Product CreateProduct(string productName, InterestRate interestRate, Term term);
        Dictionary<string, RepositoryProduct> LoadProducts(string productFile);
        Products BuildProducts(Dictionary<string, RepositoryProduct> products);
    }
}