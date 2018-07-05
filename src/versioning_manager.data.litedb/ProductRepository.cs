using LiteDB;
using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;

namespace versioning_manager.api.Controllers
{
    public class ProductRepository : IProductRepository
    {
        public IEnumerable<IProduct> GetAll()
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var product = client.GetCollection<IProduct>("product");
 
                var result = product
                    .Include(x => x.Organization)
                    .FindAll();
                
                return result;
            }
        }

        public void Add(IProduct product)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var productCollection = client.GetCollection<IProduct>("product");
                var organizationCollection = client.GetCollection<IOrganization>("organization");

                // Create unique index in Id field
                productCollection.EnsureIndex(x => x.Id, true);

                //var organization = organizationCollection.FindById(product.Organization.Id);
                //product.Organization = organization;

                // Insert new customer document (Id will be auto-incremented)
                productCollection.Insert(product);
            }
        }
    }
}
