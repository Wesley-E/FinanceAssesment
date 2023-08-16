using System;
using System.Collections.Generic;
using FinanceAssessment.Models.Product;
using FinanceAssessment.ValueSets;
using Xunit;

namespace FinanceAssessment.Tests.Models.Product
{
    public class ProductsTests
    {
        private readonly Products _sut;
        private const string ProductA = "ProductA";
        private const string ProductB = "ProductB";

        public ProductsTests()
        {
            var productList = new List<FinanceAssessment.Models.Product.Product>()
            {
                new FinanceAssessment.Models.Product.Product(
                    ProductA,
                    new InterestRate(0.035m),
                    new Term(new Period(0, 0, 0, 2))),
                new FinanceAssessment.Models.Product.Product(
                    ProductB,
                    new InterestRate(0.045m),
                    new Term(new Period(0, 0, 0, 2)))
            };
            
            _sut = new Products(productList);
        }

        [Fact]
        public void ProductsRankHighest_OrdersProducts_HighestToLowest()
        {
            var products = _sut.Rank(
                2000m,
                new Period(0, 0, 0, 4),
                new DateTime(2023, 4, 4),
                Rank.Highest);
            
            Assert.Equal(ProductB, products[0].Name);
            Assert.Equal(ProductA, products[1].Name);
        }
        
        [Fact]
        public void ProductsRankLowest_OrdersProducts_LowestToHighest()
        {
            var products = _sut.Rank(
                2000m,
                new Period(0, 0, 0, 4),
                new DateTime(2023, 4, 4),
                Rank.Lowest);
            
            Assert.Equal(ProductA, products[0].Name);
            Assert.Equal(ProductB, products[1].Name);
        }
    }
}