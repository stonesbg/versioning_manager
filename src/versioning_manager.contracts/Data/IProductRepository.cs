﻿using System.Collections.Generic;
using versioning_manager.contracts.Models;

namespace versioning_manager.contracts.Data
{
    public interface IProductRepository
    {
        IEnumerable<IProduct> GetAll();

        void Add(IProduct product);
    }
}