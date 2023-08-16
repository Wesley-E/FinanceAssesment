using System.Collections.Generic;
using FinanceAssessment.Models;
using FinanceAssessment.Models.Product;
using FinanceAssessment.Models.Repository;
using FinanceAssessment.Repository;
using FinanceAssessment.Services;
using NSubstitute;
using Xunit;

namespace FinanceAssessment.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly IProductService _sut;
        private readonly IRepository _repository;
        private readonly InterestRate _interestRate;
        private readonly Term _term;
        private const string ProductA = "productA";
        private const string ProductB = "productB";
        private const decimal InterestRateAmountA = 0.03m;
        private const decimal InterestRateAmountB = 0.0295m;
        private const int Days = 1;
        private const int Weeks = 2;
        private const int Months = 3;
        private const int Years = 4;
        private readonly Dictionary<string, RepositoryProduct> _repositoryProducts = 
            new Dictionary<string, RepositoryProduct> 
            {
                {
                    ProductA, new RepositoryProduct 
                    {
                        InterestRate = new InterestRate(InterestRateAmountA), 
                        Period = new Period(Days, Weeks, Months, Years)
                    }
                    
                },
                {
                    ProductB, new RepositoryProduct
                    {
                        InterestRate = new InterestRate(InterestRateAmountB),
                        Period = new Period(Days, Weeks, Months, Years)
                    }
                }
            };
        
        public ProductServiceTests()
        {
            _repository = Substitute.For<IRepository>();
            _repository.LoadProducts(Arg.Any<string>()).Returns(_repositoryProducts);
            _sut = new ProductService(_repository);
            _interestRate = new InterestRate(InterestRateAmountA);
            _term = new Term(new Period(Days, Weeks, Months, Years));
        }

        [Fact]
        public void CreateProduct_BuildsProduct_ReturnsProduct()
        {
            var product = _sut.CreateProduct(ProductA, _interestRate, _term);
            Assert.Equal(ProductA, product.Name);
            Assert.Equal(InterestRateAmountA, product.InterestRate.Amount);
            Assert.Equal(Days, product.Term.Period.Days);
            Assert.Equal(Weeks, product.Term.Period.Weeks);
            Assert.Equal(Months, product.Term.Period.Months);
            Assert.Equal(Years, product.Term.Period.Years);
        }

        [Fact]
        public void LoadProducts_ReturnsProductDictionary()
        {
            var products = _sut.LoadProducts("productFile");
            
            Assert.True(ProductsMatch(_repositoryProducts, products));
        }

        [Fact]
        public void BuildProducts_ReturnsProducts_FromProductDictionary()
        {
            var products = _sut.BuildProducts(_repositoryProducts);
            
            Assert.Equal(ProductA, products.All[ProductA].Name);
            Assert.Equal(Days, products.All[ProductA].Term.Period.Days);
            Assert.Equal(Weeks, products.All[ProductA].Term.Period.Weeks);
            Assert.Equal(Months, products.All[ProductA].Term.Period.Months);
            Assert.Equal(Years, products.All[ProductA].Term.Period.Years);
            Assert.Equal(InterestRateAmountA, products.All[ProductA].InterestRate.Amount);
            Assert.Equal(ProductB, products.All[ProductB].Name);
            Assert.Equal(Days, products.All[ProductB].Term.Period.Days);
            Assert.Equal(Weeks, products.All[ProductB].Term.Period.Weeks);
            Assert.Equal(Months, products.All[ProductB].Term.Period.Months);
            Assert.Equal(Years, products.All[ProductB].Term.Period.Years);
            Assert.Equal(InterestRateAmountB, products.All[ProductB].InterestRate.Amount);
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