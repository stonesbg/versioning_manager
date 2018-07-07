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

        public IEnumerable<IOrganization> GetAll()
        {
            return _repository.GetAll();
        }

        public IOrganization Get(int id)
        {
            return _repository.Get(id);
        }

        public IOrganization Add(IOrganization org)
        {
            return _repository.Add(org);
        }
    }
}
