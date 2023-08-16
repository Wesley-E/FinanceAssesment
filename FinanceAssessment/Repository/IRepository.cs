using System.Collections.Generic;
using FinanceAssessment.Models.Repository;

namespace FinanceAssessment.Repository
{
    public interface IRepository 
    {
        Dictionary<string, RepositoryProduct> LoadProducts(string path);
    }
}