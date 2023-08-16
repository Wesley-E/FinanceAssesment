using System;
using FinanceAssessment.Configuration;
using FinanceAssessment.Repository;
using FinanceAssessment.Services;
using Microsoft.Extensions.DependencyInjection;
using Xamarin.Forms;

namespace FinanceAssessment
{
    public class Bootstrapper
    {
        private readonly Application _app;
        private IServiceCollection _services;
        private readonly IServiceProvider _serviceProvider;

        public Bootstrapper(Application app)
        {
            _app = app;
        }

        public void Start()
        {
            ConfigureServices();
        }

        private void ConfigureServices()
        {
            _services = new ServiceCollection();
            _services.AddSingleton<IProductService, ProductService>();
            _services.AddSingleton<IRepository, Repository.Repository>();
        }
    }
}