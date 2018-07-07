using LiteDB;
using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.data.Models;

namespace versioning_manager.api.Controllers
{
    public class VersionDetailRepository : IVersionDetailRepository
  {
        public IEnumerable<VersionDetail> GetAll()
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<VersionDetail>("version_detail");
                var result = collection.FindAll();
                return result;
            }
        }

        public IEnumerable<VersionDetail> GetByProductId(int productId)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<VersionDetail>("version_detail");
                var result = collection.Find(x => x.Product.Id == productId);
                return result;
            }
        }

        public VersionDetail Add(VersionDetail versionDetail)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<VersionDetail>("version_detail");

                // Create unique index in Name field
                collection.EnsureIndex(x => x.Id, true);

                // Insert new customer document (Id will be auto-incremented)
                var versionDetailId = collection.Insert(versionDetail);

                var found = collection.FindById(versionDetailId);

                return null;
            }
        }
    }
}
