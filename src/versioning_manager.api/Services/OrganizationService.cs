using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;
using versioning_manager.contracts.Services;

namespace versioning_manager.api.Services
{
    public class OrganizationService : IOrganizationService
    {
        IOrganizationRepository _repository;
        public OrganizationService(IOrganizationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IOrganization> GetOrganizations()
        {
            return _repository.GetAll();
        }

        public void AddOrganization(IOrganization org)
        {
            _repository.Add(org);
        }
    }
}
