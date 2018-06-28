using LiteDB;
using System;
using System.Collections.Generic;
using versioning_manager.contracts.Data;

namespace versioning_manager.api.Controllers
{
    public class VersionRepository : IVersionRepository
    {
        public IEnumerable<Version> GetAll()
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<Version>("product");
                var result = collection.FindAll();
                return result;
            }
        }

        public void Add(Version version)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<Version>("product");

                // Create unique index in Name field
                //collection.EnsureIndex(x => x.Id, true);

                // Insert new customer document (Id will be auto-incremented)
                collection.Insert(version);
            }
        }
    }
}
