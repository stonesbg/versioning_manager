using LiteDB;
using System;
using System.Collections.Generic;
using System.Linq;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;

namespace versioning_manager.api.Controllers
{
    public class VersionDetailRepository : IVersionDetailRepository
  {
        public IEnumerable<IVersionDetail> GetAll()
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<IVersionDetail>("version_detail");
                var result = collection.FindAll();
                return result;
            }
        }

        public IEnumerable<IVersionDetail> GetByProductId(int productId)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<IVersionDetail>("version_detail");
                var result = collection.Find(x => x.Product.Id == productId);
                return result;
            }
        }

        public void Add(IVersionDetail versionDetail)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<IVersionDetail>("version_detail");

                // Create unique index in Name field
                collection.EnsureIndex(x => x.Id, true);

                // Insert new customer document (Id will be auto-incremented)
                collection.Insert(versionDetail);
            }
        }
    }
}
