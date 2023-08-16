using System;
using System.Collections.Generic;
using System.Linq;
using FinanceAssessment.ValueSets;

namespace FinanceAssessment.Models.Product
{
    public class Products
    {
        public Dictionary<string, Product> All { get; } = new Dictionary<string, Product>();

        public Products(List<Product> all)
        {
            foreach (var product in all)
            {
                All.Add(product.Name, product);
            }
        }

        public List<Product> Rank(decimal investmentAmount, Period investmentPeriod, DateTime fromDate, Rank order)
        {
            var yield = new Dictionary<decimal, Product>();
            foreach (var (_, value) in All)
            {
                yield.Add(value.Yield(investmentAmount, investmentPeriod, fromDate), value);
            }
            switch (order)
            {
                case ValueSets.Rank.Highest:
                    return (from product in yield 
                        orderby product.Key descending select product.Value).ToList();
                case ValueSets.Rank.Lowest:
                    return (from product in yield 
                        orderby product.Key select product.Value).ToList();
                default:
                    throw new ArgumentOutOfRangeException(nameof(order), order, "Unknown rank type given");
            }
        }
    }
}