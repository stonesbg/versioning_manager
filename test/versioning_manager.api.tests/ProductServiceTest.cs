using FluentAssertions;
using Moq;
using System.Collections.Generic;
using System.Linq;
using versioning_manager.api.Services;
using versioning_manager.contracts.Data;
using versioning_manager.data.Models;
using Xunit;

namespace versioning_manager.api.tests
{
    public class ProductServiceTest
    {
        IEnumerable<Product> ProductList = new List<Product>
            {
                new Product() {Id = 1, Name = "Product 1", Organization = new Organization() { Id = 1, Name= "Org 1", Description="Description 1"} },
                new Product() {Id = 2, Name = "Product 2", Organization = new Organization() { Id = 2, Name= "Org 2", Description="Description 2"} },
                new Product() {Id = 3, Name = "Product 3", Organization = new Organization() { Id = 1, Name= "Org 1", Description="Description 1"} },
            };

        [Fact]
        public void GetOrganizations()
        {
            var repository = new Mock<IProductRepository>();
            repository.Setup(x => x.GetAll()).Returns(ProductList);

            var service = new ProductService(repository.Object);

            var productList = service.GetAll();
            productList.Count().Should().Be(3);
        }
    }
}
