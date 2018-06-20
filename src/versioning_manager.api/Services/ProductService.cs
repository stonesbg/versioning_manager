﻿using System.Collections.Generic;
using versioning_manager.contracts.Data;
using versioning_manager.contracts.Models;
using versioning_manager.contracts.Services;

namespace versioning_manager.api.Services
{
    public class ProductService : IProductService
    {
        IProductRepository _repository;
        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<IProduct> GetProducts()
        {
            return _repository.GetAll();
        }
    }
}
