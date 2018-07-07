using LiteDB;
using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.data.Models;

namespace versioning_manager.data.litedb
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public OrganizationRepository()
        {
            //Add(new Organization() { Name = "Organization 1" });
        }

        public IEnumerable<Organization> GetAll()
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<Organization>("organization");
                var result = collection.FindAll();
                return result;
            }
        }

        public Organization Get(int id)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<Organization>("organization");
                var result = collection.FindById(id);
                return result;
            }
        }

        public Organization Add(Organization organization)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<Organization>("organization");

                // Create unique index in Name field
                collection.EnsureIndex(x => x.Id, true);

                // Insert new customer document (Id will be auto-incremented)
                var orgId = collection.Insert(organization);

                return collection.FindById(orgId);
            }
        }
    }
}
