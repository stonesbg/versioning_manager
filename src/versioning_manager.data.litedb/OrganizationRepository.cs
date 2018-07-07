using LiteDB;
using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;

namespace versioning_manager.data.litedb
{
    public class OrganizationRepository : IOrganizationRepository
    {
        public OrganizationRepository()
        {
            //Add(new Organization() { Name = "Organization 1" });
        }

        public IEnumerable<IOrganization> GetAll()
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<IOrganization>("organization");
                var result = collection.FindAll();
                return result;
            }
        }

        public IOrganization Get(int id)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<IOrganization>("organization");
                var result = collection.FindById(id);
                return result;
            }
        }

        public IOrganization Add(IOrganization organization)
        {
            var connectionString = @"MyData.db";
            // Open database (or create if doesn't exist)
            using (var client = new LiteDatabase(connectionString))
            {
                var collection = client.GetCollection<IOrganization>("organization");

                // Create unique index in Name field
                collection.EnsureIndex(x => x.Id, true);

                // Insert new customer document (Id will be auto-incremented)
                var orgId = collection.Insert(organization);

                return collection.FindById(orgId);
            }
        }
    }
}
