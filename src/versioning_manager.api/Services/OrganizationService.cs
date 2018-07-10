using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Services;
using versioning_manager.data.Models;

namespace versioning_manager.api.Services
{
    public class OrganizationService : IOrganizationService
    {
        IOrganizationRepository _repository;
        public OrganizationService(IOrganizationRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Organization> GetAll()
        {
            return _repository.GetAll();
        }

        public Organization Get(int id)
        {
            return _repository.Get(id);
        }

        public Organization Add(Organization org)
        {
            return _repository.Add(org);
        }
    }
}
