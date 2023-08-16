using System;
using System.Collections.Generic;
using System.IO;
using FinanceAssessment.Models.Product;
using FinanceAssessment.Models.Repository;
using FinanceAssessment.Repository;
using Newtonsoft.Json;
using Xunit;

namespace FinanceAssessment.Tests.Repository
{
    public class RepositoryTests
    {
        private readonly IRepository _sut;
        private const string FileName = "testProducts.json";
        private const string InvalidFileName = "badDataTestProducts.json";
        private readonly string _productFile;
        private readonly string _invalidProductFile;

        public RepositoryTests()
        {
            var currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            _productFile = Path.GetFullPath(Path.Combine(currentDirectory, $@"../../Repository/{FileName}"));
            _invalidProductFile = Path.GetFullPath(Path.Combine(currentDirectory, $@"../../Repository/{InvalidFileName}"));
            _sut = new FinanceAssessment.Repository.Repository();
        }

        [Fact]
        public void RepositoryLoadProducts_SuccessfullyLoadsProducts_ForValidPath()
        {
            var products = _sut.LoadProducts(_productFile);

            var expected = new Dictionary<string, RepositoryProduct>
            {
                {
                    "productA", new RepositoryProduct
                    {
                        InterestRate = new InterestRate(0.03m),
                        Period = new Period(0, 0,0,2)

                    }
                },
                {
                    "productB", new RepositoryProduct
                    {
                        InterestRate = new InterestRate(0.0295m),
                        Period = new Period(0, 0,1,0)
                    }
                }
            };

            Assert.True(ProductsMatch(expected, products));
        }

        [Fact]
        public void RepositoryLoadProducts_RaisesFileNotFoundException_ForInvalidPath()
        {
            Assert.Throws<FileNotFoundException>(() => _sut.LoadProducts("invalidPath"));
        }
        
        [Fact]
        public void RepositoryLoadProducts_RaisesJsonException_ForIncorrectFileModelFormat()
        {
            Assert.Throws<JsonException>(() => _sut.LoadProducts(_invalidProductFile));
        }

        private static bool ProductsMatch(
            Dictionary<string, RepositoryProduct> expected,
            IReadOnlyDictionary<string, RepositoryProduct> actual)
        {
            foreach (var product in expected)
            {
                Assert.Equal(product.Value.InterestRate.Amount, actual[product.Key].InterestRate.Amount);
                Assert.Equal(product.Value.Period.Days, actual[product.Key].Period.Days);
                Assert.Equal(product.Value.Period.Weeks, actual[product.Key].Period.Weeks);
                Assert.Equal(product.Value.Period.Months, actual[product.Key].Period.Months);
                Assert.Equal(product.Value.Period.Years, actual[product.Key].Period.Years);
            }

            return true;
        }
    }
}